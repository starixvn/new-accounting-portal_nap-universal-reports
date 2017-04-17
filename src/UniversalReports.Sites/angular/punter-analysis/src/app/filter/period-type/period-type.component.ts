import { Component, Input, OnChanges, Output, EventEmitter, SimpleChanges } from '@angular/core';
import { NgbDatepickerConfig, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import * as _ from 'lodash';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { DateHelper, NgbDateStruct, NgbDate } from 'nap-components/src/date';
import { PeriodType } from '../filter.model';
import { PeriodTypeEventModel } from './period-type.model';

@Component({
    selector: 'nap-period-type',
    templateUrl: './period-type.component.html',
    styleUrls: [
        '../filter.component.scss',
        'period-type.component.scss'
    ]
})
export class PeriodTypeComponent implements OnChanges {
    @Input() minDate: NgbDateStruct;
    @Input() maxDate: NgbDateStruct;
    @Output() periodTypeChange = new EventEmitter<PeriodTypeEventModel>();
    periodType = PeriodType.Daily;
    PeriodType = PeriodType;
    periodTypeOptions = this.getPeriodTypeOptions();

    dailyFromDate: NgbDateStruct;
    dailyToDate: NgbDateStruct;
    weeklyFromDate: NgbDateStruct;
    weeklyMaxFromDate: NgbDateStruct;
    weeklyToDate: NgbDateStruct;
    monthlyDate: NgbDateStruct;
    annuallyDate: NgbDateStruct;
    monthRangeFromDate: NgbDateStruct;
    monthRangeToDate: NgbDateStruct;

    constructor() {
        const todayNgbDate = NgbDate.fromToday();
        this.initDefaultDate(todayNgbDate.toDateStruct());
    }

    ngOnChanges(changes: SimpleChanges) {
        const maxDateChange = changes['maxDate'];
        if (maxDateChange) {
            const maxDateStruct: NgbDateStruct = maxDateChange.currentValue;
            const maxDate = NgbDate.from(maxDateStruct);
            const todayDate = NgbDate.fromToday();
            if (maxDate.before(todayDate)) {
                this.initDefaultDate(maxDateStruct);
            }
        }

        const minDateChange = changes['minDate'];
        if (minDateChange) {
            this.weeklyMaxFromDate = this.getWeeklyMaxFromDate();
        }

        this.onDailyDateChange();
    }

    onTypeChange() {
        switch (this.periodType) {
            case PeriodType.Daily:
                this.onDailyDateChange();
                break;
            case PeriodType.Weekly:
                this.onWeeklyDateChange();
                break;
            case PeriodType.Monthly:
                this.onMonthlyDateChange();
                break;
            case PeriodType.MonthRange:
                this.onMonthRangeDateChange();
                break;
            case PeriodType.Annually:
                this.onAnnuallyDateChange();
                break;
        }
    }

    onDailyDateChange() {
        this.periodTypeChange.emit({
            periodType: this.periodType,
            fromDate: this.dailyFromDate,
            toDate: this.dailyToDate
        });
    }

    onWeeklyDateChange() {
        this.periodTypeChange.emit({
            periodType: this.periodType,
            fromDate: DateHelper.getFirstDayOfWeek(this.weeklyFromDate),
            toDate: this.weeklyToDate
        });
    }

    onWeeklyToDateChange() {
        this.weeklyMaxFromDate = this.getWeeklyMaxFromDate();
        this.onWeeklyDateChange();
    }

    onMonthlyDateChange() {
        this.periodTypeChange.emit({
            periodType: this.periodType,
            fromDate: this.monthlyDate,
            toDate: this.monthlyDate
        });
    }

    onAnnuallyDateChange() {
        this.periodTypeChange.emit({
            periodType: this.periodType,
            fromDate: this.annuallyDate,
            toDate: this.annuallyDate
        });
    }

    onMonthRangeDateChange() {
        this.periodTypeChange.emit({
            periodType: this.periodType,
            fromDate: this.monthRangeFromDate,
            toDate: this.monthRangeToDate
        });
    }

    private initDefaultDate(date: NgbDateStruct) {
        this.dailyFromDate = _.clone(date);
        this.dailyToDate = _.clone(date);
        this.weeklyFromDate = _.clone(date);
        this.weeklyToDate = _.clone(date);
        this.monthlyDate = _.clone(date);
        this.annuallyDate = _.clone(date);
        this.monthRangeFromDate = _.clone(date);
        this.monthRangeToDate = _.clone(date);
    }

    private getWeeklyMaxFromDate(): NgbDateStruct {
        if (this.weeklyToDate) {
            const lastDayOfWeek = DateHelper.getLastDayOfWeek(this.weeklyToDate);
            if (this.maxDate) {
                const maxNgbDate = NgbDate.fromDateStruct(this.maxDate);
                const lastNgDayOfWeek = NgbDate.fromDateStruct(lastDayOfWeek);
                if (maxNgbDate.after(lastNgDayOfWeek)) {
                    return lastNgDayOfWeek;
                } else {
                    return this.maxDate;
                }
            } else {
                return lastDayOfWeek;
            }
        }

        return this.maxDate;
    }

    private getPeriodTypeOptions(): SelectItem[] {
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
