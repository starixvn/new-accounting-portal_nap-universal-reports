import {
  Component,
  ViewChild,
  ViewContainerRef,
  ComponentFactoryResolver,
  ComponentFactory,
  Input,
  OnDestroy,
  OnChanges,
  ReflectiveInjector,
  Injector,
  SimpleChanges
} from '@angular/core';
import { UpdatedUsernameComponent } from './../updated-username/updated-username.component';
import { UpdatedCreditComponent } from './../updated-credit/updated-credit.component';
import { Grid } from './grid.model';
import { FilterModel } from './../filter/filter.model';
import { QueryModelService } from './../common/query-model.service';
import { BreadcrumbService } from './../common/breadcrumb.service';
import { UpdatedUsernameService } from './../updated-username/updated-username.service';
import { UpdatedCreditService } from './../updated-credit/updated-credit.service';
import { PaginationConfig } from 'nap-components/pagination';
import { CustomPaginationConfig } from '../common/config';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: [
    './grid.component.scss'
  ],
  entryComponents: [
    UpdatedCreditComponent,
    UpdatedUsernameComponent,
  ],
  providers: [
    UpdatedCreditService,
    UpdatedUsernameService,
    QueryModelService,
    BreadcrumbService,
    { provide: PaginationConfig, useClass: CustomPaginationConfig }
  ]
})
export class GridComponent implements OnChanges, OnDestroy {
  breadcrumbItems: string[];
  @Input() filterModel: FilterModel;
  @ViewChild('container', { read: ViewContainerRef }) container: ViewContainerRef;

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private injector: Injector
  ) { }

  ngOnChanges(changes: SimpleChanges) {
    this.clear();

    if (this.filterModel) {
      this.createGrid();
    }
  }

  ngOnDestroy() {
    this.clear();
  }

  private generate() {
    this.createGrid();
  }

  private createGrid() {
    const factory = this.getComponentFactory();
    const component = this.container.createComponent(factory);
    const grid = component.instance;
    grid.query(this.filterModel);
  }

  private getComponentFactory(): ComponentFactory<Grid> {
    switch (this.filterModel.reportBy) {
      case 'Updated Credit':
        return this.componentFactoryResolver.resolveComponentFactory(UpdatedCreditComponent);
      case 'Updated Username':
        return this.componentFactoryResolver.resolveComponentFactory(UpdatedUsernameComponent);
      default:
        throw new Error('Not implemented yet');
    }
  }

  private clear() {
    this.container.clear();
  }
}
