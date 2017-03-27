import { Component, Input } from '@angular/core';
import { PaginationInstance } from 'ng2-pagination';

@Component({
    selector: 'nap-pagination',
    templateUrl: './pagination.component.html',
    styleUrls: [
        './pagination.component.scss'
    ]
})
export class PaginationComponent {
    @Input() config: PaginationInstance = {
        id: 'custom',
        itemsPerPage: 100,
        currentPage: 1,
        totalItems: 0
    };
    pageSizes = [50, 100, 200, 500];

    get startIndex(): number {
        return (this.config.currentPage - 1) * this.config.itemsPerPage + 1;
    }

    get endIndex(): number {
        return Math.min(this.config.currentPage * this.config.itemsPerPage, this.config.totalItems);
    }
}
