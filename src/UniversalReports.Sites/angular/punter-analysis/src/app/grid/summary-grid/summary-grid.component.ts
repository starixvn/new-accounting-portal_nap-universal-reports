import { Component } from '@angular/core';
import { SummaryItem } from './summary-grid.model'
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
    private summaryItems: SummaryItem[];
    private showingItems: SummaryItem[];
    private rowCount: number;
    private pagingModel: PagingModel;

    constructor() {
        this.summaryItems = [];
        this.rowCount = 5;
        this.pagingModel = {
            totalItems: this.rowCount,
            pageSize: 50,
            pageIndex: 0
        };

        for (var i = 0; i < this.rowCount; i++) {
            let summaryItem: SummaryItem = {
                Username: "Username " + i,
                WinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                Turnover: i % 5 == 0 ? 0 : 10321324.235323 + i,
                Margin: (i % 2 == 0) ? 0.0341232 : 0.1341554,
                BetCount: 1321310 + i,
                CustId: 1 + i
            };
            this.summaryItems.push(summaryItem);
        }

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
        this.showingItems = this.summaryItems.slice(begin, end);
    }
}