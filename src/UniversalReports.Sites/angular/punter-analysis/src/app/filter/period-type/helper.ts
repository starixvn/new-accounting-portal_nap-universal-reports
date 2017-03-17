import { NgbDateStruct, NgbDate, WeekRange } from './period-type.model';

export let Helper = {
    getWeekRangeOfDate: getWeekRangeOfDate,
    getFirstDayOfWeek: getFirstDayOfWeek,
    getLastDayOfWeek: getLastDayOfWeek,
    convertDateStructToDate: convertDateStructToDate,
    convertDateToDateStruct: convertDateToDateStruct,
    convertStringToDate: convertStringToDate
};

function getWeekRangeOfDate(dateStruct: NgbDateStruct): WeekRange {
    return {
        fromDate: getFirstDayOfWeek(dateStruct),
        toDate: getLastDayOfWeek(dateStruct)
    }
}

function getFirstDayOfWeek(dateStruct: NgbDateStruct): NgbDateStruct {
    let date = convertDateStructToDate(dateStruct);
    let day = date.getDay();
    if (day === 0) {
        date.setDate(dateStruct.day - 6);
    } else {
        date.setDate(dateStruct.day - day + 1);
    }

    return convertDateToDateStruct(date);
}

function getLastDayOfWeek(dateStruct: NgbDateStruct): NgbDateStruct {
    let date = convertDateStructToDate(dateStruct);
    let day = date.getDay();
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

function convertStringToDate(dateString: string): Date {
    return new Date(Date.parse(dateString));
}
