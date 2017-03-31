import { Component } from '@angular/core';
import * as moment from 'moment';
import { Grid } from '../grid.model';
import { UserRoleItem } from './associated-account-grid.model';
import { AssociatedAccountGridService } from './associated-account-grid.service';

@Component({
    selector: 'nap-associated-account-grid',
    templateUrl: './associated-account-grid.component.html'
})
export class AssociatedAccountGridComponent implements Grid {
    private data: UserRoleItem[];

    constructor(
        private service: AssociatedAccountGridService
    ) { }

    query() {
        this.service.query().subscribe(data => this.data = data);
    }

    excel() {

    }

    get hasExcel(): boolean {
        return true;
    }

    get title(): string {
        return 'Main - Punter Analysis';
    }
}
