import { Component, OnInit } from '@angular/core';
import { DateHelper, NapDateStruct } from 'nap-components/date';
import { CONFIG } from '../common/date-config';
import { PeriodTypeEventModel } from './period-type/period-type.model';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  minStartDate: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.yesterday.add(-2, 'year'));
  maxEndDate: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.yesterday);
  periodTypeEventModel: PeriodTypeEventModel;
  
  constructor() { }

  ngOnInit(): void {
  }

  onPeriodTypeChange(model: PeriodTypeEventModel) {
    this.periodTypeEventModel = model;
  }
}
