import { Component, Output, EventEmitter } from '@angular/core';
import { TreeviewItem, TreeviewConfig } from 'ng2-dropdown-treeview';
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
        FilterService
    ]
})
export class FilterComponent {
    @Output() generate = new EventEmitter<FilterModel>();
    RoleId = RoleId;
    searchBy = SearchBy.User;
    searchByOptions = this.getSearchByOptions();
    depth = RoleId.Agent;
    depthOptions = this.getDepthOptions();
    topRows = 10;
    userName = '';
    userNameTypeaheadQuery = this.buildUserNameTypeaheadQuery();
    order = SortBy.Descending;
    orderOptions = this.getOrderOptions();
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
    private productBetTypes: number[];
    private periodTypeEventModel: PeriodTypeEventModel;

    constructor(
        private service: FilterService
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

    onProductSelectedChange(productBetTypes: number[]) {
        this.productBetTypes = productBetTypes;
    }

    onGenerate() {
        const model = this.createModel();
        this.generate.emit(model);
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
            sortBy: this.order,
            periodType: this.periodTypeEventModel.periodType,
            fromDate: this.periodTypeEventModel.fromDate,
            toDate: this.periodTypeEventModel.toDate,
            depth: this.depth,
            userName: this.userName,
            productBetTypes: this.productBetTypes
        }
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

    private getOrderOptions(): OptionItem[] {
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
