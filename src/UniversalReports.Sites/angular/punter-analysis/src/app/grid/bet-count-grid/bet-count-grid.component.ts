import { Component } from '@angular/core';
import * as moment from 'moment';
import { PeriodType } from '../../filter/filter.model'
import { ViewModelItem, BetCountItem } from './bet-count-grid.model'

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
    private viewModelItem: ViewModelItem;

    constructor() {
        this.periodType = PeriodType.Weekly;
        this.viewModelItem = this.createFakeData();
    }

    private createFakeData(): ViewModelItem {

        let entities: BetCountItem[] = [];
        var startDate = moment("2015-11-25");;
        for (var i = 0; i < 12; i++) {
            var date = startDate.add(17, 'days').toDate();
            let betCountItem: BetCountItem = {
                Date: date,
                WinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                BetCount: 1321310 + i,
                WinCount: 32321,
                DrawCount: 67657
            };

            entities.push(betCountItem);
        }

        return {
            Entities: entities,
            Total: {
                Date: startDate.toDate(),
                WinLoss: -13281.321356,
                BetCount: 1321310,
                WinCount: 32321,
                DrawCount: 67657
            }
        };
    }
}