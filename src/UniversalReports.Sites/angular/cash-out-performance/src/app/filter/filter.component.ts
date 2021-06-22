import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import * as _ from 'lodash';
import * as moment from 'moment';
import { DateFormat, DateHelper } from 'nap-components/date';
import { ToastService } from 'nap-components/toast';
import { TreeviewConfig } from 'ngx-treeview';
import { CONFIG } from '../common/date-config';
import { FilterItemModel, FilterModel, LeagueModel, TimePeriod } from './filter.model';
import { FilterService } from './filter.service';
import { TypeaheadQuery } from 'nap-components/dropdown-typeahead';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss'],
})
export class FilterComponent implements OnInit {
  @Output() generated = new EventEmitter<FilterModel>();
  timePeriodSelectItems = this.filterService.getTimeSelectItems();
  timePeriod: TimePeriod = TimePeriod.Yesterday;
  minStartDate: NgbDateStruct = { year: 2019, month: 1, day: 1 };
  maxEndDate: NgbDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.yesterday);
  startDate: NgbDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.yesterday));
  endDate: NgbDateStruct = DateHelper.convertMomentToDateStruct(moment.utc(CONFIG.date.yesterday));

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

  leagueId = '';
  leagueName = '';
  leagueNameTypeaheadQuery = this.buildLeagueNameTypeaheadQuery();
  leagueNamePlaceholder = 'League name';
  constructor(
    private readonly filterService: FilterService,
    private readonly toastService: ToastService
  ) { }

  ngOnInit(): void {
    this.filterService.getLicensees().subscribe(licensees => {
      this.licensees = licensees;
    });

    this.filterService.getSports().subscribe(sports => {
      this.sports = sports;
    });
  }

  onTimePeriodChange(): void {
    let endDate: moment.Moment;
    let startDate: moment.Moment;
    switch (this.timePeriod) {
      case TimePeriod.Yesterday:
        endDate = moment.utc(CONFIG.date.yesterday);
        startDate = moment.utc(CONFIG.date.yesterday);
        break;
      case TimePeriod.CurrentWeek:
        startDate = moment.utc(CONFIG.date.today).startOf('week');
        endDate = moment.utc(CONFIG.date.today);

        if (moment(startDate).isBefore(endDate)) {
          endDate = moment.utc(CONFIG.date.yesterday);
        }
        break;
      case TimePeriod.LastWeek:
        startDate = moment.utc(CONFIG.date.today).startOf('week').subtract(1, 'week');
        endDate = moment.utc(startDate).endOf('week');
        break;
      case TimePeriod.CurrentMonth:
        startDate = moment.utc(CONFIG.date.today).startOf('month');
        endDate = moment.utc(CONFIG.date.today);

        if (moment(startDate).isBefore(endDate)) {
          endDate = moment.utc(CONFIG.date.yesterday);
        }
        break;
      case TimePeriod.LastMonth:
        startDate = moment.utc(CONFIG.date.today).subtract(1, 'month').startOf('month');
        endDate = moment.utc(startDate).endOf('month');
        break;
      case TimePeriod.SinceLastMonth:
        startDate = moment.utc(CONFIG.date.today).subtract(1, 'month').startOf('month');
        endDate = moment.utc(CONFIG.date.today);

        if (moment(startDate).isBefore(endDate)) {
          endDate = moment.utc(CONFIG.date.yesterday);
        }
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

  onDateChange(): void {
    this.timePeriod = TimePeriod.SpecificDate;
  }

  async onGenerateClick(): Promise<void> {
    await this.OnGenerate();
  }

  private async OnGenerate(): Promise<void> {
    let model = null;

    if (await this.isValid()) {
      model = this.createModel();
    }

    this.generated.emit(model);
  }

  private createModel(): FilterModel {
    const startDate = DateHelper.convertDateStructToMoment(this.startDate);
    const endDate = DateHelper.convertDateStructToMoment(this.endDate);

    return {
      startDate: DateHelper.formatMomentDate(startDate, DateFormat.Date),
      endDate: DateHelper.formatMomentDate(endDate, DateFormat.Date),
      sports: this.selectedSports.join(','),
      sites: this.selectedLicensees.join(','),
      leagueId: this.leagueId,
      pageIndex: 1,
      pageSize: 100,
      isPageChanged: false,
    };
  }

  private async isValid(): Promise<boolean> {
    if (this.selectedLicensees.length === 0) {
      this.toastService.activate(`Please select at least one licensee!`);
      return false;
    }

    if (this.selectedSports.length === 0) {
      this.toastService.activate(`Please select at least one sport!`);
      return false;
    }

    const maxDate = DateHelper.convertDateStructToMoment(this.startDate).add(3, 'month');
    if (!DateHelper.convertDateStructToMoment(this.endDate).isBefore(maxDate)) {
        this.toastService.activate(`Date range should not exceed 3 months!`);
        return false;
    }

    const test = await this.checkLeague();
    if (!test)
    {
      this.toastService.activate('League is not available.');
    }

    return true;
  }

  private async checkLeague(): Promise<boolean> {
    const searchText = this.leagueName.trim();
    if (searchText === '') {
      this.leagueId = '0';
      return true;
    } else {
      const leagues =
        await this.filterService.queryLeagueSuggestion(this.selectedSports.join(','), searchText, true).toPromise<LeagueModel[]>();
      if (leagues.length === 0)
      {
        return false;
      } else {
        this.leagueId = leagues[0].Id;
        return true;
      }
    }
  }

  private buildLeagueNameTypeaheadQuery(): TypeaheadQuery {
    return new TypeaheadQuery(term => {
      let searchText = term.replace(/,/g, '');
      let words = searchText.split(' ');
      words = words.filter(word => word.trim() !== '');
      searchText = words.join(',');
      return this.filterService.queryLeagueSuggestion(this.selectedSports.join(','), searchText, false)
        .map(list => {
          return list.map(item => item.Name);
        });
    });
  }
}
