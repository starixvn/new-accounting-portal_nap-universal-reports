import { Component } from '@angular/core';
import * as _ from 'lodash';
import { Grid, LiveStatus } from '../grid.model';
import { LeagueItem, PeriodGroupItem, LeagueData } from './league-grid.model';
import { LeagueGridService } from './league-grid.service';

@Component({
    selector: 'nap-league-grid',
    templateUrl: './league-grid.component.html'
})
export class LeagueGridComponent implements Grid {
    data: LeagueData;

    constructor(
        private service: LeagueGridService
    ) { }

    query() {
        this.service.query().subscribe(data => this.data = data);
    }

    exportExcel() {
        this.service.exportExcel();
    }

    get hasExcel(): boolean {
        return !_.isNil(this.data) && this.data.Entities.length > 0;
    }

    get title(): string {
        const model = this.service.model;
        let liveStatusTitle = this.service.getLiveStatusTitle();
        return `${model.betTypeName} - ${liveStatusTitle}`;
    }
}
