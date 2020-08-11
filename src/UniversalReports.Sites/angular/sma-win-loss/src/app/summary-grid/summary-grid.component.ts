import { VirtualRateModel } from './../common/model';
import { VirtualRateGridComponent } from './../virtual-rate-grid/virtual-rate-grid.component';
import { Component, OnChanges, Input, SimpleChanges } from '@angular/core';
import * as _ from 'lodash';
import { SummaryGridService } from './summary-grid.service';
import { FilterModel } from '../filter/filter.model';
import { WinLossModel, UsernameModel } from '../common/model';
import { QueryModelService } from '../common/queryModel.service';
import { PaginationInstance, PaginatePipe, PaginationService as NgxPaginationService } from 'ngx-pagination';
import { PaginationService } from 'nap-components/pagination';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-summary-grid',
  templateUrl: './summary-grid.component.html',
  styleUrls: ['./summary-grid.component.scss'],
  providers: [
    SummaryGridService,
    QueryModelService]
})
export class SummaryGridComponent implements OnChanges {
  @Input() filterModel: FilterModel;
  summaryWinLosses: WinLossModel;
  displaySummaryWinLosses: UsernameModel[];
  year: number;
  breadcrumbItems: string[];
  paginationInstance: PaginationInstance;
  virtualRateData: VirtualRateModel[];
  virtualRateTitle: string;
  private paginatePipe: PaginatePipe;

  constructor(
    private readonly service: SummaryGridService,
    private readonly paginationService: PaginationService,
    private readonly ngxPaginationService: NgxPaginationService,
    private readonly modalService: NgbModal) {
    this.paginatePipe = new PaginatePipe(this.ngxPaginationService);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (!this.filterModel) {
      return;
    }

    this.year = this.filterModel.year;

    this.service.query(this.filterModel).subscribe(data => {
      this.summaryWinLosses = data;
      const breadcrumb = this.Title;
      this.breadcrumbItems = [breadcrumb];
      this.paginationInstance = this.paginationService.createPaginationInstance(this.summaryWinLosses.TotalItems);
      this.onPageChange();
    });
  }

  get hasData(): boolean {
    return !_.isNil(this.summaryWinLosses) && this.summaryWinLosses.UsernameWinLosses.length > 0;
  }

  get Title(): string {
    return 'SMA Win Loss Summary Report For ' + this.year + this.getLevelName(this.filterModel.custLevel);
  }

  onPageChange() {
    this.createPaging();
  }

  isValidNumber(value: number): boolean {
    return !_.isNaN(value) && _.isFinite(value) && _.isNumber(value);
  }

  showVirtualRate(custId: number, username: string) {
    this.service.queryVirtualRate(custId).subscribe(data => {
      this.virtualRateTitle = `Virtual Rate Details (${username})`;
      this.virtualRateData = data;
      this.showModal();
    });
  }

  private createPaging() {
    if (this.filterModel.isPageChanged) {
      this.filterModel.isGenerated = false;
      this.filterModel.pageIndex = this.paginationInstance.currentPage - 1;
      this.filterModel.pageSize = this.paginationInstance.itemsPerPage;

      this.service.query(this.filterModel).subscribe(data => {
        this.summaryWinLosses = data;
        this.createPagingTransform();
      });
    }

    this.createPagingTransform();
  }

  private createPagingTransform() {
    const paginateData = this.paginatePipe.transform(this.summaryWinLosses.UsernameWinLosses, this.paginationInstance);
    this.displaySummaryWinLosses = _.cloneDeep(paginateData);
    this.filterModel.isPageChanged = true;
  }

  private getLevelName(level: number) {
    const isSearchDownlines = this.filterModel.isDownline;
    const username = this.filterModel.username;
    let title = '- Super Level';
    const masterLevel = 3;
    const agentLevel = 2;
    const notAvailableLevel = -1;
    switch (level) {
      case masterLevel:
        title = ' - Master Level';
        break;
      case agentLevel:
        title = ' - Agent Level';
        break;
      case notAvailableLevel:
        title = isSearchDownlines ? ` - ${username}'s downlines` : ` - ${username}`;
        break;
      default:
        title = ' - Super Level';
        break;
    }

    return title;
  }

  private showModal() {
    const modalRef = this.modalService.open(VirtualRateGridComponent);
    const instance = modalRef.componentInstance as VirtualRateGridComponent;
    instance.title = this.virtualRateTitle;
    instance.data = this.virtualRateData;
  }
}
