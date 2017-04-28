import { Component } from '@angular/core';
import * as _ from 'lodash';
import { Observable } from 'rxjs/Observable';
import { DateHelper } from 'nap-components/src/date';
import { Grid } from '../grid.model';
import { FilterModelWrapper } from '../../filter/filter.model.main';
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
        return !_.isNil(this.data) && this.data.length > 0;
    }

    get title(): string {
        const filterModel = this.gridService.filterModel;
        return `Associated accounts of Punter ${this.service.model.custName}`;
    }
}
