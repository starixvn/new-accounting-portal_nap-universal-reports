import { Component } from '@angular/core';
import { Exchange, ExchangeModel, Grid, GridType, QueryModel } from '../grid.model';
import { Observable } from 'rxjs';
import { LicenseeService } from './licensee.service';
import { GridService } from '../grid.service';
import { PaginatePipe, PaginationInstance, PaginationService as NgxPaginationService } from 'ngx-pagination';
import { PaginationService } from 'nap-components/pagination';
import * as _ from 'lodash';
import { BreadcrumbService } from '../../common/breadcrumb.service';

@Component({
  selector: 'app-licensee',
  templateUrl: './licensee.component.html',
  styleUrls: ['./licensee.component.scss'],
  providers: [
    BreadcrumbService
  ]
})
export class LicenseeComponent implements Grid {
  exchangeModel: ExchangeModel;
  displayExchange: Exchange[];
  paginationInstance: PaginationInstance;
  breadcrumbItems: string;
  originalEventType: string;
  private paginatePipe: PaginatePipe;

  constructor(
    private readonly licenseeService: LicenseeService,
    private readonly gridService: GridService,
    private paginationService: PaginationService,
    private ngxPaginationService: NgxPaginationService,
    private breadcrumbService: BreadcrumbService
  ) {
    this.paginatePipe = new PaginatePipe(this.ngxPaginationService);
    this.breadcrumbItems = this.breadcrumbService.createBreadcrumb(this.gridService.filterModel);
    this.originalEventType = this.gridService.filterModel.eventType;
   }

  title: string = 'Main';

  query(): Observable<ExchangeModel> {
    return new Observable(observer => {
      this.licenseeService.query().subscribe(data => {
          this.exchangeModel = data;
          this.paginationInstance = this.paginationService.createPaginationInstance(this.exchangeModel.Entities.length, 'licensee-pagination');
          this.onPageChange();
          observer.complete();
      });
    });
  }

  exportExcel(): void {
    this.licenseeService.exportExcel();
  }

  showSports(licensee: string): void {
    this.gridService.sportTitle = licensee;
    const queryModel: QueryModel = {
      licenseeName: licensee,
      eventType: this.originalEventType,
      drillLevel: 1
    }
    this.gridService.generate(GridType.Sport, queryModel);
  }

  onPageChange() {
    this.createExchangePaging();
  }

  private createExchangePaging() {
    const paginateExchange = this.paginatePipe.transform(this.exchangeModel.Entities, this.paginationInstance);
    this.displayExchange = _.cloneDeep(paginateExchange);
  }
}
