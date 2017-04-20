import { Component } from '@angular/core';
import * as _ from 'lodash';
import { TreeviewItem } from 'ngx-treeview';
import { Grid, LiveStatus } from '../grid.model';
import { BreadcrumbFilter } from '../breadcrumb/breadcrumb.model';
import { LeagueItem, PeriodGroupItem, LeagueData } from './league-grid.model';
import { LeagueGridService } from './league-grid.service';

@Component({
    selector: 'nap-league-grid',
    templateUrl: './league-grid.component.html'
})
export class LeagueGridComponent implements Grid, BreadcrumbFilter {
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

    get hasData(): boolean {
        return !_.isNil(this.data) && this.data.Entities.length > 0;
    }

    get title(): string {
        const model = this.service.model;
        const liveStatusTitle = this.service.getLiveStatusTitle();
        return `${model.betTypeName} - ${liveStatusTitle}`;
    }

    getColumnFilter(): TreeviewItem[] {
        return this.data.GroupNames.map(groupName => new TreeviewItem({ text: groupName, value: groupName }));
    }

    filterColumns(groupNames: string[]) {
        if (this.hasData) {
            this.data.GroupNames = groupNames;
        }
    }
}
