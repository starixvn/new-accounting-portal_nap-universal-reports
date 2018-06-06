import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { GridService } from './grid.service';
import { Exchange } from './grid.model';
import { FilterModel } from '../filter/filter.model';
import { PaginationInstance, PaginatePipe, PaginationService as NgxPaginationService } from 'ngx-pagination';
import { BreadcrumbService } from '../common/breadcrumb.service';
import { PaginationService } from 'nap-components/pagination';
import * as _ from 'lodash';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss'],
  providers: [
    GridService,
    BreadcrumbService
  ]
})
export class GridComponent implements OnInit, OnChanges {
  @Input() filterModel: FilterModel;
  exchanges: Exchange[];
  breadcrumbItems: string[];
  displayExchange: Exchange[];
  paginationInstance: PaginationInstance;
  private paginatePipe: PaginatePipe;

  constructor(private gridService: GridService,
    private breadcrumbService: BreadcrumbService,
    private paginationService: PaginationService,
    private ngxPaginationService: NgxPaginationService) {
      this.paginatePipe = new PaginatePipe(this.ngxPaginationService);
    }

  ngOnInit() {
  }

  ngOnChanges() {
    // this.gridService.queryReport(this.filterModel).subscribe(result => {
    //   const breadcrumb = this.breadcrumbService.createBreadcrumb(this.filterModel);
    //   this.breadcrumbItems = [breadcrumb];
    //   this.exchanges = result ;
    //   this.paginationInstance = this.paginationService.createPaginationInstance(this.exchanges.length);
    //   this.onPageChange();
    // });
  }

  onPageChange() {
    this.createExchangePaging();
  }

  exportExcel() {

  }

  private createExchangePaging() {
    const paginateExchange = this.paginatePipe.transform(this.exchanges, this.paginationInstance);
    this.displayExchange = _.cloneDeep(paginateExchange);
  }
}
