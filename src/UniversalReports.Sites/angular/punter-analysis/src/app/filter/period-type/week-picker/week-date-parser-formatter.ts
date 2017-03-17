import { DatePipe } from '@angular/common';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { NgbDateStruct, NgbDate } from '../period-type.model';
import { Helper } from '../helper';

export class WeekDateParserFormatter extends NgbDateParserFormatter {
    private datePipe = new DatePipe('en-US');
    constructor(
        private dateFormatString: string
    ) {
        super();
    }

    format(date: NgbDateStruct): string {
        if (date === null) {
            return '';
        }
        try {
            const weekNumber = this.getWeekNumber(date);
            const dateString = this.datePipe.transform(Helper.convertDateStructToDate(date), this.dateFormatString);
            return `${weekNumber} (${dateString})`;
        } catch (e) {
            return '';
        }
    }

    parse(value: string): NgbDateStruct {
        let returnVal: NgbDateStruct;
        if (!value) {
            returnVal = null;
        } else {
            try {
                let dateParts = this.datePipe.transform(value, 'M-d-y').split('-');
                returnVal = { year: parseInt(dateParts[2]), month: parseInt(dateParts[0]), day: parseInt(dateParts[1]) };
            } catch (e) {
                returnVal = null;
            }
        }
        return returnVal;
    }

    private getWeekNumber(date: NgbDateStruct): number {
        let jsDate = Helper.convertDateStructToDate(date);
        if (!isNaN(jsDate.getTime())) {
            jsDate.setFullYear(date.year);
        }

        jsDate.setHours(0, 0, 0, 0);
        jsDate.setDate(jsDate.getDate() + 4 - (jsDate.getDay() || 7));
        return Math.ceil((((jsDate.valueOf() - new Date(jsDate.getFullYear(), 0, 1).valueOf()) / 8.64e7) + 1) / 7);
    }
}
