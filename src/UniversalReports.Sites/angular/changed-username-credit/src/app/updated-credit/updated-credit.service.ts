import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { Observable } from 'rxjs/Observable';
import { UpdatedCreditModel } from './updated-credit.model';
import { FilterModel } from './../filter/filter.model';

@Injectable()
export class UpdatedCreditService {
    constructor(private httpService: HttpService) { }

    query(model: FilterModel): Observable<UpdatedCreditModel[]> {
        const url = 'api/updated-credit/query';
        return this.httpService.post<UpdatedCreditModel[]>(url, model);
    }
}
