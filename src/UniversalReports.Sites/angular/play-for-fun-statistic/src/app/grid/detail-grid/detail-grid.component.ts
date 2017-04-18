import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { PaginationInstance } from 'ng2-pagination';
import { DateHelper, DateFormat } from 'nap-components/src/date';
import * as _ from 'lodash';
import { GridService } from '../grid.service';
import { Grid, GridType } from '../grid.model';
import { DetailData } from './detail-grid.model';
import { DetailGridService } from './detail-grid.service';

@Component({
    selector: 'nap-detail-grid',
    templateUrl: './detail-grid.component.html'
})
export class DetailGridComponent implements Grid {
    config: PaginationInstance;
    data: DetailData;

    constructor(
        private gridService: GridService,
        private service: DetailGridService
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

    exportExcel() { }

    get hasData(): boolean {
        return false;
    }

    get title(): string {
        const model = this.service.model;
        const dateString = DateHelper.formatDateStruct(model.Date, DateFormat.Date);
        return `Play For Fun On ${dateString}`;
    }
}
