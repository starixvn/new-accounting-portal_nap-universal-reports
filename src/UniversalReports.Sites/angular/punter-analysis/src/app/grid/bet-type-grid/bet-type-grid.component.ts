import { Component } from '@angular/core';
import { Grid } from '../grid.model';
import { BetTypeData, BetTypeItem, ProductHasLeague } from './bet-type-grid.model';
import { BetTypeGridService } from './bet-type-grid.service';

@Component({
    selector: 'nap-bet-type-grid',
    templateUrl: './bet-type-grid.component.html'
})
export class BetTypeGridComponent implements Grid {
    data: BetTypeData;
    private productId: number;

    constructor(
        private service: BetTypeGridService
    ) {
        this.productId = 1;
    }

    query() {
        this.service.query().subscribe(data => this.data = data);
    }

    exportExcel() {

    }

    get hasExcel(): boolean {
        return true;
    }

    get title(): string {
        return 'Main - Punter Analysis';
    }
}
