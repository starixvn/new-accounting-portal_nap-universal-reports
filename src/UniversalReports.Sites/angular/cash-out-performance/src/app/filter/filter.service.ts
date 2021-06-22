import { Injectable } from '@angular/core';
import { SelectItem } from 'nap-components/dropdown-select';
import { HttpService } from 'nap-components/http';
import { Observable } from 'rxjs';
import { FilterItemModel, LeagueModel, TimePeriod } from './filter.model';

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

  getTimeSelectItems(): SelectItem[] {
    return [
        { text: 'Yesterday', value: TimePeriod.Yesterday },
        { text: 'Current Week', value: TimePeriod.CurrentWeek },
        { text: 'Last Week', value: TimePeriod.LastWeek },
        { text: 'Current Month', value: TimePeriod.CurrentMonth },
        { text: 'Last Month', value: TimePeriod.LastMonth },
        { text: 'Since Last Month', value: TimePeriod.SinceLastMonth },
        { text: 'Specific Date', value: TimePeriod.SpecificDate },
        { text: 'Last 3 Months', value: TimePeriod.LastThreeMonths }
    ];
   }

   queryLeagueSuggestion(sportId: string, searchText: string, searchExactly: boolean): Observable<LeagueModel[]> {
    const url = `${this.url}/leagues`;
    return this.httpService.post<LeagueModel[]>(url, {
      sportId,
      searchText,
      searchExactly
    });
  }
}
