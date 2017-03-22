import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DateHelper } from 'nap-components/src/date';
import { HttpService } from './components/http.service';
import { FilterModel } from './filter/filter.model';

@Injectable()
export class AppService {
    constructor(
        private httpService: HttpService
    ) { }

    querySummary(filterModel: FilterModel): Observable<any> {
        let url = 'UniversalReports/api/punter-analysis/summary';
        return this.httpService.post<any>(url, {
            topRow: filterModel.topRow,
            orderBy: filterModel.orderBy,
            sortBy: filterModel.sortBy,
            periodType: filterModel.periodType,
            fromDate: DateHelper.convertDateStructToString(filterModel.fromDate),
            toDate: DateHelper.convertDateStructToString(filterModel.toDate),
            depth: filterModel.depth,
            userName: filterModel.userName,
            listCombinationId: filterModel.productBetTypes.join(',')
        });
    }
}
