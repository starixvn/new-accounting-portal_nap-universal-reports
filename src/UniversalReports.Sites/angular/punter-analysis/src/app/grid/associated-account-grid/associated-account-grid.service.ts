import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { DateHelper } from 'nap-components/src/date';
import { NumberFormat, NumberHelper } from 'nap-components/src/number';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { SearchBy, FilterModelWrapper } from '../../filter/filter.model.main';
import { GridService } from '../grid.service';
import { AssociatedAccountGridModel } from './associated-account-grid.model';

@Injectable()
export class AssociatedAccountGridService {
    private url = 'api/punter-analysis/associated-account';
    model: AssociatedAccountGridModel;

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<any> {
        const queryModel = this.createQueryModel();
        return this.httpService.post<any>(this.url, queryModel);
    }

    exportExcel() {
        const url = `${this.url}/excel`;
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        const queryModel = this.createQueryModel();
        queryModel.title = `Associated Account of Punter ${this.model.custName} ${filterModelWrapper.dateFromToTitle}`;
        const topRow = filterModelWrapper.userLeagueModel.topRow;
        const orderByTitle = filterModelWrapper.userLeagueWrapper.orderByTitle;
        const sortByTitle = filterModelWrapper.userLeagueWrapper.sortByTitle;
        const filterLines = [
            `User Name: ${this.model.custName}`,
            `Top rows: ${NumberHelper.format(topRow, NumberFormat.Integer)} - Order by: ${orderByTitle}, ${sortByTitle}`,
            `Sport Type: ${filterModelWrapper.selectedSportTypes}`
        ];
        if (filterModel.searchBy === SearchBy.League) {
            filterLines.push(`League: ${filterModelWrapper.leagueTitle}`);
        }
        queryModel.filter = filterLines.join('\n');
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Associated_Account_${filterModelWrapper.searchByFileName}_${filterModelWrapper.dateFromToFileName}.xlsx`;
            Helper.saveExcel(response, fileName);
        });
    }

    private createQueryModel(): any {
        return {
            custId: this.model.custId,
            userName: this.model.custName
        };
    }
}
