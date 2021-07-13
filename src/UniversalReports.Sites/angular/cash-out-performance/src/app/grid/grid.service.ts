import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { HttpService } from 'nap-components/http';
import { Observable } from 'rxjs';
import { ExcelQueryModel, TicketViewModel } from '../common/model';
import { FilterModel } from '../filter/filter.model';
import { Helper } from 'nap-components/helper';
import * as _ from 'lodash';

@Injectable({
  providedIn: 'root'
})
export class GridService {
  private readonly url = 'api/cash-out-performance/';

  constructor(private httpService: HttpService) { }

  getTickets(fiterModel: FilterModel): Observable<TicketViewModel> {
    const url = this.url + 'tickets';
    return this.httpService.post<TicketViewModel>(url, fiterModel);
  }

  exportExcel(filterModel: FilterModel): void {
    const url = this.url + 'excel';
    const excelQueryModel = this.createExcelQueryModel(filterModel);

    const fromDate = moment(excelQueryModel.startDate).format('YYYY_MM_DD');
    const toDate = moment(excelQueryModel.endDate).format('YYYY_MM_DD');
    this.httpService.download(url, excelQueryModel).subscribe(response => {
      const fileName = `Cash_Out_Performance_Report_From_${fromDate}_To_${toDate}.xlsx`;
      Helper.downloadFile(response, fileName);
    });
  }

  private createExcelQueryModel(filterModel: FilterModel): ExcelQueryModel {
    const title = `Cash Out Performance Report From ${filterModel.startDate} To ${filterModel.endDate}`;
    const excelQueryModel: ExcelQueryModel = _.extend({}, { title }, filterModel);
    excelQueryModel.pageIndex = 0;
    excelQueryModel.pageSize = 0;
    return excelQueryModel;
  }
}
