import {
    Component,
    OnInit,
    Input,
    ViewContainerRef,
    ViewChild,
    Renderer2,
    ComponentFactoryResolver,
    ComponentRef,
    ComponentFactory,
    SimpleChanges,
    OnDestroy,
    OnChanges,
    AfterViewInit
} from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { FilterModel } from '../filter/filter.model';
import { TicketGridComponent } from './ticket-grid/ticket-grid.component';
import { ProductGridComponent } from './product-grid/product-grid.component';
import { Grid, GridType } from './grid.model';
import { GridService } from './grid.service';
import { Subject } from 'rxjs/Subject';

@Component({
    selector: 'app-grid',
    templateUrl: './grid.component.html',
    styleUrls: ['./grid.component.scss'],
    entryComponents: [
        ProductGridComponent,
        TicketGridComponent
    ]
})
export class GridComponent implements OnInit, OnChanges, OnDestroy {
    @Input() filterModel: FilterModel;
    @ViewChild('container', { read: ViewContainerRef, static: true }) container: ViewContainerRef;
    gridType = GridType.Product;
    breadcrumbItems: string[];
    private showGridCompletedSubscription: Subscription;
    private generateTicketGridSubscription: Subscription;
    private latestComponent: ComponentRef<Grid>;
    private components: ComponentRef<Grid>[] = [];
    private filterChanging: boolean;

    constructor(
        private componentFactoryResolver: ComponentFactoryResolver,
        private renderer: Renderer2,
        private service: GridService) { }

    ngOnInit() {
        this.service.showGridCompletedSubject = new Subject<number>();
        this.service.generateTicketGridSubject = new Subject<number>();
        this.showGridCompletedSubscription = this.service.showGridCompletedSubject.subscribe(() => this.showGridCompleted());
        this.generateTicketGridSubscription = this.service.generateTicketGridSubject.subscribe(() => this.generateTicketGrid());
    }

    ngOnChanges() {
        this.filterChanging = true;
        this.service.filterModel = this.filterModel;
        this.latestComponent = this.createGridComponent();
    }

    ngOnDestroy() {
        this.clear();
        this.showGridCompletedSubscription.unsubscribe();
        this.generateTicketGridSubscription.unsubscribe();
    }

    private clear() {
        this.container.clear();
        this.components = [];
    }

    private generateTicketGrid() {
        this.gridType = GridType.Ticket;
        this.latestComponent = this.createGridComponent();
    }

    private getComponentFactory(): ComponentFactory<Grid> {
        switch (this.gridType) {
            case GridType.Product:
                return this.componentFactoryResolver.resolveComponentFactory(ProductGridComponent);
            case GridType.Ticket:
                return this.componentFactoryResolver.resolveComponentFactory(TicketGridComponent);
            default:
                throw new Error('Not implemented yet');
        }
    }

    private createGridComponent(): ComponentRef<Grid> {
        const factory = this.getComponentFactory();
        const component = this.container.createComponent(factory);
        const grid = component.instance;
        grid.query();
        return component;
    }

    private showGridCompleted() {
        if (this.filterChanging) {
            const removeIndex = this.gridType === GridType.Product ? 0 : 1;
            this.destroyComponentsFrom(removeIndex);
        }

        this.components.push(this.latestComponent);
        this.filterChanging = false;
        this.showGridAndBreadcrumb();
    }

    private destroyComponentsFrom(index: number) {
        while (this.components.length - 1 >= index) {
            const component = this.components.pop();
            component.destroy();
        }
    }

    private showGridAndBreadcrumb() {
        this.service.activeGrid = this.components[this.components.length - 1].instance;
        this.updateBreadcrumb();
        this.showOnlyLastGrid();
    }

    private updateBreadcrumb() {
        this.breadcrumbItems = [];
        this.components.forEach(component => {
            const componentTitle = component.instance.title;
            this.breadcrumbItems.push(componentTitle);
        });
    }

    private showOnlyLastGrid() {
      const length = this.components.length;
      const currentComponent = this.components[length - 1];
      this.renderer.removeAttribute(currentComponent.location.nativeElement, 'hidden');

      // for (let i = 0; i < this.components.length - 1; i++) {
      //     const component = this.components[i];
      //     this.renderer.setAttribute(component.location.nativeElement, 'hidden', 'hidden');
      // }
      if (length > 1) {
        const lastComponent = this.components[length - 2];
        this.renderer.setAttribute(lastComponent.location.nativeElement, 'hidden', 'hidden');
      }
    }

    onBreadcrumbItemClick(event: Event) {
        this.gridType = GridType.Product;
        this.destroyComponentsFrom(1);
        this.showGridAndBreadcrumb();
    }

    exportExcel() {
        if (this.components.length === 0) {
            return;
        }
        const component = this.components[this.components.length - 1];
        const grid = component.instance;
        grid.exportExcel();
    }

}
