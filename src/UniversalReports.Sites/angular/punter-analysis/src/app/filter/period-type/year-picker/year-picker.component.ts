import { Component, Input, Output, OnChanges, EventEmitter } from '@angular/core';
import { DatePipe } from '@angular/common';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

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

    ngOnChanges() {
        this.buildModel();
    }

    onYearChange() {
        this.date.year = this.year;
        this.dateChange.emit(this.date);
    }

    private buildModel() {
        this.year = this.date.year;
        this.years = [];
        const fromYear = this.minDate.year;
        const toYear = this.maxDate.year;
        for (let year = fromYear; year <= toYear; year++) {
            this.years.push(year);
        }
    }
}
