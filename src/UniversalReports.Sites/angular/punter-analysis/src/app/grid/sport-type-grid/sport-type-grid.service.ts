import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DateHelper } from 'nap-components/src/date';
import { HttpService } from '../../components/http.service';
import { GridService } from '../grid.service';
import { SportTypeGridModel } from './sport-type-grid.model';
import { BetCountGridModel } from '../bet-count-grid/bet-count-grid.model';
import { BetTypeGridModel } from '../bet-type-grid/bet-type-grid.model';

@Injectable()
export class SportTypeGridService {
    model: SportTypeGridModel;

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    createBetTypeGridModel(sportId: number): BetTypeGridModel {
        return {
            custId: this.model.custId,
            sportId: sportId
        };
    }

    createBetCountGridModel(sportId: number): BetCountGridModel {
        return {
            custId: this.model.custId,
            sportId: sportId
        };
    }

    query(): Observable<any> {
        let url = 'UniversalReports/api/punter-analysis/sport-type';
        const filterModel = this.gridService.filterModel;
        return this.httpService.post<any>(url, {
            periodType: filterModel.periodType,
            fromDate: DateHelper.convertDateStructToString(filterModel.fromDate),
            toDate: DateHelper.convertDateStructToString(filterModel.toDate),
            listCombinationId: filterModel.productBetTypes.join(','),
            custId: this.model.custId
        });
    }
}
