import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { Observable } from 'rxjs/Observable';
import { UpdatedCreditModel } from './updated-credit.model';
import { FilterModel } from './../filter/filter.model';
import { QueryModelService } from './../common/query-model.service';

@Injectable()
export class UpdatedCreditService {
    constructor(private httpService: HttpService, private queryModelService: QueryModelService) { }

    query(filterModel: FilterModel): Observable<UpdatedCreditModel[]> {
        const url = 'api/updated-credit/query';
        const model = this.queryModelService.createQueryModel(filterModel);
        return this.httpService.post<UpdatedCreditModel[]>(url, model);
    }
}
