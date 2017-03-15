import { Component } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { OptionItem } from 'nap-components/src/model';
import { SearchBy, PeriodType, Role, Order, OrderBy } from './filter.model';
import { FilterService } from './filter.service';

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
    minDate: NgbDateStruct = { year: 2015, month: 4, day: 1 };
    maxDate: NgbDateStruct = { year: 2017, month: 9, day: 30 };

    constructor(
        private service: FilterService
    ) { }

    ngOnInit() {
        this.service.queryDataWarehouseDateRange().subscribe(model => {

        });
    }

    generate() {
        console.log(this.searchBy);
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
