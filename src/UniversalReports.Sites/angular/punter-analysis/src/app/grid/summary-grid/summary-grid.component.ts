import { Component, Input, OnChanges } from '@angular/core';
import * as _ from 'lodash';
import { SummaryData, SummaryItem } from './summary-grid.model'
import { PagingModel, PagingEvent } from '../../../../../components/src/paging/paging.model'

@Component({
    selector: 'nap-summary-grid',
    templateUrl: './summary-grid.component.html',
    styleUrls: [
        './summary-grid.component.scss',
        '../grid.scss'
    ]
})
export class SummaryGridComponent implements OnChanges {
    @Input() data: SummaryData;
    items: SummaryItem[] = [];
    pagingModel: PagingModel;

    ngOnChanges() {
        if (!_.isNil(this.data)) {
            this.pagingModel = {
                totalItems: this.data.Entities.length,
                pageSize: 50,
                pageIndex: 0
            };
            this.showSummaryItems(0, 50);
        }
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
        this.items = _.slice(this.data.Entities, begin, end);
    }
}
