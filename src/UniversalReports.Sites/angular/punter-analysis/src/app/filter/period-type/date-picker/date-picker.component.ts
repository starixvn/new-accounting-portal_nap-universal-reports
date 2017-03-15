import { Component, Input, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { NgbDateStruct, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { DateParserFormatter } from './date-parser-formatter';

@Component({
    selector: 'nap-date-picker',
    templateUrl: './date-picker.component.html',
    styleUrls: ['./date-picker.component.scss'],
    providers: [
        {
            provide: NgbDateParserFormatter,
            useFactory: () => new DateParserFormatter('longDate')
        }
    ]
})
export class DatePickerComponent implements OnInit {
    private datePipe = new DatePipe('en-US');
    @Input() minDate: NgbDateStruct;
    @Input() maxDate: NgbDateStruct;
    @Input() date: NgbDateStruct;

    constructor(
        private ngbDateParserFormatter: NgbDateParserFormatter
    ) { }

    ngOnInit() {
        const today = new Date();
        today.setMonth(0);
        const dateString = this.datePipe.transform(today, 'longDate');
        this.date = this.ngbDateParserFormatter.parse(dateString);
    }
}
