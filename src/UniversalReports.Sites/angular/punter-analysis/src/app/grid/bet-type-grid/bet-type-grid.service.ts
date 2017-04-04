import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import * as _ from 'lodash';
import { HttpService } from '../../components/http.service';
import { Helper } from '../../components/helper';
import { FilterModelWrapper } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { LiveStatus } from '../grid.model';
import { BetCountGridModel } from '../bet-count-grid/bet-count-grid.model';
import { LeagueGridModel } from '../league-grid/league-grid.model';
import { BetTypeGridModel, BetTypeData } from './bet-type-grid.model';

@Injectable()
export class BetTypeGridService {
    private url = 'api/punter-analysis/bet-type';
    model: BetTypeGridModel;

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    createBetCountGridService(betTypeId: number, liveStatusId: LiveStatus): BetCountGridModel {
        return {
            custId: this.model.custId,
            custName: this.model.custName,
            sportId: this.model.sportId,
            betTypeId: betTypeId,
            liveStatusId: liveStatusId
        };
    }

    createLeagueGridService(betTypeId: number, betTypeName: string, liveStatusId: LiveStatus): LeagueGridModel {
        return _.extend(this.model, {
            betTypeId: betTypeId,
            betTypeName: betTypeName,
            liveStatusId: liveStatusId
        });
    }

    query(): Observable<BetTypeData> {
        const queryModel = this.createQueryModel();
        return this.httpService.post<BetTypeData>(this.url, queryModel);
    }

    exportExcel() {
        const url = `${this.url}/excel`;
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        const queryModel = this.createQueryModel();
        queryModel.title = `Punter Analysis ${filterModelWrapper.dateFromToTitle}`;
        const filterLines = [
            `User Name: ${this.model.custName}`,
            `Order by: ${filterModelWrapper.orderByTitle}, ${filterModelWrapper.sortByTitle}`,
            `Sport Type: ${this.model.sportName}`
        ];
        queryModel.filter = filterLines.join('\n');
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Top_Punter_Bettype_${filterModelWrapper.searchByFileName}_${filterModelWrapper.dateFromToFileName}.xlsx`;
            Helper.saveExcel(response, fileName);
        });
    }

    private createQueryModel(): any {
        const filterModel = this.gridService.filterModel;
        const wrapper = new FilterModelWrapper(filterModel);
        return {
            periodType: filterModel.periodType,
            fromDate: wrapper.fromDateQueryString,
            toDate: wrapper.toDateQueryString,
            listCombinationId: wrapper.listCombinationId,
            custId: this.model.custId,
            sportId: this.model.sportId
        };
    }
}
