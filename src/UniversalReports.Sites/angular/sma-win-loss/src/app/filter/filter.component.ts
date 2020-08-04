import { TreeviewConfig, DropdownTreeviewComponent } from 'ngx-treeview';
import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { SelectItem, FilterModel, Currency, Sport, Site } from './filter.model';
import { NapDateStruct, DateHelper } from 'nap-components/date';
import { CONFIG } from '../common/config';
import { FilterService } from './fiter.service';
import { TypeaheadQuery } from 'nap-components/dropdown-typeahead';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss'],
  providers: [FilterService]
})
export class FilterComponent implements OnInit {
  @ViewChild('currencyDropdownTreeview') currencyDropdownTreeview: DropdownTreeviewComponent;
  @ViewChild('siteDropdownTreeview') siteDropdownTreeview: DropdownTreeviewComponent;
  @Output() generated = new EventEmitter<FilterModel>();
  today: NapDateStruct = DateHelper.convertMomentToDateStruct(CONFIG.date.today);
  yearOptions: SelectItem[] = [];
  yearSelected: SelectItem;
  username = '';
  betTypeOptions: SelectItem[] = [
    new SelectItem('All', 0),
    new SelectItem('Virtual Rate', 1)
  ];
  currencyTreeviewConfig = TreeviewConfig.create({
    hasFilter: true,
    hasAllCheckBox: true,
    hasCollapseExpand: false,
    maxHeight: 500
  });
  selectedCurrencies: number[] = [];
  betTypeSelected: SelectItem = null;
  currencies: Currency[] = [];
  levelOptions: SelectItem[] = [
    new SelectItem('Super', 4),
    new SelectItem('Master', 3),
    new SelectItem('Agent', 2),
    new SelectItem('N/A', -1)
  ];
  levelSelected: SelectItem = null;
  isSearchDownlines = false;
  sportTreeviewConfig = TreeviewConfig.create({
    hasFilter: true,
    hasAllCheckBox: true,
    hasCollapseExpand: false,
    maxHeight: 500
  });
  selectedSports: string[] = [];
  sports: Sport[] = [];
  siteTreeviewConfig = TreeviewConfig.create({
    hasFilter: true,
    hasAllCheckBox: true,
    hasCollapseExpand: false,
    maxHeight: 500
  });
  selectedSites: number[] = [];
  sites: Site[] = [];
  leagueName = '';
  leagueTypeaheadQuery = this.buildLeagueTypeaheadQuery();
  isGenerated = false;
  isEnableSearchExactly = false;

  constructor(private readonly filterService: FilterService) { }

  ngOnInit() {
    this.getYear();
    this.getCurrency();
    this.getSite();
    this.getSport();
    this.yearSelected = this.yearOptions[0];
    this.betTypeSelected = this.betTypeOptions[0];
    this.levelSelected = this.levelOptions[0];
  }

  onGenerateClick() {
    this.isGenerated = true;
    this.OnGenerate(this.isGenerated);
  }

  onLevelSelected($event) {
   this.levelSelected = $event;
   this.isEnableSearchExactly = $event.Value === -1;
  }

  private getCurrency() {
    this.filterService.getCurrency().subscribe(currencies => this.currencies = currencies);
  }

  private getSport() {
    this.filterService.getSport().subscribe(sports => this.sports = sports);
  }

  private getSite() {
    this.filterService.getSite().subscribe(sites => this.sites = sites);
  }


  private getYear() {
    for (let i = 2020; i <= this.today.year; i++) {
      this.yearOptions.push(new SelectItem(i.toString(), i));
    }
  }

  private OnGenerate(isGenerated: boolean) {
    let leagueIds = '';
    const sports = this.selectedSports.join(',');
    const searchText = this.leagueName.trim();
    this.filterService.getLeagueGroup(sports, searchText, true).subscribe(leagues => {
      leagueIds = leagues[0] === null ? '' : leagues[0];
      const model = this.createModel(isGenerated, leagueIds);
      this.generated.emit(model);
    });
  }

  private createModel(isGenerated: boolean, leagueIds: string): FilterModel {
    const model: FilterModel = {
      year: this.yearSelected.Value,
      custLevel: this.levelSelected.Value,
      username: this.username,
      isDownline: this.isSearchDownlines,
      currencies: this.selectedCurrencies.join(','),
      isAppliedVR: this.betTypeSelected.Value,
      pageSize: 1000,
      pageIndex: 0,
      sports: this.selectedSports.join(','),
      leagueIds,
      divisions: this.selectedSites.join(','),
      isGenerated,
      isPageChanged: false
    };

    return model;
  }

  private buildLeagueTypeaheadQuery(): TypeaheadQuery {
    return new TypeaheadQuery(term => {
      let searchText = term.replace(/,/g, '');
      let words = searchText.split(' ');
      words = words.filter(word => word.trim() !== '');
      searchText = words.join(',');
      const suggestResult = this.filterService.getLeagueGroup(this.selectedSports.join(','), searchText, false)
        .map(list => {
          return list.map(item => item);
        });

      return suggestResult;
    });
  }
}
