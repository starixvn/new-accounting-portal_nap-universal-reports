import { Component } from '@angular/core';
import * as moment from 'moment';
import { PeriodType } from '../../filter/filter.model'
import { BetCountItem } from './bet-count-grid.model'

@Component({
    selector: 'nap-bet-count-grid',
    templateUrl: './bet-count-grid.component.html',
    styleUrls: [
        './bet-count-grid.component.scss',
        '../grid.scss'
    ]
})
export class BetCountGridComponent {
    private periodType: PeriodType;
    private betCountItems: BetCountItem[];
    private rowCount: number;
    constructor() {
        this.periodType = PeriodType.Weekly;
        this.betCountItems = [];
        this.rowCount = 12;

        var startDate = moment("2015-11-25");;
        for (var i = 0; i < this.rowCount; i++) {
            var date = startDate.add(17, 'days').toDate();
            let betCountItem: BetCountItem = {
                Date: date,
                WinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                BetCount: 1321310 + i,
                WinCount: 32321,
                DrawCount: 67657
            };
            this.betCountItems.push(betCountItem);
        }
    }
}