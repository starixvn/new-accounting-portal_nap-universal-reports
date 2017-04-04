import { DateHelper } from './date-helper';

export interface NgbDateStruct {
    /**
     * The year, for example 2016
     */
    year: number;

    /**
     * The month, with default calendar we use ISO 8601: 1=Jan ... 12=Dec
     */
    month: number;

    /**
     * The day of month, starting at 1
     */
    day: number;
}

export class NgbDate {
    static from(date: { year: number, month: number, day?: number }): NgbDate {
        return date ? new NgbDate(date.year, date.month, date.day ? date.day : 1) : null;
    }

    static fromToday(): NgbDate {
        const today = new Date();
        return NgbDate.fromDate(today);
    }

    static fromDateStruct(dateStruct: NgbDateStruct): NgbDate {
        return new NgbDate(dateStruct.year, dateStruct.month, dateStruct.day);
    }

    static fromDate(date: Date): NgbDate {
        return NgbDate.fromDateStruct(DateHelper.convertDateToDateStruct(date));
    }

    constructor(public year: number, public month: number, public day: number) { }

    equals(other: NgbDate) {
        return other && this.year === other.year && this.month === other.month && this.day === other.day;
    }

    before(other: NgbDate) {
        if (!other) {
            return false;
        }

        if (this.year === other.year) {
            if (this.month === other.month) {
                return this.day === other.day ? false : this.day < other.day;
            } else {
                return this.month < other.month;
            }
        } else {
            return this.year < other.year;
        }
    }

    after(other: NgbDate) {
        if (!other) {
            return false;
        }
        if (this.year === other.year) {
            if (this.month === other.month) {
                return this.day === other.day ? false : this.day > other.day;
            } else {
                return this.month > other.month;
            }
        } else {
            return this.year > other.year;
        }
    }

    toDateStruct(): NgbDateStruct {
        return { year: this.year, month: this.month, day: this.day };
    }

    toString() {
        return `${this.year}-${this.month}-${this.day}`;
    }
}

export interface WeekRange {
    fromDate: NgbDateStruct;
    toDate: NgbDateStruct;
}
