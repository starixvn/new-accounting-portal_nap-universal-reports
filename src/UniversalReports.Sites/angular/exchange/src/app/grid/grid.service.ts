import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import * as moment from 'moment';
import { HttpService, HttpOptions, DefaultHttpOptions } from 'nap-components/http';
import { Helper } from 'nap-components/helper';
import { Exchange } from './grid.model';
import { FilterModel } from '../filter/filter.model';

@Injectable()
export class GridService {
  constructor(
    private httpService: HttpService
  ) { }

  queryReport(model: FilterModel): Observable<Exchange[]> {
    let exchange: Exchange[] = [];
    const url = 'api/exchange/report';
    return this.httpService.post<Exchange[]>(url, model).map(result => exchange = result);
  }
}
