import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import {
    TreeviewItem, TreeviewConfig, TreeviewEventParser,
    DownlineTreeviewEventParser, DownlineTreeviewItem
} from 'ngx-treeview';
import * as _ from 'lodash';
import * as moment from 'moment';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { ToastService } from 'nap-components/src/toast';
import { TypeaheadQuery } from 'nap-components/src/dropdown-typeahead';
import { RoleId, SortBy } from 'nap-components/src/model';
import { NgbDateStruct, NgbDate, DateHelper, DateRange } from 'nap-components/src/date';
import {
    SearchBy, PeriodType, OrderBy, FilterModel, UserFilterModel, LeagueFilterModel,
    SportsbookSportTypeBetType, isUserModel, isLeagueModel
} from './filter.model';
import { FilterService } from './filter.service';
import { PeriodTypeEventModel } from './period-type/period-type.model';

@Component({
    selector: 'nap-filter',
    templateUrl: './filter.component.html',
    styleUrls: [
        '../../../../components/src/style/filter.scss',
        './filter.component.scss'
    ],
    providers: [
        FilterService,
        { provide: TreeviewEventParser, useClass: DownlineTreeviewEventParser }
    ]
})
export class FilterComponent implements OnInit {
    @Output() generate = new EventEmitter<FilterModel>();
    @Output() reset = new EventEmitter();
    RoleId = RoleId;
    SearchBy = SearchBy;
    searchBy = SearchBy.User;
    searchByOptions = this.getSearchByOptions();
    depth = RoleId.Agent;
    depthOptions = this.getDepthOptions();
    topRows = 10;
    userName = '';
    userNameTypeaheadQuery = this.buildUserNameTypeaheadQuery();
    sortBy = SortBy.Descending;
    sortByOptions = this.getSortByOptions();
    orderBy = OrderBy.WinLoss;
    orderByOptions = this.getOrderByOptions();
    minDate: NgbDateStruct;
    maxDate: NgbDateStruct;
    productTreeviewItems: TreeviewItem[];
    productTreeviewConfig: TreeviewConfig = {
        isShowAllCheckBox: true,
        isShowCollapseExpand: true,
        isShowFilter: true,
        maxHeight: 500
    };

    sportType: number;
    sportOptions: SelectItem[];
    leagueId: number;
    leagueOptions: SelectItem[];
    betTypeTreeviewItems: TreeviewItem[];
    betTypeTreeviewConfig: TreeviewConfig = {
        isShowAllCheckBox: true,
        isShowCollapseExpand: false,
        isShowFilter: true,
        maxHeight: 500
    };

    monthRangeFromDate: NgbDateStruct;
    monthRangeToDate: NgbDateStruct;

    private selectedBetTypeTreeviewItems: DownlineTreeviewItem[];
    private periodTypeEventModel: PeriodTypeEventModel;
    private sportbooksSportTypeBetTypeData: SportsbookSportTypeBetType[];

    constructor(
        private service: FilterService,
        private toastService: ToastService
    ) {
        const todayNgbDate = NgbDate.fromToday();
        this.minDate = { year: todayNgbDate.year - 1, month: todayNgbDate.month, day: todayNgbDate.day };
        this.maxDate = todayNgbDate.toDateStruct();
    }

    get isUserNameRequired(): boolean {
        switch (this.searchBy) {
            case SearchBy.User:
                return this.depth !== RoleId.Member;
            case SearchBy.League:
                return false;
            case SearchBy.Performance:
                return true;
        }
    }

    get userNamePlaceholder(): string {
        switch (this.depth) {
            case RoleId.Super:
                return 'Super name';
            case RoleId.Master:
                return 'Master name';
            case RoleId.Agent:
                return 'Agent name';
            case RoleId.Member:
                return this.searchBy === SearchBy.User ? 'All' : 'Member name';
        }
    }

    ngOnInit() {
        this.service.queryDataWarehouseDateRange().subscribe(model => {
            this.minDate = DateHelper.convertDateToDateStruct(DateHelper.convertStringToDate(model.MinDate));
            this.maxDate = DateHelper.convertDateToDateStruct(DateHelper.convertStringToDate(model.MaxDate));
            this.monthRangeToDate = { year: this.maxDate.year, month: this.maxDate.month, day: 1 };
            let momentFromDate = DateHelper.convertDateStructToMoment(this.maxDate).subtract(5, 'months');
            const momentMinDate = DateHelper.convertDateStructToMoment(this.minDate);
            if (momentFromDate.isBefore(momentMinDate)) {
                momentFromDate = momentMinDate;
            }
            const fromDate = DateHelper.convertDateToDateStruct(momentFromDate.toDate());
            this.monthRangeFromDate = { year: fromDate.year, month: fromDate.month, day: 1 };
        });
        this.service.queryProductTreeviewItems().subscribe(treeItems => this.productTreeviewItems = treeItems);
    }

