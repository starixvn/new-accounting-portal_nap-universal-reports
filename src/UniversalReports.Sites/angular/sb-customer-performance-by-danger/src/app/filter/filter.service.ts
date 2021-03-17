import { TreeviewItem } from 'ngx-treeview';
import { LeagueGroup, Site, Sport } from './filter.model';
import { Injectable } from "@angular/core";
import { HttpService } from "nap-components/http";
import { Observable } from 'rxjs/Observable';
import { SelectItem } from 'nap-components/dropdown-select';

@Injectable()
export class FilterService {
  constructor(
    private httpService: HttpService
  ) { }

  getSite(): Observable<Site[]> {
    const url = 'api/sb-customer-performance-by-danger/filter/division';
    return this.httpService.post<Site[]>(url);
  }

  getLeagueGroup(sportBettype: string): Observable<LeagueGroup[]> {
    const url = 'api/sb-customer-performance-by-danger/filter/league-group';
    return this.httpService.post<LeagueGroup[]>(url, {
      sportBettype: sportBettype
    });
  }

  getSport(): Observable<Sport[]> {
    const url = 'api/sb-customer-performance-by-danger/filter/sport';
    return this.httpService.post<Sport[]>(url);
  }

  queryLeagueSuggestion(sportBettype: string, searchText: string): Observable<string[]> {
    const url = 'api/sb-customer-performance-by-danger/filter/league-suggestion';
    return this.httpService.post<string[]>(url, {
      sportBettype: sportBettype,
      searchText: searchText
    });
  }

  getStatusOptions(): SelectItem[] {
    return [{
      text: 'All',
      value: 'All'
    }, {
      text: 'Live',
      value: 'Live'
    }, {
      text: 'Non-Live',
      value: 'Non-Live'
    }];
  }

  getDangerLevel(): TreeviewItem[] {
    const treeItems: TreeviewItem[] = [];
    var nonItem = new TreeviewItem({ text: 'None', value: '0' });

    treeItems.push(nonItem);

    for (let i = 1; i < 51; i++) {
      var item = new TreeviewItem({ text: i.toString(), value: i.toString() });
      treeItems.push(item)
    }

    return treeItems;
  }
}
