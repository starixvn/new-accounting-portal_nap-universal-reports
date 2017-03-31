import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DateHelper } from 'nap-components/src/date';
import { HttpService } from '../../components/http.service';
import { GridService } from '../grid.service';
import { BetCountGridModel, BetCountData } from './bet-count-grid.model';

@Injectable()
export class BetCountGridService {
    model: BetCountGridModel;

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<BetCountData> {
        let url = 'UniversalReports/api/punter-analysis/bet-count';
        const filterModel = this.gridService.filterModel;
        return this.httpService.post<BetCountData>(url, {
            periodType: filterModel.periodType,
            fromDate: DateHelper.convertDateStructToString(filterModel.fromDate),
            toDate: DateHelper.convertDateStructToString(filterModel.toDate),
            listCombinationId: filterModel.productBetTypes.join(','),
            custId: this.model.custId,
            sportId: this.model.sportId,
            betTypeId: this.model.betTypeId,
            liveStatusId: this.model.liveStatusId
        });
    }
}
