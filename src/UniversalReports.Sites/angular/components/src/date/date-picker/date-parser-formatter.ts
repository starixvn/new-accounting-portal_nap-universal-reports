import { DatePipe } from '@angular/common';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { NgbDateStruct } from '../date-model.date-struct';
import { DateHelper } from '../date-helper';

export class DateParserFormatter extends NgbDateParserFormatter {
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
        const date = DateHelper.convertDateStructToDate(dateStruct);
        return this.datePipe.transform(date, this.dateFormatString);
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
}
