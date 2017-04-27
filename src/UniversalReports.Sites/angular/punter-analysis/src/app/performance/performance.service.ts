import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { FilterModel, FilterModelWrapper } from '../filter/filter.model';
import { BetCount } from './performance.model';

@Injectable()
export class PerformanceService {
    private url = 'api/punter-analysis/performance';

    constructor(
        private httpService: HttpService
    ) { }

    query(filterModel: FilterModel): Observable<BetCount[]> {
        const url = `${this.url}/summary`;
        const queryModel = this.createQueryModel(filterModel);
        return this.httpService.post<BetCount[]>(url, queryModel);
    }

    private createQueryModel(filterModel: FilterModel): any {
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        return {
            fromDate: filterModelWrapper.fromDateQueryString,
            toDate: filterModelWrapper.toDateQueryString,
            depth: filterModel.performance.depth.role,
            userName: filterModel.performance.userName
        };
    }
}
