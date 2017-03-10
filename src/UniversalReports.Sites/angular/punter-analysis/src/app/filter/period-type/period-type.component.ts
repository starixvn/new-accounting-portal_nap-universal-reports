import { Component } from '@angular/core';
import { PeriodType, OptionItem } from '../filter.model';

@Component({
    selector: 'nap-period-type',
    templateUrl: './period-type.component.html',
    styleUrls: [
        '../filter.component.scss',
        'period-type.component.scss'
    ]
})
export class PeriodTypeComponent {
    periodType = PeriodType.Daily;
    PeriodType  = PeriodType;
    periodTypeOptions = this.getPeriodTypeOptions();

    private getPeriodTypeOptions(): OptionItem[] {
        return [{
            text: 'Daily',
            value: PeriodType.Daily
        }, {
            text: 'Weekly',
            value: PeriodType.Weekly
        }, {
            text: 'Monthly',
            value: PeriodType.Monthly
        }, {
            text: 'Annually',
            value: PeriodType.Annually
        }, {
            text: 'Month Range',
            value: PeriodType.MonthRange
        }];
    }
}