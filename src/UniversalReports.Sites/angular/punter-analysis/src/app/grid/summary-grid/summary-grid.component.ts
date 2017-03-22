import { Component } from '@angular/core';
import { ViewModelItem, SummaryItem } from './summary-grid.model'
import { PagingModel, PagingEvent } from '../../../../../components/src/paging/paging.model'

@Component({
    selector: 'nap-summary-grid',
    templateUrl: './summary-grid.component.html',
    styleUrls: [
        './summary-grid.component.scss',
        '../grid.scss'
    ]
})
export class SummaryGridComponent {
    private viewModelItem: ViewModelItem;
    private showingItems: SummaryItem[];
    private pagingModel: PagingModel;

    constructor() {
        this.viewModelItem = this.createFakeData();
        this.pagingModel = {
            totalItems: this.viewModelItem.Entities.length,
            pageSize: 50,
            pageIndex: 0
        };

        this.showSummaryItems(0, 50);
    }

    private onShowSportType(custId: number) {
        alert(custId);
    }

    private onShowBetCount(custId: number): void {
        alert(custId);
    }

    private onShowAssociatedAccount(custId: number): void {
        alert(custId);
    }

    private changePagingEvent(pagingEvent: PagingEvent) {
        this.showSummaryItems(pagingEvent.pageIndex, pagingEvent.pageSize);
    }

    private showSummaryItems(pageIndex: number, pageSize: number) {
        var begin = pageIndex * pageSize;
        var end = (pageIndex + 1) * pageSize + 1;
        this.showingItems = this.viewModelItem.Entities.slice(begin, end);
    }

    private createFakeData(): ViewModelItem {
        let entities: SummaryItem[] = [];
        for (var i = 0; i < 500; i++) {
            let summaryItem: SummaryItem = {
                Username: "Username " + i,
                WinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                Turnover: i % 5 == 0 ? 0 : 10321324.235323 + i,
                Margin: (i % 2 == 0) ? 0.0341232 : 0.1341554,
                BetCount: 1321310 + i,
                CustId: 1 + i
            };
            entities.push(summaryItem);
        }

        return {
            Entities: entities,
            Total: {
                Username: "",
                WinLoss: -13281.321356 + i,
                Turnover: 10321324.235323,
                Margin: 0.0341232,
                BetCount: 1321310,
                CustId: 0
            }
        };
    }
}