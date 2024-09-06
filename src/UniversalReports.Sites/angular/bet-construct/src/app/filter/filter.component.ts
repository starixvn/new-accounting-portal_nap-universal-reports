import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FilterModel } from './filter.model';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DateHelper } from 'nap-components/date'
import * as moment from "moment";
import { CONFIG } from '../common/date-config';
import { SelectItem } from 'nap-components/dropdown-select';
import { FilterService } from './filter.service';
import { TurnoverType } from '../common/model';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  @Output() generated = new EventEmitter<FilterModel>();

  minStartDate: NgbDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.yesterday).subtract(1, 'month'));;
  maxEndDate: NgbDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.yesterday));
  startDate: NgbDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.yesterday));
  endDate: NgbDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.yesterday));
  turnoverOptions: SelectItem[] = [];
  turnover = TurnoverType.Normal;

  constructor(private readonly filterService: FilterService) { }

  ngOnInit(): void {
    this.turnoverOptions = this.filterService.getFTurnoverOptions();
  }

  onGenerateClick() {}

}
