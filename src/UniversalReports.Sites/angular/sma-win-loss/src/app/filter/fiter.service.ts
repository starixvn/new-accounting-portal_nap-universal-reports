import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { Currency, LeagueGroup, Site, Sport } from './filter.model';
import { Observable } from 'rxjs';

@Injectable()
export class FilterService {

  private url = 'api/sma-win-loss/filter';
  constructor(
    private httpService: HttpService
  ) { }

  getCurrency(): Observable<Currency[]> {
    const url = `${this.url}/currency`;
    return this.httpService.post<Currency[]>(url);
  }

  getSite(): Observable<Site[]> {
    const url = `${this.url}/site`;
    return this.httpService.post<Site[]>(url);
  }

  getSport(): Observable<Sport[]> {
    const url = `${this.url}/sport`;
    return this.httpService.post<Sport[]>(url);
  }

  getLeagueGroup(sports: string, searchText: string, searchExactly: boolean): Observable<string[]> {
    const url = `${this.url}/league-group`;
    return this.httpService.post<string[]>(url, {
      sports,
      searchText,
      searchExactly
    });
  }
}
