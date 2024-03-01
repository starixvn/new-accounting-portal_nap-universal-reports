import { Injectable } from '@angular/core';
import { SelectItem } from 'nap-components/dropdown-select';
import { HttpService } from 'nap-components/http';

import { LeagueModel } from './filter.model';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';


@Injectable({
  providedIn: 'root'
})
export class FilterService {
  private readonly url = 'api/result-analysis';

  constructor(private readonly httpService: HttpService) { }

  getSportSelectItems(): SelectItem[] {
    return [
        { text: 'Soccer', value: '1' },
        { text: 'Basketball', value: '2' }
    ];
   }

   queryLeagueSuggestion(sportId: string, searchText: string): Observable<LeagueModel[]> {
    const url = `${this.url}/leagues`;
    return this.httpService.post<LeagueModel[]>(url, {
      sportId,
      searchText
    });
  }
}
