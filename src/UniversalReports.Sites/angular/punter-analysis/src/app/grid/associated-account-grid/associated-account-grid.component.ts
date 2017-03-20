import { Component } from '@angular/core';
import * as moment from 'moment';
import { UserRoleItem } from './associated-account-grid.model'

@Component({
    selector: 'nap-associated-account-grid',
    templateUrl: './associated-account-grid.component.html',
    styleUrls: [
        './associated-account-grid.component.scss',
        '../grid.scss'
    ]
})
export class AssociatedAccountGridComponent {
    private userRoleItems: UserRoleItem[];
    private rowCount: number;
    constructor() {
        this.userRoleItems = [];
        this.rowCount = 12;

        for (var i = 0; i < this.rowCount; i++) {
            let betCountItem: UserRoleItem = {
                Username: "User"+i,
                RoleName:"member"
            };
            this.userRoleItems.push(betCountItem);
        }
    }
}