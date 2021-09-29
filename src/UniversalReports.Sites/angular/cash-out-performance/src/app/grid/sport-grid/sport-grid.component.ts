import { Component } from '@angular/core';
import { PaginationInstance, PaginatePipe, PaginationService as NgxPaginationService } from 'ngx-pagination';
import { PaginationService } from 'nap-components/pagination';
import { Observable } from 'rxjs';
import { SportLevelModel, TicketViewModel } from '../../../app/common/model';
import { Grid, GridType } from '../grid.model';
import { GridService } from '../grid.service';
import { SportGridService } from './sport-grid.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-sport-grid',
  templateUrl: './sport-grid.component.html',
  styleUrls: ['./sport-grid.component.scss']
})
export class SportGridComponent implements Grid {

  dataViewModel: TicketViewModel<SportLevelModel>;
  paginationInstance: PaginationInstance;
  originalPageSize = 100;

  private paginatePipe: PaginatePipe;

  constructor(
    private readonly service: SportGridService,
    private readonly gridService: GridService,
    private readonly paginationService: PaginationService,
    private readonly ngxPaginationService: NgxPaginationService) {
    this.paginatePipe = new PaginatePipe(this.ngxPaginationService);
  }

  get title(): string {
    return 'MAIN';
  }

  query() {
    return new Observable(observer => {
      this.service.getTickets(this.gridService.filterModel).subscribe(data => {
        this.dataViewModel = data;
        this.paginationInstance = this.paginationService.createPaginationInstance(this.dataViewModel.Total);
        this.onPageChange();
      });
      observer.complete();
    });
  }

  exportExcel(): void {
    this.service.exportExcel(this.gridService.filterModel);
  }

  onPageChange(): void {
    this.createPaging();
  }

  private createPaging(): void {
    if (this.gridService.filterModel.isPageChanged) {
      this.paginationInstance.currentPage =
        this.paginationInstance.itemsPerPage !== this.originalPageSize ? 1 : this.paginationInstance.currentPage;
      this.gridService.filterModel.pageIndex = this.paginationInstance.currentPage;
      this.gridService.filterModel.pageSize = this.paginationInstance.itemsPerPage;

      this.service.getTickets(this.gridService.filterModel).subscribe(data => {
        this.dataViewModel = data;
        this.createPagingTransform();
      });
    }

    this.createPagingTransform();
  }

  private createPagingTransform(): void {
    const paginateData = this.paginatePipe.transform(this.dataViewModel.TicketList, this.paginationInstance);
    this.dataViewModel.TicketList = _.cloneDeep(paginateData);
    this.gridService.filterModel.isPageChanged = true;
    this.originalPageSize = this.paginationInstance.itemsPerPage;
  }

  get hasData(): boolean {
    return !_.isNil(this.dataViewModel) && this.dataViewModel.Total > 0;
  }

  showEventStatusLevel(sportType: number, sportName: string): void{
    this.gridService.eventTitle = sportName;
    this.gridService.filterModel.sportType = sportType;
    this.gridService.generate(GridType.Event);
  }
}
