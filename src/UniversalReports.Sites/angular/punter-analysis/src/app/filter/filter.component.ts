import { Component } from '@angular/core';
import { SearchBy, OptionItem, PeriodType, Role, Order, OrderBy } from './filter.model';

@Component({
    selector: 'nap-filter',
    templateUrl: './filter.component.html',
    styleUrls: [
        '../../../../components/src/style/filter.scss',
        './filter.component.scss'
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
