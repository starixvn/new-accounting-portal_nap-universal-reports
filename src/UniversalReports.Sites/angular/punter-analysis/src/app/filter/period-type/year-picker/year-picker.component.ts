import { Component, Input, Output, OnChanges, EventEmitter, SimpleChanges } from '@angular/core';
import { DatePipe } from '@angular/common';
import { NgbDateStruct } from 'nap-components/src/date';

@Component({
    selector: 'nap-year-picker',
    templateUrl: './year-picker.component.html'
})
export class YearPickerComponent implements OnChanges {
    @Input() minDate: NgbDateStruct;
    @Input() maxDate: NgbDateStruct;
    @Input() date: NgbDateStruct;
    @Output() dateChange = new EventEmitter<NgbDateStruct>();
    year: number;
    years: number[];

    ngOnChanges(changes: SimpleChanges) {
        const dateChange = changes['date'];
        if (dateChange) {
            this.date.day = 1;
            this.date.month = 1;
        }

        const maxDateChange = changes['maxDate'];
        const minDateChange = changes['minDate'];
        if (maxDateChange || minDateChange || dateChange) {
            this.generateYears();
        }
    }

    onYearChange(year: string) {
        this.year = parseInt(year, 10);
        this.date = { year: this.year, month: this.date.month, day: this.date.day };
        this.dateChange.emit(this.date);
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
