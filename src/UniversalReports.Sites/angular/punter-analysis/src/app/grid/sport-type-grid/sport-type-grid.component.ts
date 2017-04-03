import { Component } from '@angular/core';
import * as _ from 'lodash';
import { GridService } from '../grid.service';
import { Grid, GridType } from '../grid.model';
import { BetCountGridService } from '../bet-count-grid/bet-count-grid.service';
import { BetTypeGridService } from '../bet-type-grid/bet-type-grid.service';
import { SportTypeData, SportTypeItem } from './sport-type-grid.model';
import { SportTypeGridService } from './sport-type-grid.service';

@Component({
    selector: 'nap-sport-type-grid',
    templateUrl: './sport-type-grid.component.html'
})
export class SportTypeGridComponent implements Grid {
    data: SportTypeData;

    constructor(
        private gridService: GridService,
        private service: SportTypeGridService,
        private betCountGridService: BetCountGridService,
        private betTypeGridService: BetTypeGridService
    ) { }

    query() {
        this.service.query().subscribe(data => this.data = data);
    }

    exportExcel() {

    }

    get hasExcel(): boolean {
        return !_.isNil(this.data) && this.data.Entities.length > 0;
    }

    get title(): string {
        return 'Main - Punter Analysis';
    }

    private onShowBetType(sportId: number) {
        this.betTypeGridService.model = this.service.createBetTypeGridModel(sportId);
        this.gridService.showGrid(GridType.BetType);
    }

    private onShowBetCount(sportId: number): void {
        this.betCountGridService.model = this.service.createBetCountGridModel(sportId);
        this.gridService.showGrid(GridType.BetCount);
    }
}
