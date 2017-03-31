import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import * as moment from 'moment';
import { DateHelper } from 'nap-components/src/date';
import { FilterModel, PeriodType } from '../filter/filter.model';
import { Grid, GridType } from './grid.model';
import { BetCountGridModel } from './bet-count-grid/bet-count-grid.model';
import { AssociatedAccountGridModel } from './associated-account-grid/associated-account-grid.model';

@Injectable()
export class GridService {
    filterModel: FilterModel;
    activeGrid: Grid;
    show = new Subject<GridType>();

    showGrid(gridType: GridType) {
        this.show.next(gridType);
    }

    getDateTitle() {
        const momentFromDate = DateHelper.convertDateStructToMoment(this.filterModel.fromDate);
        const momentToDate = DateHelper.convertDateStructToMoment(this.filterModel.toDate);
        const dateFormat = 'MMM DD, YYYY';
        const fromDateString = momentFromDate.format(dateFormat);
        const toDateString = momentToDate.format(dateFormat);
        const periodTitle = this.getPeriodTitle(this.filterModel.periodType);
        return `from ${fromDateString} to ${toDateString} (${periodTitle})`;
    }

    private getPeriodTitle(periodType: PeriodType): string {
        switch (periodType) {
            case PeriodType.Daily:
                return 'Daily';
            case PeriodType.Weekly:
                return 'Weekly';
            case PeriodType.Monthly:
            case PeriodType.MonthRange:
                return 'Monthly';
            case PeriodType.Annually:
                return 'Annually';
        }
    }
}
