import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import * as moment from 'moment';
import { CONFIG } from '../common/config';
import { FilterModel } from './filter.model';
import { FilterService } from './filter.service';
import { NapDateStruct, DateHelper, DateFormat } from 'nap-components/date';
import { ToastService } from 'nap-components/toast';
@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss'],
  providers: [
    FilterService
  ]
})
export class FilterComponent implements OnInit {
  @Output() generated = new EventEmitter<FilterModel>();
  winlostDate: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.today);
  voidedDate: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.today);
  voidedTime: string;
  minStartDate: NapDateStruct;
  maxEndDate: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.today);
  isIncludeVoidedTime: false;
  voidedDateTemp: string;
  matchId: number;
  constructor(
    private readonly filterSerivce: FilterService,
    private toastService: ToastService
  ) { }

  ngOnInit() {
    this.voidedDateTemp = CONFIG.date.today.format(CONFIG.dateFormatString);
    this.voidedTime = CONFIG.date.today.format(CONFIG.timeFormatString);
    this.filterSerivce.getMoveBetsDay().subscribe(model => {
      const moveBet =  DateHelper.convertDateToDateStruct(new Date(model));
      moveBet.day ++;
      this.minStartDate = moveBet;
    });
  }

  onGenerate() {
    const isTime = moment(this.voidedTime, CONFIG.timeFormatString).isValid();
    if (this.isIncludeVoidedTime && this.voidedTime !== '' && !isTime) {
      this.toastService.activate('Invalid time value.');
      return;
    }

    const winlost = DateHelper.convertDateStructToMoment(this.winlostDate);
    const voidedDate = DateHelper.convertDateStructToMoment(this.voidedDate);
    const voidedTime = this.isIncludeVoidedTime
                    ? `${DateHelper.formatMomentDate(voidedDate, DateFormat.Date)} ${this.voidedTime}`  : '';

    const filterModel: FilterModel = {
        winlostDate: DateHelper.formatMomentDate(winlost, DateFormat.Date),
        voidTime: voidedTime,
        matchId: this.matchId,
        productName: ''
    };
    this.generated.emit(filterModel);
  }

  onWinlostDateChange() {
    let winlostDate: moment.Moment;
    winlostDate = DateHelper.convertDateStructToMoment(this.winlostDate);
    winlostDate = moment.utc(winlostDate);
    this.winlostDate = DateHelper.convertMomentToDateStruct(winlostDate);
  }

  onVoidDateChange() {
    let voidDate: moment.Moment;
    voidDate = DateHelper.convertDateStructToMoment(this.voidedDate);
    voidDate = moment.utc(voidDate);
    this.voidedDate = DateHelper.convertMomentToDateStruct(voidDate);
  }
}
