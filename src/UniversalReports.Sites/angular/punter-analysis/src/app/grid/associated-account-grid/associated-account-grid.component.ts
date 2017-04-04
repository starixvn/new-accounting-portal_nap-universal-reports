import { Component } from '@angular/core';
import * as _ from 'lodash';
import { DateHelper } from 'nap-components/src/date';
import { Grid } from '../grid.model';
import { FilterModelWrapper } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { UserRoleItem } from './associated-account-grid.model';
import { AssociatedAccountGridService } from './associated-account-grid.service';

@Component({
    selector: 'nap-associated-account-grid',
    templateUrl: './associated-account-grid.component.html'
})
export class AssociatedAccountGridComponent implements Grid {
    data: UserRoleItem[];

    constructor(
        private gridService: GridService,
        private service: AssociatedAccountGridService
    ) { }

    query() {
        this.service.query().subscribe(data => this.data = data);
    }

    exportExcel() {
        this.service.exportExcel();
    }

    get hasExcel(): boolean {
        return !_.isNil(this.data) && this.data.length > 0;
    }

    get title(): string {
        const filterModel = this.gridService.filterModel;
        return `Associated accounts of Punter ${this.service.model.custName} ${this.getDateFromToTitle()}`;
    }

    private getDateFromToTitle(): string {
        const filterModel = this.gridService.filterModel;
        const momentFromDate = DateHelper.convertDateStructToMoment(filterModel.fromDate);
        const momentToDate = DateHelper.convertDateStructToMoment(filterModel.toDate);
        const dateFormat = 'MM/DD/YYYY';
        const fromDateString = momentFromDate.format(dateFormat);
        const toDateString = momentToDate.format(dateFormat);
        return `from ${fromDateString} to ${toDateString}`;
    }
}
