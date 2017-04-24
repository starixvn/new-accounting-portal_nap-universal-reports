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
import { NgbDateStruct, NgbDate, DateHelper } from 'nap-components/src/date';
import { SearchBy, PeriodType, OrderBy, FilterModel, SportsbookSportTypeBetType } from './filter.model';
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

    periodOptions = this.getPeriodOptions();
    period = 6;

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

    get userNamePlaceholder(): string {
        switch (this.depth) {
            case RoleId.Super:
                return 'Super name';
            case RoleId.Master:
                return 'Master name';
            case RoleId.Agent:
                return 'Agent name';
            case RoleId.Member:
                return 'All';
        }
    }

    ngOnInit() {
        this.service.queryDataWarehouseDateRange().subscribe(model => {
            this.minDate = DateHelper.convertDateToDateStruct(DateHelper.convertStringToDate(model.MinDate));
            this.maxDate = DateHelper.convertDateToDateStruct(DateHelper.convertStringToDate(model.MaxDate));
        });
        this.service.queryProductTreeviewItems().subscribe(treeItems => this.productTreeviewItems = treeItems);
    }

    onSearchByChange() {
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
        this.service.querySportTypeLeague(this.sportType).subscribe(options => {
            this.leagueOptions = options;
            this.leagueId = this.leagueOptions[0].value;
        });
    }

    onBetTypeSelectedChange() {

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

    private validateModel(model: FilterModel): boolean {
        if (model.periodType === PeriodType.Daily || model.periodType === PeriodType.Weekly) {
            const momentFromDate = DateHelper.convertDateStructToMoment(model.fromDate);
            const momentToDate = DateHelper.convertDateStructToMoment(model.toDate);
            if (momentFromDate.add(1, 'month').isBefore(momentToDate)) {
                this.toastService.activate('Date range should not exceed 1 month!');
                return false;
            }
        }

        if (model.depth === RoleId.Agent && model.userName === '') {
            this.toastService.activate('Account name field is required!');
            return false;
        }

        if (model.selectedBetTypeTreeviewItems.length === 0) {
            this.toastService.activate('Please select at least one Product!');
            return false;
        }

        return true;
    }

    private buildUserNameTypeaheadQuery(): TypeaheadQuery {
        return new TypeaheadQuery(term => {
            return this.service.queryUserNameSuggestion(term, this.depth);
        });
    }

    private createModel(): FilterModel {
        return {
            searchBy: this.searchBy,
            topRow: this.topRows,
            orderBy: this.orderBy,
            sortBy: this.sortBy,
            periodType: this.periodTypeEventModel.periodType,
            fromDate: this.periodTypeEventModel.fromDate,
            toDate: this.periodTypeEventModel.toDate,
            depth: this.depth,
            userName: _.trim(this.userName),
            selectedBetTypeTreeviewItems: this.selectedBetTypeTreeviewItems,
            searchByOptions: this.searchByOptions,
            depthOptions: this.depthOptions,
            orderByOptions: this.orderByOptions,
            sortByOptions: this.sortByOptions
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

    private getPeriodOptions(): SelectItem[] {
        const options: SelectItem[] = [];
        for (let i = 1; i <= 12; i++) {
            options.push({
                text: `${i} ${i > 1 ? 'months' : 'month'}`,
                value: i
            });
        }
        return options;
    }
}
