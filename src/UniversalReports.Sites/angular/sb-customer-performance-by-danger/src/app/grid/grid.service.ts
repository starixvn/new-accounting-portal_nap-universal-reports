import { SummaryEntity } from './grid.model';
import { Injectable } from "@angular/core";
import { HttpService } from "nap-components/http";
import { Observable } from 'rxjs/Observable';
import { FilterModel } from '../filter/filter.model';

@Injectable()
export class GridService {
  constructor(
    private httpService: HttpService
  ) { }

  getData(fiterModel: FilterModel): Observable<SummaryEntity> {
    const url = 'api/sb-customer-performance-by-danger/report/data';
    return this.httpService.post<SummaryEntity>(url, fiterModel);
  }
}
