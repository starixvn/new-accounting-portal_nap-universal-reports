import { Injectable } from '@angular/core';
import { ReasonModel, BetTypeModel, SportModel, SiteModel, FilterItemModel } from './filter.model';
import { Observable } from 'rxjs';
import { HttpService } from 'nap-components/http';

@Injectable()
export class FilterService {
  /**
   *
   */
  private readonly url = 'api/ab-normal-bet/filter/';

  constructor(private readonly httpService: HttpService) { }

  getReason(): Observable<FilterItemModel[]> {
    const url = this.url + 'reason';
    return this.httpService.post<FilterItemModel[]>(url);
  }

  getBetType(sportId: string): Observable<FilterItemModel[]> {
    const url = this.url + 'bet-type';
    return this.httpService.post<FilterItemModel[]>(url, { sportId: sportId });
  }

  getSport(): Observable<FilterItemModel[]> {
    const url = this.url + 'sport';
    return this.httpService.post<FilterItemModel[]>(url);
  }

  getSite(): Observable<FilterItemModel[]> {
    const url = this.url + 'site';
    return this.httpService.post<FilterItemModel[]>(url);
  }
  getCurrency(): Observable<FilterItemModel[]> {
    const url = this.url + 'currency';
    return this.httpService.post<FilterItemModel[]>(url);
  }
  queryLeagueSuggestion(sportId: string, searchText: string, searchExactly: boolean): Observable<FilterItemModel[]> {
    const url = `${this.url}/league`;
    return this.httpService.post<FilterItemModel[]>(url, {
      sportId: sportId,
      searchText: searchText,
      searchExactly: searchExactly
    });
}
}
