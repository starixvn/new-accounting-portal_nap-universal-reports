import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/http';
import { Helper } from 'nap-components/helper';
import { AssociatedAccountGridModel, AssociatedAccountData } from './associated-account-grid.model';
import { FilterModelWrapper } from '../../filter/filter.model.main';
import { GridService } from '../grid.service';

@Injectable()
export class AssociatedAccountGridService {
    private url = 'api/punter-analysis/associated-account';
    model: AssociatedAccountGridModel;

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<AssociatedAccountData> {
        const queryModel = this.createQueryModel();
        return this.httpService.post<AssociatedAccountData>(this.url, queryModel);
    }

    private createQueryModel(): any {
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        const userLeagueModel = filterModelWrapper.userLeagueModel;
        return {
            custId: this.model.custId,
            userName: this.model.custName,
            leagueId: filterModelWrapper.leagueId,
            orderBy: userLeagueModel.orderBy,
            sortBy: userLeagueModel.sortBy,
            periodType: userLeagueModel.periodType,
            fromDate: filterModelWrapper.fromDateQueryString,
            toDate: filterModelWrapper.toDateQueryString,
            listCombinationId: filterModelWrapper.userLeagueWrapper.listCombinationId
        };
    }

    exportExcel() {
        const url = `${this.url}/excel`;
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        const queryModel = this.createQueryModel();
        queryModel.title = `Associated accounts of Punter ${this.model.custName} ${filterModelWrapper.dateFromToTitle}`;
        const filterLines = [];
        const orderByTitle = filterModelWrapper.userLeagueWrapper.orderByTitle;
        const sortByTitle = filterModelWrapper.userLeagueWrapper.sortByTitle;
        filterLines.push(`Order by: ${orderByTitle}, ${sortByTitle}`);
        filterLines.push(`Sport Type: ${filterModelWrapper.selectedSportTypes}`);
        queryModel.filter = filterLines.join('\n');
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Associated_Accounts_Of_Punter_${this.model.custName}_${filterModelWrapper.dateFromToFileName}.xlsx`;
            Helper.downloadFile(response, fileName);
        });
    }
}
