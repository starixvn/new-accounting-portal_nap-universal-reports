import { Component, OnInit } from '@angular/core';
import { DateHelper, NapDateStruct } from 'nap-components/date';
import { TreeviewConfig } from 'ngx-treeview';
import { CONFIG } from '../common/date-config';
import { FilterItemModel } from './filter.model';
import { FilterService } from './filter.service';
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

  licensees: FilterItemModel[] = [];
  licenseeTreeviewConfig = TreeviewConfig.create({
    hasFilter: true,
    hasAllCheckBox: true,
    hasCollapseExpand: false,
    maxHeight: 500
  });
  selectedLicensees: number[] = [];

  sports: FilterItemModel[] = [];
  sportTreeviewConfig = TreeviewConfig.create({
    hasFilter: true,
    hasAllCheckBox: true,
    hasCollapseExpand: false,
    maxHeight: 500
  });
  selectedSports: number[] = [];
  
  constructor(
    private readonly filterSerivce: FilterService
  ) { }

  ngOnInit(): void {
    this.filterSerivce.getLicensees().subscribe(licensees => {
      this.licensees = licensees;
    });

    this.filterSerivce.getSports().subscribe(sports => {
      this.sports = sports;
    });
  }

  onPeriodTypeChange(model: PeriodTypeEventModel) {
    this.periodTypeEventModel = model;
  }

  onGenerateClick() {
    
  }
}
