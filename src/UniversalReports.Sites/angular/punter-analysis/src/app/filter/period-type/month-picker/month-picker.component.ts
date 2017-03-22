import { Component, Input, OnChanges, Output, EventEmitter, SimpleChanges } from '@angular/core';
import { DatePipe } from '@angular/common';
import * as moment from 'moment';
import { OptionItem } from 'nap-components/src/model';
import { NgbDateStruct } from 'nap-components/src/date';

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
    months: number[];
    year: number;
    years: number[];

    ngOnChanges(changes: SimpleChanges) {
        const dateChange = changes['date'];
        if (dateChange) {
            this.date.day = 1;
        }

        const maxDateChange = changes['maxDate'];
        const minDateChange = changes['minDate'];
        if (maxDateChange || minDateChange || dateChange) {
            this.generateYears();
            this.generateMonths();
        }
    }

    onMonthChange(month: string) {
        this.month = parseInt(month);
        this.date = { year: this.date.year, month: this.month, day: this.date.day };
        this.dateChange.emit(this.date);
    }

    onYearChange(year: string) {
        this.year = parseInt(year);
        let month = this.date.month;
        if (this.year === this.minDate.year) {
            month = Math.max(this.minDate.month, this.month);
        }
        if (this.year === this.maxDate.year) {
            month = Math.min(this.maxDate.month, this.month);
        }
        this.date = { year: this.year, month: month, day: this.date.day };
        this.dateChange.emit(this.date);
    }

    getMonthName(month: number) {
        const monthFullNames = moment.months();
        return monthFullNames[month - 1];
    }

    private generateMonths() {
        this.month = this.date.month;
        this.months = [];
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
            this.months.push(month);
        }
    }

    private generateYears() {
        this.year = this.date.year;
        this.years = [];
        const fromYear = this.minDate.year;
        const toYear = this.maxDate.year;
        for (let year = fromYear; year <= toYear; year++) {
            this.years.push(year);
        }
    }
}
