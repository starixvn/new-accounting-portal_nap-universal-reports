import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { SearchBy, FilterModel, FilterModelWrapper, isLeagueModel, isUserModel } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { BetCountGridModel } from '../bet-count-grid/bet-count-grid.model';
import { AssociatedAccountGridModel } from '../associated-account-grid/associated-account-grid.model';
import { SportTypeGridModel } from '../sport-type-grid/sport-type-grid.model';
import { SummaryData } from './summary-grid.model';

@Injectable()
export class SummaryGridService {
    private url = 'api/punter-analysis/summary';

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    createBetCountGridModel(custId: number, custName: string): BetCountGridModel {
        return {
            custId: custId,
            custName: custName
        };
    }

    createSportTypeGridModel(custId: number, custName: string): SportTypeGridModel {
        return {
            custId: custId,
            custName: custName
        };
    }

    createAssociatedAccountGridModel(custId: number, custName: string): AssociatedAccountGridModel {
        return {
            custId: custId,
            custName: custName
        };
    }

    query(): Observable<SummaryData> {
        const queryModel = this.createQueryModel();
        return this.httpService.post<SummaryData>(this.url, queryModel);
    }

    exportExcel() {
        const url = `${this.url}/excel`;
        const filterModel = this.gridService.filterModel;
        const wrapper = new FilterModelWrapper(filterModel);
        const queryModel = this.createQueryModel();
        queryModel.title = `Punter Analysis ${wrapper.dateFromToTitle}`;
        const filterLines = [];
        if (filterModel.searchBy === SearchBy.User) {
            filterLines.push(`Depth: ${wrapper.depthTitle} - Account name: ${wrapper.userNameTitle}`);
        } else if (filterModel.searchBy === SearchBy.League) {
            filterLines.push('User Name: All');
        }
        filterLines.push(`Top rows: ${filterModel.topRow} - Order by: ${wrapper.orderByTitle}, ${wrapper.sortByTitle}`);
        filterLines.push(`Sport Type: ${wrapper.selectedSportTypes}`);
        if (filterModel.searchBy === SearchBy.League) {
            filterLines.push(`League: ${wrapper.leagueTitle}`);
        }
        queryModel.filter = filterLines.join('\n');
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Top_Punter_Summary_${wrapper.searchByFileName}_${wrapper.dateFromToFileName}.xlsx`;
            Helper.saveExcel(response, fileName);
        });
    }

    private createQueryModel(): any {
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        return {
            topRow: filterModel.topRow,
            orderBy: filterModel.orderBy,
            sortBy: filterModel.sortBy,
            periodType: filterModel.periodType,
            fromDate: filterModelWrapper.fromDateQueryString,
            toDate: filterModelWrapper.toDateQueryString,
            depth: isUserModel(filterModel) ? filterModel.depth.role : 0,
            userName: isUserModel(filterModel) ? filterModel.userName : '',
            listCombinationId: filterModelWrapper.listCombinationId,
            leagueId: isLeagueModel(filterModel) ? filterModel.leagueId : 0
        };
    }
}
