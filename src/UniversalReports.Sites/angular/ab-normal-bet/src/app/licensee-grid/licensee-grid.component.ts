import { Component } from '@angular/core';
import * as _ from 'lodash';
import { LicenseeModel, Grid } from './../common/model';
import { PaginationInstance, PaginatePipe, PaginationService  as NgxPaginationService } from 'ngx-pagination';
import { PaginationService } from 'nap-components/pagination';
import { LicenseeGridService } from './licensee-grid.service';

@Component({
  selector: 'app-licensee-grid',
  templateUrl: './licensee-grid.component.html',
  styleUrls: ['./licensee-grid.component.scss'],
  providers: [
    LicenseeGridService
  ]
})

export class LicenseeGridComponent implements Grid {
  breadcrumbItems: string[];
  licenseeData: LicenseeModel[] = [];
  displayLicensee: LicenseeModel[];
  paginationInstance: PaginationInstance;
  private paginatePipe: PaginatePipe;

  constructor(
    private readonly licenseeGridService: LicenseeGridService,
    private paginationService: PaginationService,
    private ngxPaginationService: NgxPaginationService) {
    this.paginatePipe = new PaginatePipe(this.ngxPaginationService);
  }

  query() {
    this.licenseeGridService.query().subscribe(data => {
      this.licenseeData = data;
      const breadcrumb = this.licenseeGridService.title;
      this.breadcrumbItems = [breadcrumb];
      this.paginationInstance = this.paginationService.createPaginationInstance(this.licenseeData.length);
      this.onPageChange();
    });
  }

  exportExcel() {
    this.licenseeGridService.exportExcel();
  }

  get hasExcel(): boolean {
    return this.hasData;
  }

  get hasData(): boolean {
    return !_.isNil(this.licenseeData) && this.licenseeData.length > 0;
  }

  onPageChange() {
    this.createExchangePaging();
  }

  private createExchangePaging() {
    const paginateMember = this.paginatePipe.transform(this.licenseeData, this.paginationInstance);
    this.displayLicensee = _.cloneDeep(paginateMember);
  }
}
