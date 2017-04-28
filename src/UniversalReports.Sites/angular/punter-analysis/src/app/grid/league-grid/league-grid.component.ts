import { Component } from '@angular/core';
import * as _ from 'lodash';
import { Observable } from 'rxjs/Observable';
import { TreeviewItem } from 'ngx-treeview';
import { Grid, LiveStatus } from '../grid.model';
import { BreadcrumbFilter } from '../../breadcrumb/breadcrumb.model';
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

    query(): Observable<any> {
        return Observable.create(observer => {
            this.service.query().subscribe(data => {
                this.data = data;
                observer.complete();
            });
        });
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

    getFilterColumns(): string[] {
        return this.data.GroupNames;
    }

    filterColumns(selectedColumns: string[]) {
        if (this.hasData) {
            this.data.GroupNames = selectedColumns;
        }
    }
}
