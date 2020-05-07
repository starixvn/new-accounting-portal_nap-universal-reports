import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { DateHelper, NapDateStruct, DateFormat } from 'nap-components/date';
import { FilterService } from './filter.service';
import { FilterModel, FilterItemModel } from './filter.model';
import { TreeviewConfig, DropdownTreeviewComponent } from 'ngx-treeview';
import { CONFIG } from '../common/date-config';
import * as moment from 'moment';
import { ToastService } from 'nap-components/toast';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  @ViewChild('siteDropdownTreeview') siteDropdownTreeview: DropdownTreeviewComponent;
  @ViewChild('betTypeDropdownTreeview') betTypeDropdownTreeview: DropdownTreeviewComponent;
  @ViewChild('sportDropdownTreeview') sportDropdownTreeview: DropdownTreeviewComponent;
  @ViewChild('reasonDropdownTreeview') reasonDropdownTreeview: DropdownTreeviewComponent;
  reasons: FilterItemModel[] = [];
  reasonTreeviewConfig = TreeviewConfig.create({
    hasFilter: true,
    hasAllCheckBox: true,
    hasCollapseExpand: false,
    maxHeight: 500
  });
  selectedReasons: number[] = [];
  sites: FilterItemModel[] = [];
  siteTreeviewConfig = TreeviewConfig.create({
    hasFilter: true,
    hasAllCheckBox: true,
    hasCollapseExpand: false,
    maxHeight: 500
  });
  selectedSites: number[] = [];
  sports: FilterItemModel[] = [];
  sportTreeviewConfig = TreeviewConfig.create({
    hasFilter: true,
    hasAllCheckBox: true,
    hasCollapseExpand: false,
    maxHeight: 500
  });
  selectedSports: number[] = [];
  betTypes: FilterItemModel[] = [];
  betTypeTreeviewConfig = TreeviewConfig.create({
    hasFilter: true,
    hasAllCheckBox: true,
    hasCollapseExpand: false,
    maxHeight: 500
  });
  selectedBetTypes: number[] = [];
  @Output() generated = new EventEmitter<FilterModel>();
  isExcludeTest = true;
  memberStr = '';
  showLicenseeControl = this.memberStr === '';
  minStartDate: NapDateStruct = { year: 2017, month: 1, day: 1 };
  maxEndDate: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.yesterday);
  startDate: NapDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.yesterday));
  endDate: NapDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.yesterday));
  sportIds = '0';

  constructor(
    private readonly filterSerivce: FilterService,
    private readonly toastService: ToastService) { }

  ngOnInit() {
    this.filterSerivce.getReason().subscribe(reasons => {
      this.reasons = reasons;
    });

    // this.filterSerivce.getBetType(this.sportIds).subscribe(betTypes => {
    //   this.betTypes = betTypes;
    // });

    this.filterSerivce.getSite().subscribe(sites => {
      this.sites = sites;
    });

    this.filterSerivce.getSport().subscribe(sports => {
      this.sports = sports;
    });
  }

  onGenerateClick() {
    if (!this.isValid) {
      return;
    }

    const model = this.createModel();
    this.generated.emit(model);
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
    const maxEndDate = startDate.add(1, 'year');

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

  onMemberChange(memberValue: string) {
    this.showLicenseeControl = memberValue === '';
  }

  onSportSelectedChange(selectedSports: number[]) {
    this.selectedSports = selectedSports;
    if (selectedSports.length > 0) {
      this.sportIds = selectedSports.join(',');
      this.filterSerivce.getBetType(this.sportIds).subscribe(betTypes => {
        this.betTypes = betTypes;
      });
    }
  }

  private createModel(): FilterModel {
    const fromDate = DateHelper.convertDateStructToMoment(this.startDate);
    const toDate = DateHelper.convertDateStructToMoment(this.endDate);

    const model: FilterModel = {
      fromDate: DateHelper.formatMomentDate(fromDate, DateFormat.Date),
      toDate: DateHelper.formatMomentDate(toDate, DateFormat.Date),
      sport: this.sports.length === this.selectedSports.length ? [0] : this.selectedSports,
      bettype: this.betTypes.length === this.selectedBetTypes.length ? [0] : this.selectedBetTypes,
      reason: this.reasons.length === this.selectedReasons.length ? [0] : this.selectedReasons,
      licensee: this.sites.length === this.selectedSites.length ? [-1] : this.selectedSites,
      isTest: this.isExcludeTest,
      member: this.memberStr
    };

    return model;
  }

  private get isValid(): boolean {
    const maxDate = DateHelper.convertDateStructToMoment(this.startDate).add(4, 'month');
    if (!DateHelper.convertDateStructToMoment(this.endDate).isBefore(maxDate)) {
      this.toastService.activate(`Date range should not exceed 4 months!`);
      return false;
    }

    if (this.selectedReasons.length === 0) {
      this.toastService.activate(`Please select at least one reason!`);
      return false;
    }

    if (this.selectedSites.length === 0) {
      this.toastService.activate(`Please select at least one licensee!`);
      return false;
    }

    if (this.selectedSports.length === 0) {
      this.toastService.activate(`Please select at least one sport!`);
      return false;
    }

    if (this.selectedBetTypes.length === 0) {
      this.toastService.activate(`Please select at least one bet type!`);
      return false;
    }

    return true;
  }
}
