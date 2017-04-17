import { Component, Input, OnInit, OnChanges } from '@angular/core';
import * as _ from 'lodash';
import { GridService } from '../grid.service';
import { Grid, GridType } from '../grid.model';
import { SummaryData } from './summary-grid.model';
import { SummaryGridService } from './summary-grid.service';

@Component({
    selector: 'nap-summary-grid',
    templateUrl: './summary-grid.component.html'
})
export class SummaryGridComponent implements Grid {
    data: SummaryData;

    constructor(
        private gridService: GridService,
        private service: SummaryGridService
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
        return 'Play For Fun Statistics From';
    }
}
