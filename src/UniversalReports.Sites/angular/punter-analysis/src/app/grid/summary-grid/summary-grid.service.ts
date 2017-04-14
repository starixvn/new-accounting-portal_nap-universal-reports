import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { FilterModel, FilterModelWrapper } from '../../filter/filter.model';
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
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        const queryModel = this.createQueryModel();
        queryModel.title = `Punter Analysis ${filterModelWrapper.dateFromToTitle}`;
        const filterLines = [
            `Depth: ${filterModelWrapper.depthTitle} - Account name: ${filterModelWrapper.userNameTitle}`,
            `Top rows: ${filterModel.topRow} - Order by: ${filterModelWrapper.orderByTitle}, ${filterModelWrapper.sortByTitle}`,
            `Sport Type: ${filterModelWrapper.selectedSportTypes}`
        ];
        queryModel.filter = filterLines.join('\n');
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Top_Punter_Summary_${filterModelWrapper.searchByFileName}_${filterModelWrapper.dateFromToFileName}.xlsx`;
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
            depth: filterModel.depth,
            userName: filterModel.userName,
            listCombinationId: filterModelWrapper.listCombinationId
        };
    }
}
