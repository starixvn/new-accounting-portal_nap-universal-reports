import { DatePipe } from '@angular/common';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { NgbDateStruct, NgbDate, DateHelper } from 'nap-components/src/date';

export class WeekDateParserFormatter extends NgbDateParserFormatter {
    private datePipe = new DatePipe('en-US');
    constructor(
        private dateFormatString: string
    ) {
        super();
    }

    format(dateStruct: NgbDateStruct): string {
        if (dateStruct === null) {
            return '';
        }
        const weekNumber = this.getWeekNumber(dateStruct);
        const firstDayOfWeek = DateHelper.getFirstDayOfWeek(dateStruct);
        const date = DateHelper.convertDateStructToDate(firstDayOfWeek);
        const dateString = this.datePipe.transform(date, this.dateFormatString);
        return `${weekNumber} (${dateString})`;
    }

    parse(value: string): NgbDateStruct {
        let returnVal: NgbDateStruct;
        if (!value) {
            returnVal = null;
        } else {
            try {
                const dateParts = this.datePipe.transform(value, 'M-d-y').split('-');
                returnVal = {
                    year: parseInt(dateParts[2], 10),
                    month: parseInt(dateParts[0], 10),
                    day: parseInt(dateParts[1], 10)
                };
            } catch (e) {
                returnVal = null;
            }
        }
        return returnVal;
    }

    private getWeekNumber(dateStruct: NgbDateStruct): number {
        const jsDate = DateHelper.convertDateStructToDate(dateStruct);
        if (!isNaN(jsDate.getTime())) {
            jsDate.setFullYear(dateStruct.year);
        }

        jsDate.setHours(0, 0, 0, 0);
        jsDate.setDate(jsDate.getDate() + 4 - (jsDate.getDay() || 7));
        return Math.ceil((((jsDate.valueOf() - new Date(jsDate.getFullYear(), 0, 1).valueOf()) / 8.64e7) + 1) / 7);
    }
}