    onSearchByChange() {
        this.reset.emit();
        switch (this.searchBy) {
            case SearchBy.User:
                if (this.depth === RoleId.Super || this.depth === RoleId.Master) {
                    this.depth = RoleId.Agent;
                }
                break;
            case SearchBy.League:
                if (this.sportbooksSportTypeBetTypeData) {
                    this.loadSports();
                } else {
                    this.service.querySportbooksSportTypeBetType().subscribe(data => {
                        this.sportbooksSportTypeBetTypeData = data;
                        this.loadSports();
                    });
                }
                break;
        }
        this.depthOptions = this.getDepthOptions();
    }

    onPeriodTypeChange(model: PeriodTypeEventModel) {
        this.periodTypeEventModel = model;
        if (this.searchBy === SearchBy.League) {
            this.loadLeagues();
        }
    }

    onProductSelectedChange(downlineTreeviewItems: DownlineTreeviewItem[]) {
        this.selectedBetTypeTreeviewItems = downlineTreeviewItems;
    }

    onSportChange() {
        this.betTypeTreeviewItems = this.sportbooksSportTypeBetTypeData
            .filter(item => item.SportType === this.sportType)
            .map(item => new TreeviewItem({
                text: item.BetTypeName,
                value: item.CombinationId
            }));
        this.loadLeagues();
    }

    onBetTypeSelectedChange(downlineTreeviewItems: DownlineTreeviewItem[]) {
        this.selectedBetTypeTreeviewItems = downlineTreeviewItems;
    }

    onGenerate() {
        this.reset.emit();
        const model = this.createModel();
        if (this.validateModel(model)) {
            this.service.checkDatabaseAvailable().subscribe(isAvailable => {
                if (isAvailable) {
                    this.generate.emit(model);
                } else {
                    this.toastService.activate('Data is being processed.... Please try again after 10 minutes!');
                }
            });
        }
    }

    private loadSports() {
        if (!this.sportOptions) {
            let sportName = '';
            this.sportOptions = [];
            this.sportbooksSportTypeBetTypeData.forEach(item => {
                if (item.SportName !== sportName) {
                    sportName = item.SportName;
                    this.sportOptions.push({
                        text: item.SportName,
                        value: item.SportType
                    });
                }
            });
            this.sportType = this.sportOptions[0].value;
            this.onSportChange();
        }
    }

    private loadLeagues() {
        const dateRange = this.getExactDateRange();
        this.service.querySportTypeLeague(this.sportType, dateRange).subscribe(options => {
            this.leagueOptions = options;
            if (this.leagueOptions.length === 0) {
                this.leagueOptions.push({
                    text: 'There is no information available.',
                    value: 0
                });
            }

            this.leagueId = this.leagueOptions[0].value;
        });
    }

    private getExactDateRange(): DateRange {
        const minDate = DateHelper.convertDateStructToMoment(this.minDate);
        let fromDate = DateHelper.convertDateStructToMoment(this.periodTypeEventModel.fromDate);
        let toDate = DateHelper.convertDateStructToMoment(this.periodTypeEventModel.toDate);
        if (fromDate.isBefore(minDate)) {
            fromDate = moment.utc(minDate);
        }
        switch (this.periodTypeEventModel.periodType) {
            case PeriodType.Weekly:
                toDate = toDate.endOf('week');
                break;
            case PeriodType.Monthly:
            case PeriodType.MonthRange:
                toDate = toDate.endOf('month');
                break;
            case PeriodType.Annually:
                toDate = toDate.endOf('year');
                break;
        }

        const maxDate = DateHelper.convertDateStructToMoment(this.maxDate);
        if (toDate.isAfter(maxDate)) {
            toDate = maxDate;
        }
        if (fromDate.isAfter(toDate)) {
            fromDate = moment.utc(toDate);
        }
        return {
            fromDate: DateHelper.convertDateToDateStruct(fromDate.toDate()),
            toDate: DateHelper.convertDateToDateStruct(toDate.toDate())
        };
    }

