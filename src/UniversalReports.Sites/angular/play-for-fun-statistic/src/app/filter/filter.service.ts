import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import * as _ from 'lodash';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { HttpService } from 'nap-components/src/http.service';
import { FilterModel } from './filter.model';

@Injectable()
export class FilterService {
    constructor(
        private httpService: HttpService
    ) { }

    queryProductOptions(): Observable<SelectItem[]> {
        return Observable.of([{
            text: 'XYZ',
            value: 1
        }]);
        /*const url = 'api/punter-analysis/filter/product-sport-bet-type';
        return this.httpService.post<SelectItem[]>(url);*/
    }

    querySuperNameSuggestion(userName: string): Observable<string[]> {
        const url = 'api/punter-analysis/filter/username-suggestion';
        return this.httpService.post<string[]>(url, {
            userName: userName
        });
    }
}
