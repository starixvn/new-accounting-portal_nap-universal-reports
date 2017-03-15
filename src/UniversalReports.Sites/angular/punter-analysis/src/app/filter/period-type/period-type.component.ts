import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { NgbDatepickerConfig, NgbDateParserFormatter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { OptionItem } from 'nap-components/src/model';
import { PeriodType } from '../filter.model';

interface DateRange {
    fromDate: NgbDateStruct,
    toDate: NgbDateStruct
}

@Component({
    selector: 'nap-period-type',
    templateUrl: './period-type.component.html',
    styleUrls: [
        '../filter.component.scss',
        'period-type.component.scss'
    ]
})
export class PeriodTypeComponent implements OnInit {
    @Input() minDate: NgbDateStruct;
    @Input() maxDate: NgbDateStruct;
    @Output() dateRangeChange = new EventEmitter<DateRange>();
    periodType = PeriodType.Daily;
    PeriodType = PeriodType;
    periodTypeOptions = this.getPeriodTypeOptions();

    dailyFromDate: NgbDateStruct;
    dailyToDate: NgbDateStruct;
    weeklyFromDate: NgbDateStruct;
    weeklyToDate: NgbDateStruct;
    monthlyDate: NgbDateStruct;
    annuallyDate: NgbDateStruct;
    monthRangeFromDate: NgbDateStruct;
    monthRangeToDate: NgbDateStruct;

    constructor() {
        const date = this.getCurrentDate();
        this.dailyFromDate = date;
        this.dailyToDate = date;
        this.weeklyFromDate = date;
        this.weeklyToDate = date;
        this.monthlyDate = this.getCurrentDate();
        this.annuallyDate = this.getCurrentDate();
        this.monthRangeFromDate = date;
        this.monthRangeToDate = date;
    }

    ngOnInit() {
        console.log('test');
    }

    onDailyDateChange() {

    }

    onWeeklyDateChange() {

    }

    onMonthlyDateChange() {

    }

    onAnnuallyDateChange() {

    }

    onMonthRangeDateChange() {

    }

    private getCurrentDate(): NgbDateStruct {
        return { year: 2017, month: 3, day: 1 };
    }

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