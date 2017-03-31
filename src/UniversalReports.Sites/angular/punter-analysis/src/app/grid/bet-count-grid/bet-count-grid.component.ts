import { Component } from '@angular/core';
import * as moment from 'moment';
import { PeriodType } from '../../filter/filter.model';
import { Grid } from '../grid.model';
import { GridService } from '../grid.service';
import { BetCountData, BetCountItem } from './bet-count-grid.model';
import { BetCountGridService } from './bet-count-grid.service';

@Component({
    selector: 'nap-bet-count-grid',
    templateUrl: './bet-count-grid.component.html'
})
export class BetCountGridComponent implements Grid {
    private periodType: PeriodType;
    private data: BetCountData;

    constructor(
        private gridService: GridService,
        private service: BetCountGridService
    ) { }

    query() {
        this.periodType = this.gridService.filterModel.periodType;
        this.service.query().subscribe(data => this.data = data);
    }

    excel() {

    }

    get hasExcel(): boolean {
        return true;
    }

    get title(): string {
        return 'Main - Punter Analysis';
    }
}
