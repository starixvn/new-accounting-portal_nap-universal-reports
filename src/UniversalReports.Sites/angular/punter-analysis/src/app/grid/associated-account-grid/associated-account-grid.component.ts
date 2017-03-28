import { Component } from '@angular/core';
import * as moment from 'moment';
import { UserRoleItem } from './associated-account-grid.model'

@Component({
    selector: 'nap-associated-account-grid',
    templateUrl: './associated-account-grid.component.html'
})
export class AssociatedAccountGridComponent {
    private userRoleItems: UserRoleItem[];
    
    constructor() {
        this.userRoleItems = this.createFakeData();
    }

    private createFakeData(): UserRoleItem[] {
        var entities: UserRoleItem[] = [];
        for (var i = 0; i < 50; i++) {
            let betCountItem: UserRoleItem = {
                Username: "User" + i,
                RoleName: "member"
            };

            entities.push(betCountItem);
        }

        return entities;
    }
}