    private validateModel(model: FilterModel): boolean {
        if (this.searchBy !== SearchBy.Performance) {
            if (model.periodType === PeriodType.Daily || model.periodType === PeriodType.Weekly) {
                const momentFromDate = DateHelper.convertDateStructToMoment(model.fromDate);
                const momentToDate = DateHelper.convertDateStructToMoment(model.toDate);
                if (momentFromDate.add(1, 'month').isBefore(momentToDate)) {
                    this.toastService.activate('Date range should not exceed 1 month!');
                    return false;
                }
            }
        }

        if (isUserModel(model) && this.isUserNameRequired && model.userName === '') {
            this.toastService.activate('Account name field is required!');
            return false;
        }

        if (isUserModel(model)) {
            if (model.selectedBetTypeTreeviewItems.length === 0) {
                this.toastService.activate('Please select at least one Product!');
                return false;
            }
        }

        if (isLeagueModel(model)) {
            if (model.selectedBetTypeTreeviewItems.length === 0) {
                this.toastService.activate('Please select at least one Bet Type!');
                return false;
            }

            if (model.leagueId === 0) {
                this.toastService.activate('There is no league available!');
                return false;
            }
        }

        return true;
    }

    private buildUserNameTypeaheadQuery(): TypeaheadQuery {
        return new TypeaheadQuery(term => {
            return this.service.queryUserNameSuggestion(term, this.depth);
        });
    }

    private createModel(): FilterModel {
        switch (this.searchBy) {
            case SearchBy.User:
                return this.createUserModel();
            case SearchBy.League:
                return this.createLeagueModel();
        }
    }

    private createUserModel(): UserFilterModel {
        return {
            searchBy: this.searchBy,
            searchByOptions: this.searchByOptions,
            topRow: this.topRows,
            orderBy: this.orderBy,
            orderByOptions: this.orderByOptions,
            sortBy: this.sortBy,
            sortByOptions: this.sortByOptions,
            periodType: this.periodTypeEventModel.periodType,
            fromDate: this.periodTypeEventModel.fromDate,
            toDate: this.periodTypeEventModel.toDate,
            selectedBetTypeTreeviewItems: this.selectedBetTypeTreeviewItems,
            depth: this.depth,
            depthOptions: this.depthOptions,
            userName: _.trim(this.userName)
        };
    }

    private createLeagueModel(): LeagueFilterModel {
        return {
            searchBy: this.searchBy,
            searchByOptions: this.searchByOptions,
            topRow: this.topRows,
            orderBy: this.orderBy,
            orderByOptions: this.orderByOptions,
            sortBy: this.sortBy,
            sortByOptions: this.sortByOptions,
            periodType: this.periodTypeEventModel.periodType,
            fromDate: this.periodTypeEventModel.fromDate,
            toDate: this.periodTypeEventModel.toDate,
            selectedBetTypeTreeviewItems: this.selectedBetTypeTreeviewItems,
            leagueId: this.leagueId,
            leagueOptions: this.leagueOptions,
            sportType: this.sportType,
            sportOptions: this.sportOptions
        };
    }

    private getSearchByOptions(): SelectItem[] {
        return [{
            text: 'User',
            value: SearchBy.User
        }, {
            text: 'League',
            value: SearchBy.League
        }, {
            text: 'Performance',
            value: SearchBy.Performance
        }];
    }

    private getDepthOptions(): SelectItem[] {
        let result: SelectItem[] = [{
            text: 'Agent',
            value: RoleId.Agent
        }, {
            text: 'Member',
            value: RoleId.Member
        }];
        if (this.searchBy === SearchBy.Performance) {
            const list: SelectItem[] = [{
                text: 'Super',
                value: RoleId.Super
            }, {
                text: 'Master',
                value: RoleId.Master
            }];
            result = _.concat(list, result);
        }
        return result;
    }

    private getSortByOptions(): SelectItem[] {
        return [{
            text: 'Ascending',
            value: SortBy.Ascending
        }, {
            text: 'Descending',
            value: SortBy.Descending
        }];
    }

    private getOrderByOptions(): SelectItem[] {
        return [{
            text: 'Win Loss',
            value: OrderBy.WinLoss
        }, {
            text: 'Turnover',
            value: OrderBy.Turnover
        }, {
            text: 'Margin',
            value: OrderBy.Margin
        }];
    }
}
