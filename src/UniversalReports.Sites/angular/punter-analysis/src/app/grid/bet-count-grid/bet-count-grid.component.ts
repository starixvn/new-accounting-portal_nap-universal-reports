import { Component } from '@angular/core';
import * as _ from 'lodash';
import { PeriodType, FilterModelWrapper } from '../../filter/filter.model';
import { Grid } from '../grid.model';
import { GridService } from '../grid.service';
import { BetCountData, BetCountItem } from './bet-count-grid.model';
import { BetCountGridService } from './bet-count-grid.service';

@Component({
    selector: 'nap-bet-count-grid',
    templateUrl: './bet-count-grid.component.html'
})
export class BetCountGridComponent implements Grid {
    periodType: PeriodType;
    data: BetCountData;

    constructor(
        private gridService: GridService,
        private service: BetCountGridService
    ) { }

    query() {
        const filterModelWrapper = new FilterModelWrapper(this.gridService.filterModel);
        this.periodType = filterModelWrapper.userLeagueModel.periodType;
        this.service.query().subscribe(data => this.data = data);
    }

    exportExcel() {
        this.service.exportExcel();
    }

    get hasData(): boolean {
        return !_.isNil(this.data) && this.data.Entities.length > 0;
    }

    get title(): string {
        const model = this.service.model;
        return `Punter ${model.custName} by bet count`;
    }
}
