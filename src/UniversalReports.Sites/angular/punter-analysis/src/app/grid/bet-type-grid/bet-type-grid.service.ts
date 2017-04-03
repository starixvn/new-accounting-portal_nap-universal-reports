import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../../components/http.service';
import { FilterModelWrapper } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { BetTypeGridModel } from './bet-type-grid.model';

@Injectable()
export class BetTypeGridService {
    model: BetTypeGridModel;

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<any> {
        let url = 'UniversalReports/api/punter-analysis/bet-type';
        const filterModel = this.gridService.filterModel;
        const wrapper = new FilterModelWrapper(filterModel);
        return this.httpService.post<any>(url, {
            periodType: filterModel.periodType,
            fromDate: wrapper.fromDateQueryString,
            toDate: wrapper.toDateQueryString,
            listCombinationId: wrapper.listCombinationId,
            custId: this.model.custId,
            sportId: this.model.sportId
        });
    }
}
