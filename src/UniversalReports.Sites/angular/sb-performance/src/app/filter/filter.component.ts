import { NapDateStruct, DateHelper, DateFormat } from 'nap-components/date';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import * as moment from 'moment';
import { CONFIG } from '../common/date-config';
import { FilterModel, SelectItem } from './filter.model';
import { FilterService } from './filter.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss'],
  providers: [
    FilterService]
})
export class FilterComponent implements OnInit {
  @Output() generated = new EventEmitter<FilterModel>();
  minStartDate: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.minDate);
  maxEndDate: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.today);
  startDate: NapDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.today));
  endDate: NapDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.today));
  timeRangeOptions: SelectItem[] = [
    new SelectItem('Whole Day', -1),
    new SelectItem('00 - 02', 2),
    new SelectItem('00 - 04', 4),
    new SelectItem('00 - 06', 6),
    new SelectItem('00 - 08', 8),
    new SelectItem('00 - 10', 10),
    new SelectItem('00 - 12', 12),
    new SelectItem('00 - 14', 14),
    new SelectItem('00 - 16', 16),
    new SelectItem('00 - 18', 18),
    new SelectItem('00 - 20', 20),
    new SelectItem('00 - 22', 22)
  ];
  margin = 3.00;
  topRowOptions: SelectItem[] = [
    new SelectItem('50', 50),
    new SelectItem('100', 100),
    new SelectItem('200', 200),
    new SelectItem('500', 500)
  ];

  isShowFullColumn = false;

  constructor(private readonly filterService: FilterService) { }

  ngOnInit() {
    this.filterService.showFullColumn().subscribe(data => {
      this.isShowFullColumn = data;
    });
  }

  onDateChangeFrom() {
    let startDate: moment.Moment;
    let endDate: moment.Moment;
    let tempStartDate: moment.Moment;
    let tempEndDate: moment.Moment;

    startDate = DateHelper.convertDateStructToMoment(this.startDate);
    endDate = DateHelper.convertDateStructToMoment(this.endDate);
    tempStartDate = moment.utc(startDate);
    tempEndDate = moment.utc(endDate);
    const maxEndDate = startDate;

    if (maxEndDate.isBefore(endDate)) {
      tempEndDate = moment.utc(maxEndDate);
    }

    this.startDate = DateHelper.convertMomentToDateStruct(tempStartDate);
    this.endDate = DateHelper.convertMomentToDateStruct(tempEndDate);
  }

  onDateChangeTo() {
    let startDate: moment.Moment;
    let endDate: moment.Moment;
    let tempStartDate: moment.Moment;
    let tempEndDate: moment.Moment;

    startDate = DateHelper.convertDateStructToMoment(this.startDate);
    endDate = DateHelper.convertDateStructToMoment(this.endDate);
    tempStartDate = moment.utc(startDate);
    tempEndDate = moment.utc(endDate);
    const minStartDate = endDate.subtract(1, 'year');

    if (minStartDate.isAfter(startDate)) {
      tempStartDate = moment.utc(minStartDate);
    }

    this.startDate = DateHelper.convertMomentToDateStruct(tempStartDate);
    this.endDate = DateHelper.convertMomentToDateStruct(tempEndDate);
  }

  onGenerateClick(timeRange: number, topRows: number) {
    const model = this.createModel(timeRange, topRows);
    this.generated.emit(model);
  }

  private createModel(timeRange: number, topRows: number): FilterModel {
    const fromDate = DateHelper.convertDateStructToMoment(this.startDate);
    const toDate = DateHelper.convertDateStructToMoment(this.endDate);

    const model: FilterModel = {
      fromDate: DateHelper.formatMomentDate(fromDate, DateFormat.Date),
      toDate: DateHelper.formatMomentDate(toDate, DateFormat.Date),
      timeRange: Number(timeRange),
      margin: Number(this.margin),
      topRows: Number(topRows),
      isShowFullColumn: this.isShowFullColumn
    };

    return model;
  }
}
