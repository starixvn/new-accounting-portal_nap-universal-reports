import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import * as _ from 'lodash';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { SearchBy, FilterModelWrapper } from '../../filter/filter.model.main';
import { GridService } from '../grid.service';
import { SportTypeGridModel } from './sport-type-grid.model';
import { BetCountGridModel } from '../bet-count-grid/bet-count-grid.model';
import { BetTypeGridModel } from '../bet-type-grid/bet-type-grid.model';

@Injectable()
export class SportTypeGridService {
    private url = 'api/punter-analysis/sport-type';
    model: SportTypeGridModel;

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    createBetTypeGridModel(sportId: number, sportName: string): BetTypeGridModel {
        return _.extend(this.model, {
            sportId: sportId,
            sportName: sportName
        });
    }

    createBetCountGridModel(sportId: number): BetCountGridModel {
        return {
            custId: this.model.custId,
            custName: this.model.custName,
            sportId: sportId
        };
    }

    query(): Observable<any> {
        const queryModel = this.createQueryModel();
        return this.httpService.post<any>(this.url, queryModel);
    }

    exportExcel() {
        const url = `${this.url}/excel`;
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        const queryModel = this.createQueryModel();
        queryModel.title = `Punter Analysis ${filterModelWrapper.dateFromToTitle}`;
        const filterLines = [
            `User Name: ${this.model.custName}`,
            `Order by: ${filterModelWrapper.userLeagueWrapper.orderByTitle}, ${filterModelWrapper.userLeagueWrapper.sortByTitle}`,
            `Sport Type: ${filterModelWrapper.selectedSportTypes}`
        ];
        if (filterModel.searchBy === SearchBy.League) {
            filterLines.push(`League: ${filterModelWrapper.leagueTitle}`);
        }
        queryModel.filter = filterLines.join('\n');
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Top_Punter_Sporttype_${filterModelWrapper.searchByFileName}_${filterModelWrapper.dateFromToFileName}.xlsx`;
            Helper.saveExcel(response, fileName);
        });
    }

    private createQueryModel(): any {
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        return {
            periodType: filterModelWrapper.userLeagueModel.periodType,
            fromDate: filterModelWrapper.fromDateQueryString,
            toDate: filterModelWrapper.toDateQueryString,
            listCombinationId: filterModelWrapper.userLeagueWrapper.listCombinationId,
            leagueId: filterModelWrapper.leagueId,
            custId: this.model.custId
        };
    }
}
