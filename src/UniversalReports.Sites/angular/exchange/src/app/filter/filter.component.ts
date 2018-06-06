import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import {
  TreeviewItem, TreeviewConfig, TreeviewEventParser,
  DownlineTreeviewEventParser, DownlineTreeviewItem
} from 'ngx-treeview';
import * as moment from 'moment';
import { FilterService } from './filter.service';
import { TimePeriod, FilterModel } from './filter.model';
import { CONFIG } from '../common/config';
import { NapDateStruct, DateHelper, DateFormat } from 'nap-components/date';
import * as _ from 'lodash';
import { ToastService } from 'nap-components/toast';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss'],
  providers: [
    FilterService,
    { provide: TreeviewEventParser, useClass: DownlineTreeviewEventParser }
  ]
})
export class FilterComponent implements OnInit {
  @Output() generated = new EventEmitter<FilterModel>();
  timePeriodSelectItems = this.filterService.getTimeSelectItems();
  timePeriod: TimePeriod = TimePeriod.LastMonth;
  minStartDate: NapDateStruct = { year: 2014, month: 1, day: 1 };
  maxEndDate: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.today);
  startDate: NapDateStruct = DateHelper.convertMomentToDateStruct(
    moment.utc(CONFIG.date.today)
      .subtract(1, 'month')
      .startOf('month'));
  endDate: NapDateStruct = DateHelper.convertMomentToDateStruct(
    moment.utc(CONFIG.date.today)
      .subtract(1, 'month')
      .endOf('month'));
  licenseeTreeviewItems: TreeviewItem[];
  sportTreeviewItems: TreeviewItem[];
  treeviewConfig: TreeviewConfig;
  private selectedLicenseeTreeviewItems: DownlineTreeviewItem[];
  private selectedSportTreeviewItems: DownlineTreeviewItem[];

  constructor(private filterService: FilterService, private toastService: ToastService) { }

  ngOnInit() {
    this.createTreeViewConfig();
    this.getLicensee();
    this.getSport();
  }

  onGenerate() {
    const filterModel = this.createFilterModel();
    this.generated.emit(filterModel);
  }

  onTimePeriodChange() {
    let endDate: moment.Moment;
    let startDate: moment.Moment;
    switch (this.timePeriod) {
      case TimePeriod.Today:
        endDate = moment.utc(CONFIG.date.today);
        startDate = moment.utc(CONFIG.date.today);
        break;
      case TimePeriod.Yesterday:
        endDate = moment.utc(CONFIG.date.yesterday);
        startDate = moment.utc(CONFIG.date.yesterday);
        break;
      case TimePeriod.CurrentWeek:
        startDate = moment.utc(CONFIG.date.today).startOf('week');
        endDate = moment.utc(CONFIG.date.today);
        break;
      case TimePeriod.LastWeek:
        startDate = moment.utc(CONFIG.date.today).startOf('week').subtract(1, 'week');
        endDate = moment.utc(startDate).endOf('week');
        break;
      case TimePeriod.CurrentMonth:
        startDate = moment.utc(CONFIG.date.today).startOf('month');
        endDate = moment.utc(CONFIG.date.today);
        break;
      case TimePeriod.LastMonth:
        startDate = moment.utc(CONFIG.date.today).subtract(1, 'month').startOf('month');
        endDate = moment.utc(startDate).endOf('month');
        break;
      case TimePeriod.SinceLastMonth:
        startDate = moment.utc(CONFIG.date.today).subtract(1, 'month').startOf('month');
        endDate = moment.utc(CONFIG.date.today);
        break;
      case TimePeriod.SpecificDate:
        break;
      case TimePeriod.LastThreeMonths:
        startDate = moment.utc(CONFIG.date.today).subtract(3, 'month').startOf('month');
        endDate = moment.utc(CONFIG.date.today).subtract(1, 'month').endOf('month');
        break;
    }

    if (!_.isNil(startDate) && !_.isNil(endDate)) {
      this.startDate = DateHelper.convertMomentToDateStruct(startDate);
      this.endDate = DateHelper.convertMomentToDateStruct(endDate);
    }
  }

  onDateChange() {
    this.timePeriod = TimePeriod.SpecificDate;
  }

  onLicenseeSelectedChange(downlineTreeviewItems: DownlineTreeviewItem[]) {
    this.selectedLicenseeTreeviewItems = downlineTreeviewItems;
  }

  onSportSelectedChange(downlineTreeviewItems: DownlineTreeviewItem[]) {
    this.selectedSportTreeviewItems = downlineTreeviewItems;
  }

  getLicensee() {
    this.filterService.getLicensee().subscribe(licenseeTreeviewItems => this.licenseeTreeviewItems = licenseeTreeviewItems);
  }

  getSport() {
    this.filterService.getSport().subscribe(sportTreeViewItems => this.sportTreeviewItems = sportTreeViewItems);
  }

  createTreeViewConfig() {
    this.treeviewConfig = new TreeviewConfig();
    this.treeviewConfig.hasAllCheckBox = true;
    this.treeviewConfig.hasFilter = true;
    this.treeviewConfig.hasCollapseExpand = true;
    this.treeviewConfig.maxHeight = 500;
  }

  private createFilterModel() {
    const fromDate = DateHelper.convertDateStructToMoment(this.startDate);
    const toDate = DateHelper.convertDateStructToMoment(this.endDate);
    const model: FilterModel = {
       fromDate:  DateHelper.formatMomentDate(fromDate, DateFormat.Date),
       toDate:  DateHelper.formatMomentDate(toDate, DateFormat.Date),
       licenseeId: this.selectedLicenseeTreeviewItems.map(licenseeItem => licenseeItem.item.value).join(','),
       sportType: this.selectedSportTreeviewItems.map(sportItem => sportItem.item.value).join(',')
    };

    return model;
  }
}
