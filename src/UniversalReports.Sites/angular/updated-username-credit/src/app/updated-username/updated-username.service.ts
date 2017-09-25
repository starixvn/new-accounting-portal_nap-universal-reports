import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { Observable } from 'rxjs/Observable';
import { UpdatedUsernameModel } from './updated-username.model';
import { FilterModel } from './../filter/filter.model';
import { QueryModelService } from './../common/query-model.service';

@Injectable()
export class UpdatedUsernameService {
    constructor(private httpService: HttpService, private queryModelService: QueryModelService) { }

    query(filterModel: FilterModel): Observable<UpdatedUsernameModel[]> {
        const url = 'api/updated-username/query';
        const model = this.queryModelService.createQueryModel(filterModel);
        return this.httpService.post<UpdatedUsernameModel[]>(url, model);
    }
}
