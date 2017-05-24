import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/src/http.service';
import { AssociatedAccountGridModel } from './associated-account-grid.model';

@Injectable()
export class AssociatedAccountGridService {
    private url = 'api/punter-analysis/associated-account';
    model: AssociatedAccountGridModel;

    constructor(
        private httpService: HttpService
    ) { }

    query(): Observable<any> {
        const queryModel = this.createQueryModel();
        return this.httpService.post<any>(this.url, queryModel);
    }

    private createQueryModel(): any {
        return {
            custId: this.model.custId,
            userName: this.model.custName
        };
    }
}
