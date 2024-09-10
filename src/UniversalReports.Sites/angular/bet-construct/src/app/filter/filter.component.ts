import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FilterModel } from './filter.model';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DateHelper, DateFormat } from 'nap-components/date'
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
    this.turnoverOptions = this.filterService.getTurnoverOptions();
  }

  onGenerateClick() {
    const model = this.createModel();
    this.generated.emit(model);
  }

  private createModel(): FilterModel {
    const fromDate = DateHelper.convertDateStructToMoment(this.startDate);
    const toDate = DateHelper.convertDateStructToMoment(this.endDate);
    const model: FilterModel = {
      fromDate: DateHelper.formatMomentDate(fromDate, DateFormat.Date),
      toDate: DateHelper.formatMomentDate(toDate, DateFormat.Date),
      sportId: undefined,
      noDraw: this.turnover === TurnoverType.NoDraw,
      breadCrumb: []
    };
    return model;
  }

}
