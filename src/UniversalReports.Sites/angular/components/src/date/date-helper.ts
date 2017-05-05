import * as moment from 'moment';
import { NgbDateStruct } from './date-model.date-struct';
import { DateRange } from './date-model.date-range';
import { DateFormat } from './date-model.date-format';

export let DateHelper = {
    getWeekRangeOfDate: getWeekRangeOfDate,
    getFirstDayOfWeek: getFirstDayOfWeek,
    getLastDayOfWeek: getLastDayOfWeek,
    convertDateStructToDate: convertDateStructToDate,
    convertDateToDateStruct: convertDateToDateStruct,
    convertStringToDate: convertStringToDate,
    convertDateStructToString: convertDateStructToString,
    convertDateStructToMoment: convertDateStructToMoment,
    formatDateStruct: formatDateStruct
};

function getWeekRangeOfDate(dateStruct: NgbDateStruct): DateRange {
    return {
        fromDate: getFirstDayOfWeek(dateStruct),
        toDate: getLastDayOfWeek(dateStruct)
    };
}

function getFirstDayOfWeek(dateStruct: NgbDateStruct): NgbDateStruct {
    const date = convertDateStructToDate(dateStruct);
    const day = date.getDay();
    if (day === 0) {
        date.setDate(dateStruct.day - 6);
    } else {
        date.setDate(dateStruct.day - day + 1);
    }

    return convertDateToDateStruct(date);
}

function getLastDayOfWeek(dateStruct: NgbDateStruct): NgbDateStruct {
    const date = convertDateStructToDate(dateStruct);
    const day = date.getDay();
    if (day === 0) {
        date.setDate(dateStruct.day);
    } else {
        date.setDate(dateStruct.day + 7 - day);
    }

    return convertDateToDateStruct(date);
}

function convertDateStructToDate(dateStruct: NgbDateStruct): Date {
    return new Date(dateStruct.year, dateStruct.month - 1, dateStruct.day);
}

function convertDateToDateStruct(date: Date): NgbDateStruct {
    return { year: date.getFullYear(), month: date.getMonth() + 1, day: date.getDate() };
}

/// example input: '2016-11-02T00:00:00'
function convertStringToDate(dateString: string): Date {
    return new Date(Date.parse(dateString));
}

/// example output: '2016-11-02T00:00:00'
function convertDateStructToString(dateStruct: NgbDateStruct): string {
    const yearString = dateStruct.year.toString();
    const monthString = ('0' + dateStruct.month).slice(-2);
    const dayString = ('0' + dateStruct.day).slice(-2);
    return `${yearString}-${monthString}-${dayString}T00:00:00`;
}

function convertDateStructToMoment(dateStruct: NgbDateStruct): moment.Moment {
    return moment.utc([dateStruct.year, dateStruct.month - 1, dateStruct.day]);
}

function formatDateStruct(dateStruct: NgbDateStruct, dateFormat: DateFormat): string {
    const momentDate = DateHelper.convertDateStructToMoment(dateStruct);
    switch (dateFormat) {
        case DateFormat.Date:
            return momentDate.format('MMM DD, YYYY');
        case DateFormat.Week:
            return momentDate.format('MM/YYYY') + ' - Week ' + momentDate.format('W');
        case DateFormat.Month:
            return momentDate.format('MMM YYYY');
        case DateFormat.Year:
            return momentDate.format('YYYY');
    }
}
