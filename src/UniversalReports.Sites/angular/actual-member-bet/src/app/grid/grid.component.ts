import {
  Component,
  OnInit,
  Input,
  ViewContainerRef,
  ViewChild,
   Injector,
  Renderer,
  ComponentFactoryResolver,
  ComponentRef,
  ComponentFactory,
  SimpleChanges,
  OnDestroy,
  OnChanges} from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { BettypeGridComponent } from './bettype-grid/bettype-grid.component';
import { ProductGridComponent } from './product-grid/product-grid.component';
import { Grid, GridType } from './grid.model';
import { GridService } from './grid.service';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss'],
  entryComponents: [
    ProductGridComponent,
    BettypeGridComponent
  ]
})
export class GridComponent implements OnInit, OnChanges, OnDestroy {
  @Input() filterModel: FilterModel;
  @ViewChild('container', { read: ViewContainerRef }) container: ViewContainerRef;
  GridType = GridType;
  gridType = GridType.Product;
  breadcrumbItems: string[];
  private components: ComponentRef<Grid>[] = [];

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private injector: Injector,
    private renderer: Renderer,
    private service: GridService) { }

    ngOnInit() {
        this.service.generate = (gridType: GridType) => this.generate(gridType);
        this.service.goBack = (index: number) => this.goBack(index);
    }

    ngOnChanges(changes: SimpleChanges) {
        this.clear();
        this.gridType = GridType.Product;
        this.service.filterModel = this.filterModel;
        this.createGrid();
    }

    ngOnDestroy() {
        this.clear();
    }

    private clear() {
        this.container.clear();
        this.components = [];
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
            case GridType.Product:
                return this.componentFactoryResolver.resolveComponentFactory(ProductGridComponent);
            case GridType.Bettype:
                return this.componentFactoryResolver.resolveComponentFactory(BettypeGridComponent);
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
