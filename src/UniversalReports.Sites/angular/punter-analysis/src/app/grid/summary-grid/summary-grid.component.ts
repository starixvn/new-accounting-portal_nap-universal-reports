import { Component, Input, OnChanges } from '@angular/core';
import * as _ from 'lodash';
import { PaginationInstance } from 'ng2-pagination';
import { SummaryData, SummaryItem } from './summary-grid.model'

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
    config: PaginationInstance;

    ngOnChanges() {
        if (!_.isNil(this.data)) {
            this.config = {
                id: 'custom',
                itemsPerPage: 100,
                currentPage: 1,
                totalItems: this.data.Entities.length
            };
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
}
