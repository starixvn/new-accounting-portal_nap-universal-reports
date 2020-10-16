import { Component } from '@angular/core';
import * as _ from 'lodash';
import { PaginationInstance, PaginatePipe, PaginationService as NgxPaginationService } from 'ngx-pagination';
import { PaginationService } from 'nap-components/pagination';
import { Grid } from '../grid.model';
import { GridService } from '../grid.service';
import { TicketGridService } from './ticket-grid.service';
import { VoidTicketModel } from './ticket-grid.model';

@Component({
    selector: 'app-ticket-grid',
    templateUrl: './ticket-grid.component.html',
    styleUrls: ['./ticket-grid.component.scss']
})
export class TicketGridComponent implements Grid {
  voidTicketModel: VoidTicketModel;
  paginationInstance: PaginationInstance;
  private paginatePipe: PaginatePipe;

  constructor(
      private readonly gridService: GridService,
      private readonly ticketService: TicketGridService,
      private readonly paginationService: PaginationService,
      private readonly ngxPaginationService: NgxPaginationService) {
      this.paginatePipe = new PaginatePipe(this.ngxPaginationService);
  }

  query() {
    this.ticketService.query().subscribe(data => {
        this.voidTicketModel = data;
        this.gridService.showGridCompletedSubject.next(0);
        this.paginationInstance = this.paginationService.createPaginationInstance(this.voidTicketModel.TotalItems);
        this.onPageChange();
    });
  }

  exportExcel() {
  }

  get hasExcel(): boolean {
      return this.hasData;
  }

  get hasData(): boolean {
    return !_.isNil(this.voidTicketModel) && this.voidTicketModel.Tickets.length > 0;
  }

  get title(): string {
      return this.gridService.productName;
  }

  onPageChange() {
    this.createPaging();
  }

  private createPaging() {
    if (this.gridService.filterModel.isPageChanged) {
      this.gridService.filterModel.pageIndex = this.paginationInstance.currentPage;
      this.gridService.filterModel.pageSize = this.paginationInstance.itemsPerPage;

      this.ticketService.query().subscribe(data => {
        this.voidTicketModel = data;
        this.createPagingTransform();
      });
    }

    this.createPagingTransform();
  }

  private createPagingTransform() {
    const paginateData = this.paginatePipe.transform(this.voidTicketModel.Tickets, this.paginationInstance);
    this.voidTicketModel.Tickets = _.cloneDeep(paginateData);
    this.gridService.filterModel.isPageChanged = true;
  }
}
