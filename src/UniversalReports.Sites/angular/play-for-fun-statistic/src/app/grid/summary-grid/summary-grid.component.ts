import { Component, Input, OnInit, OnChanges } from '@angular/core';
import * as _ from 'lodash';
import * as moment from 'moment';
import { DateHelper } from 'nap-components/src/date';
import { FilterModelWrapper } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { Grid, GridType } from '../grid.model';
import { SummaryData } from './summary-grid.model';
import { SummaryGridService } from './summary-grid.service';
import { DetailGridService } from '../detail-grid/detail-grid.service';

@Component({
    selector: 'nap-summary-grid',
    templateUrl: './summary-grid.component.html'
})
export class SummaryGridComponent implements Grid {
    data: SummaryData;

    constructor(
        private gridService: GridService,
        private service: SummaryGridService,
        private detailGridService: DetailGridService
    ) { }

    query() {
        this.service.query().subscribe(data => this.data = data);
    }

    exportExcel() {
        this.service.exportExcel();
    }

    get hasExcel(): boolean {
        return this.hasData;
    }

    get hasData(): boolean {
        return !_.isNil(this.data) && this.data.Entities.length > 0;
    }

    get title(): string {
        const filterModelWrapper = new FilterModelWrapper(this.gridService.filterModel);
        return `Play For Fun Statistics ${filterModelWrapper.dateFromToTitle}`;
    }

    showDate(date: string) {
        this.detailGridService.model = {
            Date: DateHelper.convertDateToDateStruct(new Date(date))
        };
        this.gridService.generate(GridType.Detail);
    }
}
