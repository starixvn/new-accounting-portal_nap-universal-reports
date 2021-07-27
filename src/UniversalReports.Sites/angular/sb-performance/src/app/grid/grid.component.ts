import { Component, ComponentFactory, ComponentFactoryResolver, ComponentRef, Input,
  OnChanges,
  OnDestroy, OnInit, Renderer2, ViewChild, ViewContainerRef } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { Grid, GridType } from './grid.model';
import { GridService } from './grid.service';
import { SiteGridComponent } from './site-grid/site-grid.component';
import * as _ from 'lodash';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss'],
  entryComponents: [
    SiteGridComponent
  ]
})
export class GridComponent implements OnInit, OnChanges, OnDestroy {
  @Input() filterModel: FilterModel;
  @ViewChild('container', { read: ViewContainerRef }) container: ViewContainerRef;

  gridType = GridType.MarginBySite;
  breadcrumbItems: string[];
  private components: ComponentRef<Grid>[] = [];

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private renderer: Renderer2,
    private service: GridService
  ) { }

  ngOnInit() {
    this.service.generate = (gridType: GridType, queryModel: any) => this.generate(gridType, queryModel);
  }

  ngOnDestroy() {
    this.container.clear();
  }

  ngOnChanges() {
    this.breadcrumbItems = [];
    while (this.components.length) {
      const component = this.components.pop();
      component.destroy();
    }

    this.gridType = GridType.MarginBySite;
    this.service.queryModel = _.assign(this.filterModel, this.service.queryModel);
    this.createGridComponent();
  }

  private generate(gridType: GridType, model: any) {
    this.service.queryModel = model;
    this.gridType = gridType;
    this.createGridComponent();
  }

  private getComponentFactory(): ComponentFactory<Grid> {
    switch (this.gridType) {
        case GridType.MarginBySite:
            return this.componentFactoryResolver.resolveComponentFactory(SiteGridComponent);
        default:
            throw new Error('Not implemented yet');
    }
  }

  private createGridComponent() {
    const factory = this.getComponentFactory();
    const component = this.container.createComponent(factory);
    this.components.push(component);

    const grid = component.instance;
    this.service.activeGrid = grid;
    grid.query().subscribe({
      complete: () => this.showGridAndBreadcrumb()
    });
  }

  private showGridAndBreadcrumb() {
    this.updateBreadcrumb();
    this.showOnlyLastGrid();
  }

  private updateBreadcrumb() {
    this.breadcrumbItems = [this.service.mainTitle];
    this.components.forEach(component => {
      const componentTitle = component.instance.title;
      this.breadcrumbItems.push(componentTitle);
    });

    this.service.breadCrumb = this.breadcrumbItems.join(' > ');
  }

  private showOnlyLastGrid() {
    const length = this.components.length;
    const currentComponent = this.components[length - 1];
    this.renderer.removeAttribute(currentComponent.location.nativeElement, 'hidden');

    if (length > 1) {
      const lastComponent = this.components[length - 2];
      this.renderer.setAttribute(lastComponent.location.nativeElement, 'hidden', 'hidden');
    }
  }

  private destroyComponentsFrom(index: number) {
    while (this.components.length - 1 > index) {
      const component = this.components.pop();
      component.destroy();
    }

    this.service.activeGrid = this.components[this.components.length - 1].instance;
    this.showGridAndBreadcrumb();
  }

  onBreadcrumbItemClick(event: number) {
    this.destroyComponentsFrom(event);
    this.showGridAndBreadcrumb();
  }
}
