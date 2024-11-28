import { Injectable } from '@angular/core';
import * as _ from 'lodash';
import * as moment from 'moment';
import { Helper } from 'nap-components/helper';
import { HttpService } from 'nap-components/http';
import { Observable } from 'rxjs';
import { FilterModel } from '../../../app/filter/filter.model';
import { BetTypeDrillDownType, CommonConfig } from '../../../app/common/constants';
import { BetTypeDrillDownQueryModel, BetTypeLevelModel, ExcelQueryModel, TicketViewModel } from '../../../app/common/model';

@Injectable({
  providedIn: 'root'
})
export class DetailGameTimeGridService {

  constructor(private httpService: HttpService) { }

  getTickets(model: BetTypeDrillDownQueryModel): Observable<TicketViewModel<BetTypeLevelModel>> {
    return this.httpService.post<TicketViewModel<BetTypeLevelModel>>(`${CommonConfig.API}drill-down-bettype-level`, model);
  }

  exportExcel(filterModel: FilterModel, model: BetTypeDrillDownQueryModel): void {
    model.title = `Cash Out Performance Report From ${filterModel.startDate} To ${filterModel.endDate}`;
    model.breadCrumb = filterModel.breadCrumb;
    model.type = BetTypeDrillDownType.DETAIL_GAME_TIME;

    const fromDate = moment(filterModel.startDate).format('YYYY_MM_DD');
    const toDate = moment(filterModel.endDate).format('YYYY_MM_DD');
    this.httpService.download(`${CommonConfig.API}excel-drill-down-bettype`, model).subscribe(response => {
      const fileName = `Cash_Out_Performance_Report_From_${fromDate}_To_${toDate}.xlsx`;
      Helper.downloadFile(response, fileName);
    });
  }
}
