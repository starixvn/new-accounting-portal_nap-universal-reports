import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { Observable } from 'rxjs';
import { FilterItemModel } from './filter.model';

@Injectable({
  providedIn: 'root'
})
export class FilterService {
  private readonly url = 'api/cash-out-performance/';

  constructor(private readonly httpService: HttpService) { }

  getSports(): Observable<FilterItemModel[]> {
    const url = this.url + 'sports';
    return this.httpService.post<FilterItemModel[]>(url);
  }

  getLicensees(): Observable<FilterItemModel[]> {
    const url = this.url + 'licensees';
    return this.httpService.post<FilterItemModel[]>(url);
  }
}
