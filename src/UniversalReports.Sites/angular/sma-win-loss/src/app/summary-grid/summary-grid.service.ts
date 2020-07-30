import { QueryModel, WinLossModel, VirtualRateModel } from './../common/model';
import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { FilterModel } from '../filter/filter.model';
import { Observable } from 'rxjs';
import { QueryModelService } from '../common/queryModel.service';

@Injectable()
export class SummaryGridService {
  constructor(
    private readonly httpService: HttpService,
    private readonly queryModelService: QueryModelService
  ) { }

  query(filterModel: FilterModel): Observable<WinLossModel> {
    const url = 'api/sma-win-loss/summary';
    const queryModel = this.createQueryModel(filterModel);
    return this.httpService.post<WinLossModel>(url, queryModel);
  }

  private createQueryModel(filterModel: FilterModel): QueryModel {
    return this.queryModelService.createQueryModel(filterModel);
  }

  queryVirtualRate(custId: number): Observable<VirtualRateModel[]> {
    const url = 'api/sma-win-loss/virtual-rate';
    return this.httpService.post<VirtualRateModel[]>(url, { custId });
  }
}
