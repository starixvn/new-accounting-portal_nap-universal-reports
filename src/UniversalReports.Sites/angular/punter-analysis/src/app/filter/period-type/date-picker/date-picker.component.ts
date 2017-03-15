import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
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
    @Output() dateChange = new EventEmitter<NgbDateStruct>();

    constructor(
        private ngbDateParserFormatter: NgbDateParserFormatter
    ) { }

    ngOnInit() {
    }

    onModelChange() {
        this.dateChange.emit(this.date);
    }
}
