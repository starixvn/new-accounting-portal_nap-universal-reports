import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService, HttpOptions, DefaultHttpOptions } from 'nap-components/http';
import { Helper } from 'nap-components/helper';
import { Exchange, ExchangeModel } from './grid.model';
import { FilterModel } from '../filter/filter.model';

@Injectable()
export class GridService {
  constructor(
    private httpService: HttpService
  ) { }

  queryReport(model: FilterModel): Observable<ExchangeModel> {
    let exchangeModel: ExchangeModel;
    const url = 'api/exchange/report';
    return this.httpService.post<ExchangeModel>(url, model).map(result => exchangeModel = result);
  }

  exportExcel(model: FilterModel) {
    const url = 'api/exchange/excel';
    const fromDate =  model.fromDate.replace(',', '').replace(/ /g, '_');
    const toDate = model.toDate.replace(',', '').replace(/ /g, '_');
    this.httpService.download(url, model).subscribe(response => {
        const fileName = `Exchange_WinLoss_report_From_${fromDate}_To_${toDate}.xlsx`;
        Helper.saveExcel(response, fileName);
    });
  }
}
