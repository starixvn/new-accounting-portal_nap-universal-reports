import { Component, Input } from '@angular/core';
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
export class SummaryGridComponent {
    @Input() data: SummaryData;
    config: PaginationInstance = {
        id: 'custom',
        itemsPerPage: 10,
        currentPage: 1
    };

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
