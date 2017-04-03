import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpService } from '../../components/http.service';
import { FilterModel, FilterModelWrapper } from '../../filter/filter.model';
import { Helper } from '../../components/helper';
import { GridService } from '../grid.service';
import { BetCountGridModel } from '../bet-count-grid/bet-count-grid.model';
import { AssociatedAccountGridModel } from '../associated-account-grid/associated-account-grid.model';
import { SportTypeGridModel } from '../sport-type-grid/sport-type-grid.model';
import { SummaryData } from './summary-grid.model';

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

    excel() {
        let url = 'UniversalReports/api/punter-analysis/summary/excel';
        const model = this.gridService.filterModel;
        const wrapper = new FilterModelWrapper(model);
        const queryModel = this.createQueryModel();
        queryModel.title = `Punter Analysis ${wrapper.dateTitle}`;
        const filterLines = [
            `Depth: ${wrapper.depthTitle} - Account name: ${wrapper.userNameTitle}`,
            `Top rows: ${model.topRow} - Order by: ${wrapper.orderByTitle}, ${wrapper.sortByTitle}`,
            `Sport Type: ${wrapper.selectedSportTypes}`
        ];
        queryModel.filter = filterLines.join('\n');
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Top_Punter_Summary_${wrapper.searchByFileName}_${wrapper.dateFileName}.xlsx`;
            Helper.saveExcel(response, fileName);
        });
    }

    private createQueryModel(): any {
        const model = this.gridService.filterModel;
        const wrapper = new FilterModelWrapper(model);
        return {
            topRow: model.topRow,
            orderBy: model.orderBy,
            sortBy: model.sortBy,
            periodType: model.periodType,
            fromDate: wrapper.fromDateQueryString,
            toDate: wrapper.toDateQueryString,
            depth: model.depth,
            userName: model.userName,
            listCombinationId: wrapper.listCombinationId
        };
    }
}
