import { Component, OnInit } from '@angular/core';
import { NgbDatepickerConfig, NgbDateParserFormatter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { OptionItem } from 'nap-components/src/model';
import { PeriodType } from '../filter.model';
import { PeriodTypeService } from './period-type.service';

@Component({
    selector: 'nap-period-type',
    templateUrl: './period-type.component.html',
    styleUrls: [
        '../filter.component.scss',
        'period-type.component.scss'
    ],
    providers: [
        NgbDatepickerConfig,
        PeriodTypeService
    ]
})
export class PeriodTypeComponent implements OnInit {
    periodType = PeriodType.Daily;
    PeriodType = PeriodType;
    periodTypeOptions = this.getPeriodTypeOptions();

    // Daily
    dailyFromDate: NgbDateStruct;
    dailyToDate: NgbDateStruct;

    // Weekly
    weeklyFromDate: NgbDateStruct;
    weeklyToDate: NgbDateStruct;

    // Monthly
    month: number;
    monthOptions: OptionItem[];
    year: number;
    yearOptions: OptionItem[];

    // Annually
    annuallyYear: number;
    annuallyYearOptions: OptionItem[];

    // Month Range
    fromMonth: number;
    fromMonthOptions: OptionItem[];
    fromYear: number;
    fromYearOptions: OptionItem[];
    toMonth: number;
    toMonthOptions: OptionItem[];
    toYear: number;
    toYearOptions: OptionItem[];

    private date: NgbDateStruct = this.getCurrentDate();

    constructor(
        private config: NgbDatepickerConfig,
        private service: PeriodTypeService
    ) {
        config.minDate = { year: 1900, month: 1, day: 1 };
        config.maxDate = { year: 2019, month: 12, day: 31 };
    }

    ngOnInit() {
        this.service.queryDataWarehouseDateRange().subscribe(model => {

        });
        this.buildMonthlyModel();
    }

    private getCurrentDate(): NgbDateStruct {
        return { year: 2017, month: 3, day: 1 };
    }

    private buildMonthlyModel() {
        this.month = this.date.month;
        this.monthOptions = [];
        let fromMonth = 0;
        let toMonth = 11;
        if (this.date.year === this.config.minDate.year) {
            fromMonth = this.config.minDate.month;
        }
        const monthFullNames = moment.months();
        for (let i = fromMonth; i <= toMonth; i++) {
            this.monthOptions.push({
                text: monthFullNames[i],
                value: i
            });
        }

        this.year = this.date.year;
        this.yearOptions = [];
        const fromYear = this.config.minDate.year;
        const toYear = this.config.maxDate.year;
        for (let i = fromYear; i <= toYear; i++) {
            this.yearOptions.push({
                text: i.toString(),
                value: i
            });
        }
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