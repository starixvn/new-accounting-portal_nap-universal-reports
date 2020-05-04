import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { Helper } from 'nap-components/helper';
import { Observable } from 'rxjs';
import { QueryModel } from '../common/model';
import * as moment from 'moment';
import { QueryModelService } from './../common/query-model.service';
import { GridFilterService } from './../common/grid-filter.service';
import { ExcelQueryModel, LicenseeModel } from './../common/model';
import { DateHelper } from 'nap-components/date';

@Injectable()
export class LicenseeGridService {
  private url = 'api/ab-normal-bet/report/';

  constructor(
    private httpService: HttpService,
    private queryModelService: QueryModelService,
    private gridFilterService: GridFilterService
  ) { }

  query(): Observable<LicenseeModel[]> {
    const url = this.url + 'licensee';
    const queryModel = this.createQueryModel();
    return this.httpService.post<LicenseeModel[]>(url, queryModel);
  }

  exportExcel() {
    const url = this.url + 'licensee-excel';
    const excelQueryModel = this.createExcelQueryModel();
    const fromDate = moment(excelQueryModel.fromDate).format('YYYY_MM_DD');
    const toDate = moment(excelQueryModel.toDate).format('YYYY_MM_DD');
    this.httpService.download(url, excelQueryModel).subscribe(response => {
      const fileName = `Abnormal_Bet_Void_Report_From_${fromDate}_To_${toDate}.xlsx`;
      Helper.downloadFile(response, fileName);
    });
  }

  get title(): string {
    const filterModel = this.gridFilterService.filterModel;
    return `Abnormal Bet From From ${filterModel.fromDate} To ${filterModel.toDate}`;
  }

  private createQueryModel(): QueryModel {
    const filterModel = this.gridFilterService.filterModel;
    return this.queryModelService.createQueryModel(filterModel);
  }

  private createExcelQueryModel(): ExcelQueryModel {
    const filterModel = this.gridFilterService.filterModel;
    const title = `Abnormal Bet From ${filterModel.fromDate} To ${filterModel.toDate}`;
    return this.queryModelService.createExcelQueryModel(title, filterModel);
  }
}
