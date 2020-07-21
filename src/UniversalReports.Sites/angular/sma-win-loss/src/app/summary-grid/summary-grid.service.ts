import { QueryModel, WinLossModel } from './../common/model';
import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { FilterModel } from '../filter/filter.model';
import { Observable } from 'rxjs';
import { QueryModelService } from '../common/queryModel.service';

@Injectable()
export class SummaryGridService {
  private readonly url = 'api/sma-win-loss/summary';

  constructor(
    private readonly httpService: HttpService,
    private readonly queryModelService: QueryModelService
  ) { }

  query(
    filterModel: FilterModel): Observable<WinLossModel> {
    const queryModel = this.createQueryModel(filterModel);
    return this.httpService.post<WinLossModel>(this.url, queryModel);
  }

  private createQueryModel(filterModel: FilterModel): QueryModel {
    return this.queryModelService.createQueryModel(filterModel);
  }
}
