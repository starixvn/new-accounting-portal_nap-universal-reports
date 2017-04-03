import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DateHelper } from 'nap-components/src/date';
import { HttpService } from '../../components/http.service';
import { AssociatedAccountGridModel } from './associated-account-grid.model';

@Injectable()
export class AssociatedAccountGridService {
    model: AssociatedAccountGridModel;

    constructor(
        private httpService: HttpService
    ) { }

    query(): Observable<any> {
        let url = 'UniversalReports/api/punter-analysis/associated-account';
        return this.httpService.post<any>(url, {
            custId: this.model.custId,
            userName: this.model.custName
        });
    }
}
