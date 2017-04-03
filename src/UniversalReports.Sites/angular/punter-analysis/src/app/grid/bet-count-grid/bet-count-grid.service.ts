import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../../components/http.service';
import { FilterModelWrapper } from '../../filter/filter.model';
import { Helper } from '../../components/helper';
import { GridService } from '../grid.service';
import { BetCountGridModel, BetCountData } from './bet-count-grid.model';

@Injectable()
export class BetCountGridService {
    model: BetCountGridModel;
    private url = 'UniversalReports/api/punter-analysis/bet-count';

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
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        const queryModel = this.createQueryModel();
        queryModel.title = `Punter Analysis - ${this.model.custName} by bet count ${filterModelWrapper.dateFromToTitle}`;
        queryModel.filter = `Sport Type: ${filterModelWrapper.selectedSportTypes}`;
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `Top_Punter_Summary_Bet_Count_${filterModelWrapper.searchByFileName}_${filterModelWrapper.dateFromToFileName}.xlsx`;
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
            custId: this.model.custId,
            sportId: this.model.sportId,
            betTypeId: this.model.betTypeId,
            liveStatusId: this.model.liveStatusId
        };
    }
}
