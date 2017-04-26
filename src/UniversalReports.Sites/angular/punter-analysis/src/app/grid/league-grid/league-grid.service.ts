import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { DateHelper } from 'nap-components/src/date';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { SearchBy, FilterModelWrapper, isLeagueModel } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { LiveStatus } from '../grid.model';
import { LeagueGridModel, LeagueData } from './league-grid.model';

@Injectable()
export class LeagueGridService {
    private url = 'api/punter-analysis/league';
    model: LeagueGridModel;

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    getLiveStatusTitle(): string {
        switch (this.model.liveStatusId) {
            case LiveStatus.Live:
                return 'Live';
            case LiveStatus.NonLive:
                return 'Non-Live';
            default:
                return 'Non-Live & Live';
        }
    }

    query(): Observable<LeagueData> {
        const queryModel = this.createQueryModel();
        return this.httpService.post<LeagueData>(this.url, queryModel);
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
            `Sport Type: ${this.model.sportName}`,
            `Bet Type: ${this.model.betTypeName} - Status: ${this.getLiveStatusTitle()}`
        ];
        if (filterModel.searchBy === SearchBy.League) {
            filterLines.push(`League: ${filterModelWrapper.leagueTitle}`);
        }
        queryModel.filter = filterLines.join('\n');
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Top_Punter_League_${filterModelWrapper.searchByFileName}_${filterModelWrapper.dateFromToFileName}.xlsx`;
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
