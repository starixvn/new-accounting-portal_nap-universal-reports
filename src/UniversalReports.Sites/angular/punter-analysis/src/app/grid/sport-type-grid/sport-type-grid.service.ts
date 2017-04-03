import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../../components/http.service';
import { FilterModelWrapper } from '../../filter/filter.model';
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
        const wrapper = new FilterModelWrapper(filterModel);
        return this.httpService.post<any>(url, {
            periodType: filterModel.periodType,
            fromDate: wrapper.fromDateQueryString,
            toDate: wrapper.toDateQueryString,
            listCombinationId: wrapper.listCombinationId,
            custId: this.model.custId
        });
    }
}
