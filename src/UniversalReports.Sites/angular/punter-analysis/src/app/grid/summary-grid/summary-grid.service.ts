import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs';
import { DateHelper } from 'nap-components/src/date';
import { HttpService } from '../../components/http.service';
import { FilterModel } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { SummaryData } from './summary-grid.model';
import { BetCountGridModel } from '../bet-count-grid/bet-count-grid.model';
import { AssociatedAccountGridModel } from '../associated-account-grid/associated-account-grid.model';
import { SportTypeGridModel } from '../sport-type-grid/sport-type-grid.model';

@Injectable()
export class SummaryGridService {
    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    createBetCountGridModel(custId: number): BetCountGridModel {
        return {
            custId: custId
        };
    }

    createSportTypeGridModel(custId: number): SportTypeGridModel {
        return {
            custId: custId
        };
    }

    createAssociatedAccountGridModel(custId: number, userName: string): AssociatedAccountGridModel {
        return {
            custId: custId,
            userName: userName
        };
    }

    query(): Observable<SummaryData> {
        let url = 'UniversalReports/api/punter-analysis/summary';
        const queryModel = this.createQueryModel();
        return this.httpService.post<SummaryData>(url, queryModel);
    }

    excel(): Observable<Response> {
        let url = 'UniversalReports/api/punter-analysis/summary/excel';
        const queryModel = this.createQueryModel();
        return this.httpService.download(url, queryModel);
    }

    private createQueryModel(): any {
        const model = this.gridService.filterModel;
        return {
            topRow: model.topRow,
            orderBy: model.orderBy,
            sortBy: model.sortBy,
            periodType: model.periodType,
            fromDate: DateHelper.convertDateStructToString(model.fromDate),
            toDate: DateHelper.convertDateStructToString(model.toDate),
            depth: model.depth,
            userName: model.userName,
            listCombinationId: model.productBetTypes.join(',')
        };
    }
}
