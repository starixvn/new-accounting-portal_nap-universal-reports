import { Component, Input, OnInit, OnChanges } from '@angular/core';
import * as _ from 'lodash';
import { PaginationInstance } from 'ng2-pagination';
import { Helper } from '../../components/helper';
import { FilterModel } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { Grid, GridType } from '../grid.model';
import { SummaryData, SummaryItem } from './summary-grid.model'
import { SummaryGridService } from './summary-grid.service';
import { BetCountGridService } from '../bet-count-grid/bet-count-grid.service';
import { AssociatedAccountGridService } from '../associated-account-grid/associated-account-grid.service';
import { SportTypeGridService } from '../sport-type-grid/sport-type-grid.service';

@Component({
    selector: 'nap-summary-grid',
    templateUrl: './summary-grid.component.html'
})
export class SummaryGridComponent implements Grid {
    @Input() filterModel: FilterModel;
    config: PaginationInstance;
    data: SummaryData;

    constructor(
        private gridService: GridService,
        private service: SummaryGridService,
        private betCountGridService: BetCountGridService,
        private associatedAccountGridService: AssociatedAccountGridService,
        private sportTypeGridService: SportTypeGridService
    ) { }

    query() {
        this.service.query().subscribe(data => {
            this.data = data;
            this.config = {
                id: 'custom',
                itemsPerPage: 100,
                currentPage: 1,
                totalItems: this.data.Entities.length
            };
        });
    }

    excel() {
        this.service.excel().subscribe(response => {
            Helper.saveExcel(response, 'test.xls');
        });
    }

    get hasExcel(): boolean {
        return true;
    }

    get title(): string {
        if (this.gridService.activeGrid === this) {
            return 'Main - Punter Analysis';
        } else {
            return 'Main';
        }
    }

    private onShowSportType(custId: number) {
        this.sportTypeGridService.model = this.service.createSportTypeGridModel(custId);
        this.gridService.showGrid(GridType.SportType);
    }

    private onShowBetCount(custId: number): void {
        this.betCountGridService.model = this.service.createBetCountGridModel(custId);
        this.gridService.showGrid(GridType.BetCount);
    }

    private onShowAssociatedAccount(custId: number, userName: string): void {
        this.associatedAccountGridService.model = this.service.createAssociatedAccountGridModel(custId, userName);
        this.gridService.showGrid(GridType.AssociatedAccount);
    }
}
