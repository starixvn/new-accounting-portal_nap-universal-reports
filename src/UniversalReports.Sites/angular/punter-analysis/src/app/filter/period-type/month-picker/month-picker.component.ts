import { Component, Input, OnChanges, Output, EventEmitter } from '@angular/core';
import { DatePipe } from '@angular/common';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { OptionItem } from 'nap-components/src/model';

@Component({
    selector: 'nap-month-picker',
    templateUrl: './month-picker.component.html'
})
export class MonthPickerComponent implements OnChanges {
    @Input() minDate: NgbDateStruct;
    @Input() maxDate: NgbDateStruct;
    @Input() date: NgbDateStruct;
    @Output() dateChange = new EventEmitter<NgbDateStruct>();
    month: number;
    monthOptions: OptionItem[];
    year: number;
    years: number[];

    ngOnChanges() {
        this.buildModel();
    }

    onMonthChange() {
        this.date.month = this.month;
        this.dateChange.emit(this.date);
    }

    onYearChange() {
        this.date.year = this.year;
        if (this.year === this.minDate.year) {
            this.date.month = Math.max(this.minDate.month, this.month);
        }
        if (this.year === this.maxDate.year) {
            this.date.month = Math.min(this.maxDate.month, this.month);
        }
        if (this.month !== this.date.month) {
            this.buildMonths();
        }
        this.dateChange.emit(this.date);
    }

    private buildModel() {
        this.buildMonths();
        this.buildYears();
    }

    private buildMonths() {
        this.month = this.date.month;
        this.monthOptions = [];
        let fromMonth = 1;
        let toMonth = 12;
        if (this.date.year === this.minDate.year) {
            fromMonth = this.minDate.month;
        }
        if (this.date.year === this.maxDate.year) {
            toMonth = this.maxDate.month;
        }
        const monthFullNames = moment.months();
        for (let month = fromMonth; month <= toMonth; month++) {
            this.monthOptions.push({
                text: monthFullNames[month - 1],
                value: month
            });
        }
    }

    private buildYears() {
        this.year = this.date.year;
        this.years = [];
        const fromYear = this.minDate.year;
        const toYear = this.maxDate.year;
        for (let year = fromYear; year <= toYear; year++) {
            this.years.push(year);
        }
    }
}
