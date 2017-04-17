import {
    Component, Input, OnInit, OnChanges, ComponentFactoryResolver, Injector, ViewContainerRef,
    ComponentRef, ViewChild, SimpleChanges, OnDestroy, ComponentFactory, Renderer
} from '@angular/core';
import * as _ from 'lodash';
import { FilterModel } from '../filter/filter.model';
import { GridService } from './grid.service';
import { Grid, GridType } from './grid.model';
import { SummaryGridComponent } from './summary-grid/summary-grid.component';

@Component({
    selector: 'nap-grid',
    templateUrl: './grid.component.html',
    styleUrls: ['./grid.component.scss'],
    entryComponents: [
    ]
})
export class GridComponent implements OnInit, OnChanges, OnDestroy {
    @Input() filterModel: FilterModel;
    @ViewChild('container', { read: ViewContainerRef }) container: ViewContainerRef;
    GridType = GridType;
    gridType = GridType.Summary;
    breadcrumbItems: string[];
    private components: ComponentRef<Grid>[] = [];

    constructor(
        private componentFactoryResolver: ComponentFactoryResolver,
        private injector: Injector,
        private renderer: Renderer,
        private service: GridService
    ) { }

    ngOnInit() {
        this.service.generate = (gridType: GridType) => this.generate(gridType);
        this.service.goBack = (index: number) => this.goBack(index);
    }

    ngOnChanges(changes: SimpleChanges) {
        this.gridType = GridType.Summary;
        this.service.filterModel = this.filterModel;
        this.createGrid();
    }

    ngOnDestroy() {
        this.container.clear();
    }

    private generate(gridType: GridType) {
        this.gridType = gridType;
        this.createGrid();
    }

    private goBack(index: number) {
        while (this.components.length - 1 > index) {
            const component = this.components.pop();
            component.destroy();
        }
        this.afterGridChange();
    }

    private getComponentFactory(): ComponentFactory<Grid> {
        switch (this.gridType) {
            case GridType.Summary:
                return this.componentFactoryResolver.resolveComponentFactory(SummaryGridComponent);
            default:
                throw new Error('Not implemented yet');
        }
    }

    private createGrid() {
        const factory = this.getComponentFactory();
        const component = this.container.createComponent(factory);
        this.components.push(component);
        const grid = component.instance;
        grid.query();
        this.afterGridChange();
    }

    private afterGridChange() {
        this.service.activeGrid = this.components[this.components.length - 1].instance;
        this.updateBreadcrumb();
        this.showCurrentAndHideLast();
    }

    private updateBreadcrumb() {
        this.breadcrumbItems = [];
        this.components.forEach(component => {
            const componentTitle = component.instance.title;
            this.breadcrumbItems.push(componentTitle);
        });
    }

    private showCurrentAndHideLast() {
        const length = this.components.length;
        const currentComponent = this.components[length - 1];
        this.renderer.setElementAttribute(currentComponent.location.nativeElement, 'hidden', null);
        if (length > 1) {
            const lastComponent = this.components[length - 2];
            this.renderer.setElementAttribute(lastComponent.location.nativeElement, 'hidden', 'hidden');
        }
    }
}
