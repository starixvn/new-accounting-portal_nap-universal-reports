import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { GridService } from './grid.service';
import { Exchange, ExchangeModel } from './grid.model';
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
export class GridComponent implements OnChanges {
  @Input() filterModel: FilterModel;
  exchangeModel: ExchangeModel;
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

  ngOnChanges() {
    if (this.filterModel) {
      this.gridService.queryReport(this.filterModel).subscribe(result => {
        const breadcrumb = this.breadcrumbService.createBreadcrumb(this.filterModel);
        this.breadcrumbItems = [breadcrumb];
        this.exchangeModel = result ;
        this.paginationInstance = this.paginationService.createPaginationInstance(this.exchangeModel.Entities.length);
        this.onPageChange();
      });
    }
  }

  onPageChange() {
    this.createExchangePaging();
  }

  exportExcel() {
    this.gridService.exportExcel(this.filterModel);
  }

  private createExchangePaging() {
    const paginateExchange = this.paginatePipe.transform(this.exchangeModel.Entities, this.paginationInstance);
    this.displayExchange = _.cloneDeep(paginateExchange);
  }
}
