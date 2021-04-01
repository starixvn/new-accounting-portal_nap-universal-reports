import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import * as moment from 'moment';
import { DateHelper, NapDateStruct } from 'nap-components/date';
import { SelectItem } from 'nap-components/dropdown-select';
import { PeriodType } from '../filter.model';
import { PeriodTypeEventModel } from './period-type.model';
import * as _ from 'lodash';

@Component({
  selector: 'nap-period-type',
  templateUrl: './period-type.component.html',
  styleUrls: [
    '../filter.component.scss',
    './period-type.component.scss'
  ]
})
export class PeriodTypeComponent implements OnChanges {
  @Input() minDate: NapDateStruct;
  @Input() maxDate: NapDateStruct;
  @Output() periodTypeChange = new EventEmitter<PeriodTypeEventModel>();
  periodType = PeriodType.Yesterday;
  PeriodType = PeriodType;
  periodTypeOptions = this.getPeriodTypeOptions();

  yesterdayDate: NapDateStruct;
  specificFromDate: NapDateStruct;
  specificToDate: NapDateStruct;
  // monthlyDate: NapDateStruct;
  // monthlyEndDate: NapDateStruct;
  // annuallyDate: NapDateStruct;
  // annuallyEndDate: NapDateStruct;

  private emittedModel: PeriodTypeEventModel;
  private todayNgbDate: NapDateStruct = DateHelper.convertMomentToDateStruct(moment().startOf('day'));
  private maxDateStruct: NapDateStruct;
  constructor() {
    this.initDefaultDate(this.todayNgbDate);
  }

  ngOnChanges(changes: SimpleChanges) {
    const maxDateChange = changes['maxDate'];
    if (maxDateChange) {
      const maxDateStruct: NapDateStruct = maxDateChange.currentValue;
      this.maxDateStruct = maxDateStruct;
      const maxDate = DateHelper.convertDateStructToMoment(maxDateStruct);
      const todayDate = DateHelper.convertDateStructToMoment(this.todayNgbDate);
      if (maxDate.isBefore(todayDate)) {
        this.initDefaultDate(maxDateStruct);
      }
    }

    this.onSpecificDateChange();
  }

  onTypeChange() {
    switch (this.periodType) {
      case PeriodType.Yesterday:
        this.onYesterdayDateChange();
        break;
      case PeriodType.SpecificDate:
        this.onSpecificDateChange();
        break;
      // case PeriodType.Monthly:
      //   this.onMonthlyDateChange();
      //   break;
      // case PeriodType.Annually:
      //   this.onAnnuallyDateChange();
      //   break;
    }
  }

  onYesterdayDateChange() {
    this.emitChange({
      periodType: this.periodType,
      fromDate: this.yesterdayDate,
      toDate: this.yesterdayDate
    });
  }

  onSpecificDateChange() {
    this.emitChange({
      periodType: this.periodType,
      fromDate: this.specificFromDate,
      toDate: this.specificToDate
    });
  }

  // onMonthlyDateChange() {
  //   const maxDateValue =  DateHelper.convertDateStructToMoment(this.maxDateStruct);
  //   const monthlyDate = { year: this.monthlyDate.year, month: this.monthlyDate.month, day: 1 };

  //   const startMonth = DateHelper.convertDateStructToMoment(monthlyDate);
  //   const endMonth = moment(startMonth).endOf('month');
  //   let endMonthDateStruct = DateHelper.convertMomentToDateStruct(endMonth);

  //   if (maxDateValue.isBefore(endMonth)) {
  //     endMonthDateStruct = DateHelper.convertMomentToDateStruct(maxDateValue);
  //   }

  //   const endMonthDate = {year: endMonthDateStruct.year, month: endMonthDateStruct.month, day: endMonthDateStruct.day};

  //   this.emitChange({
  //     periodType: this.periodType,
  //     fromDate: monthlyDate,
  //     toDate: endMonthDate
  //   });
  // }

  // onAnnuallyDateChange() {
  //   const maxDateValue =  DateHelper.convertDateStructToMoment(this.maxDateStruct);
  //   const annuallyDate = { year: this.annuallyDate.year, month: 1, day: 1 };

  //   const startYear = moment({years: this.annuallyDate.year, months: 1, date: 1});
  //   let endYear = moment(startYear).endOf('year');

  //   if (maxDateValue.isBefore(endYear)) {
  //     endYear = maxDateValue;
  //   }

  //   const endYearDateStruct = DateHelper.convertMomentToDateStruct(endYear);
  //   const endYearDate = {year: endYearDateStruct.year, month: endYearDateStruct.month, day: endYearDateStruct.day};

  //   this.emitChange({
  //     periodType: this.periodType,
  //     fromDate: annuallyDate,
  //     toDate: endYearDate
  //   });
  // }

  private emitChange(model: PeriodTypeEventModel) {
    let shouldEmit = true;
    if (this.emittedModel !== undefined) {
      shouldEmit = this.emittedModel.periodType !== model.periodType
        || !_.isEqual(this.emittedModel.fromDate, model.fromDate)
        || !_.isEqual(this.emittedModel.toDate, model.toDate);
    }

    if (shouldEmit) {
      this.emittedModel = model;
      this.periodTypeChange.emit(model);
    }
  }

  private initDefaultDate(date: NapDateStruct) {
    const maxDateValue =  DateHelper.convertDateStructToMoment(date);
    const dateValue = DateHelper.convertDateStructToMoment(date);
    let endMonth = moment(dateValue).endOf('month');
    let endYear = moment(dateValue).endOf('year');

    if (maxDateValue.isBefore(endMonth)) {
      endMonth = maxDateValue;
    }

    if (maxDateValue.isBefore(endYear)) {
      endYear = maxDateValue;
    }

    // const endMonthDateStruct = DateHelper.convertMomentToDateStruct(endMonth);
    // const endYearDateStruct = DateHelper.convertMomentToDateStruct(endYear);

    this.yesterdayDate = _.clone(date);
    this.specificFromDate = _.clone(date);
    this.specificToDate = _.clone(date);
    // this.monthlyDate = _.clone(date);
    // this.monthlyEndDate = _.clone(endMonthDateStruct);
    // this.annuallyDate = _.clone(date);
    // this.annuallyEndDate = _.clone(endYearDateStruct);
  }

  private getPeriodTypeOptions(): SelectItem[] {
    return [
      {
        text: 'Yesterday',
        value: PeriodType.Yesterday
      },
      {
        text: 'Current Week',
        value: PeriodType.CurrentWeek
      },
      {
        text: 'Last Week',
        value: PeriodType.LastWeek
      },
      {
        text: 'Current Month',
        value: PeriodType.CurrentMonth
      },
      {
        text: 'Last Month',
        value: PeriodType.LastMonth
      },
      {
        text: 'Since Last Month',
        value: PeriodType.SinceLastMonth
      },
      {
        text: 'Specific Date',
        value: PeriodType.SpecificDate
      },
      {
        text: 'Last 3 Months',
        value: PeriodType.Last3Months
      }];
  }
}
