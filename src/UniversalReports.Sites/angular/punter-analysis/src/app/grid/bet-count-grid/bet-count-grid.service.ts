import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { SearchBy, FilterModelWrapper, isLeagueModel } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { BetCountGridModel, BetCountData } from './bet-count-grid.model';

@Injectable()
export class BetCountGridService {
    model: BetCountGridModel;
    private url = 'api/punter-analysis/bet-count';

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<BetCountData> {
        const queryModel = this.createQueryModel();
        return this.httpService.post<BetCountData>(this.url, queryModel);
    }

    exportExcel() {
        const url = `${this.url}/excel`;
        const filterModel = this.gridService.filterModel;
        const wrapper = new FilterModelWrapper(filterModel);
        const queryModel = this.createQueryModel();
        queryModel.title = `Punter Analysis - ${this.model.custName} by bet count ${wrapper.dateFromToTitle}`;
        const filterLines = [`Sport Type: ${wrapper.selectedSportTypes}`];
        if (filterModel.searchBy === SearchBy.League) {
            filterLines.push(`League: ${wrapper.leagueTitle}`);
        }
        queryModel.filter = filterLines.join('\n');
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Top_Punter_Summary_Bet_Count_${wrapper.searchByFileName}_${wrapper.dateFromToFileName}.xlsx`;
            Helper.saveExcel(response, fileName);
        });
    }

    private createQueryModel(): any {
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        return {
            periodType: filterModel.periodType,
            fromDate: filterModelWrapper.fromDateQueryString,
            toDate: filterModelWrapper.toDateQueryString,
            listCombinationId: filterModelWrapper.listCombinationId,
            leagueId: isLeagueModel(filterModel) ? filterModel.leagueId : 0,
            custId: this.model.custId,
            sportId: this.model.sportId,
            betTypeId: this.model.betTypeId,
            liveStatusId: this.model.liveStatusId
        };
    }
}
