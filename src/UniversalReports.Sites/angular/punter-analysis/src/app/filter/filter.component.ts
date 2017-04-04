import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import {
    TreeviewItem, TreeviewConfig, TreeviewEventParser,
    DownlineTreeviewEventParser, DownlineTreeviewItem
} from 'ng2-dropdown-treeview';
import * as _ from 'lodash';
import * as moment from 'moment';
import { ToastService } from 'nap-components/src/toast';
import { OptionItem, RoleId, SortBy } from 'nap-components/src/model';
import { NgbDateStruct, NgbDate, DateHelper } from 'nap-components/src/date';
import { SearchBy, PeriodType, OrderBy, FilterModel } from './filter.model';
import { FilterService } from './filter.service';
import { PeriodTypeEventModel } from './period-type/period-type.model';
import { TypeaheadQuery } from '../components/dropdown-typeahead';

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
    private selectedBetTypeTreeviewItems: DownlineTreeviewItem[];
    private periodTypeEventModel: PeriodTypeEventModel;

    constructor(
        private service: FilterService,
        private toastService: ToastService
    ) {
        const todayNgbDate = NgbDate.fromToday();
        this.minDate = { year: todayNgbDate.year - 1, month: todayNgbDate.month, day: todayNgbDate.day };
        this.maxDate = todayNgbDate.toDateStruct();
    }

    ngOnInit() {
        this.service.queryDataWarehouseDateRange().subscribe(model => {
            this.minDate = DateHelper.convertDateToDateStruct(DateHelper.convertStringToDate(model.MinDate));
            this.maxDate = DateHelper.convertDateToDateStruct(DateHelper.convertStringToDate(model.MaxDate));
        });
        this.service.queryProductTreeviewItems().subscribe(treeItems => this.productTreeviewItems = treeItems);
    }

    onPeriodTypeChange(model: PeriodTypeEventModel) {
        this.periodTypeEventModel = model;
    }

    onProductSelectedChange(downlineTreeviewItems: DownlineTreeviewItem[]) {
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

    private validateModel(model: FilterModel): boolean {
        if (model.periodType === PeriodType.Daily || model.periodType === PeriodType.Weekly) {
            const momentFromDate = DateHelper.convertDateStructToMoment(model.fromDate);
            const momentToDate = DateHelper.convertDateStructToMoment(model.toDate);
            if (momentFromDate.add(1, 'month').isBefore(momentToDate)) {
                this.toastService.activate('Date range should not exceed 1 month!');
                return false;
            }
        } else if (model.periodType === PeriodType.MonthRange) {
            const momentFromDate = DateHelper.convertDateStructToMoment(model.fromDate);
            const momentToDate = DateHelper.convertDateStructToMoment(model.toDate);
            if (momentFromDate.add(1, 'year').isBefore(momentToDate)) {
                this.toastService.activate('Date range should not exceed 1 year!');
                return false;
            }
        }

        if (model.userName === '') {
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

    private getSearchByOptions(): OptionItem[] {
        return [{
            text: 'User',
            value: SearchBy.User
        }/*, {
            text: 'League',
            value: SearchBy.League
        }, {
            text: 'Performance',
            value: SearchBy.Performance
        }*/];
    }

    private getDepthOptions(): OptionItem[] {
        return [{
            text: 'Agent',
            value: RoleId.Agent
        }, {
            text: 'Member',
            value: RoleId.Member
        }];
    }

    private getSortByOptions(): OptionItem[] {
        return [{
            text: 'Ascending',
            value: SortBy.Ascending
        }, {
            text: 'Descending',
            value: SortBy.Descending
        }];
    }

    private getOrderByOptions(): OptionItem[] {
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
