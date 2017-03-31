import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DateHelper } from 'nap-components/src/date';
import { HttpService } from '../../components/http.service';
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
        return this.httpService.post<any>(url, {
            periodType: filterModel.periodType,
            fromDate: DateHelper.convertDateStructToString(filterModel.fromDate),
            toDate: DateHelper.convertDateStructToString(filterModel.toDate),
            listCombinationId: filterModel.productBetTypes.join(','),
            custId: this.model.custId,
            sportId: this.model.sportId
        });
    }
}
