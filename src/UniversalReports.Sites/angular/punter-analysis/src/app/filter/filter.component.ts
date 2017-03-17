import { Component } from '@angular/core';
import { OptionItem } from 'nap-components/src/model';
import { SearchBy, PeriodType, Role, Order, OrderBy, FilterModel } from './filter.model';
import { FilterService } from './filter.service';
import { NgbDateStruct, NgbDate, PeriodTypeEventModel } from './period-type/period-type.model';

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
    Role = Role;
    searchBy = SearchBy.User;
    searchByOptions = this.getSearchByOptions();
    depth = Role.Agent;
    depthOptions = this.getDepthOptions();
    topRows = 10;
    userName = '';
    order = Order.Descending;
    orderOptions = this.getOrderOptions();
    orderBy = OrderBy.WinLoss;
    orderByOptions = this.getOrderByOptions();
    minDate: NgbDateStruct;
    maxDate: NgbDateStruct;
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

        });
    }

    onPeriodTypeChange(model: PeriodTypeEventModel) {
        this.periodTypeEventModel = model;
    }

    generate() {
        console.log(this.searchBy);
    }

    private createModel(): FilterModel {
        return {
            searchBy: this.searchBy,
            topRows: this.topRows,
            orderBy: this.orderBy,
            order: this.order,
            periodType: this.periodTypeEventModel.periodType,
            fromDate: this.periodTypeEventModel.fromDate,
            toDate: this.periodTypeEventModel.toDate,
            depth: this.depth,
            userName: this.userName
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
            value: Role.Agent
        }, {
            text: 'Member',
            value: Role.Member
        }];
    }

    private getOrderOptions(): OptionItem[] {
        return [{
            text: 'Ascending',
            value: Order.Ascending
        }, {
            text: 'Descending',
            value: Order.Descending
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
