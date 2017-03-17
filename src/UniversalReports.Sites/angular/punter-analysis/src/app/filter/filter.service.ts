import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RoleId } from 'nap-components/src/model';
import { HttpService } from '../components/http.service';

export interface DataWarehouseDateRange {
    MinDate: string;
    MaxDate: string;
}

@Injectable()
export class FilterService {
    constructor(
        private httpService: HttpService
    ) { }

    queryDataWarehouseDateRange(): Observable<DataWarehouseDateRange> {
        let url = 'UniversalReports/api/punter-analysis/filter/available-date-range';
        return this.httpService.post<DataWarehouseDateRange>(url);
    }

    queryUserNameSuggestion(userName: string, roleId: RoleId): Observable<string[]> {
        let url = 'UniversalReports/api/punter-analysis/filter/username-suggestion';
        return this.httpService.post<string[]>(url, {
            userName: userName,
            roleId: roleId
        });
    }
}
