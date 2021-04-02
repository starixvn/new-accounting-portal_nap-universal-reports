import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { PaginationInstance, PaginatePipe, PaginationService as NgxPaginationService } from 'ngx-pagination';
import { PaginationService } from 'nap-components/pagination';
import { SummaryEntity, TicketModel } from '../common/model';
import { GridService } from './grid.service';
import { FilterModel } from '../filter/filter.model';
import * as _ from 'lodash';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnChanges {
  @Input() filterModel: FilterModel;
  
  dataModel: SummaryEntity;
  paginationInstance: PaginationInstance;
  displayData: TicketModel[];
  breadcrumbItems: string[];

  private paginatePipe: PaginatePipe;

  constructor(
    private readonly service: GridService,
    private readonly paginationService: PaginationService,
    private readonly ngxPaginationService: NgxPaginationService) {
    this.paginatePipe = new PaginatePipe(this.ngxPaginationService);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (!this.filterModel) {
      return;
    }

    this.service.getTickets(this.filterModel).subscribe(data => {
      this.dataModel = data;
      const breadcrumb = this.Title;
      this.breadcrumbItems = [breadcrumb];
      this.paginationInstance = this.paginationService.createPaginationInstance(this.dataModel.Entities.length);
      this.onPageChange();
    });
  }

  exportExcel() {
    this.service.exportExcel(this.filterModel);
  }

  onPageChange() {
    this.createPaging();
  }

  private createPaging() {
    if (this.filterModel.isPageChanged) {
      this.filterModel.pageIndex = this.paginationInstance.currentPage;
      this.filterModel.pageSize = this.paginationInstance.itemsPerPage;

      this.service.getTickets(this.filterModel).subscribe(data => {
        this.dataModel = data;
        this.createPagingTransform();
      });
    }

    this.createPagingTransform();
  }

  private createPagingTransform() {
    const paginateData = this.paginatePipe.transform(this.dataModel.Entities, this.paginationInstance);
    this.dataModel.Entities = _.cloneDeep(paginateData);
    this.filterModel.isPageChanged = true;
  }

  get hasData(): boolean {
    return !_.isNil(this.dataModel) && this.dataModel.Entities.length > 0;
  }

  get Title(): string {
    return `Cash Out Performance Report From ${this.filterModel.startDate} To ${this.filterModel.endDate}`;
  }
}
