import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DateHelper } from 'nap-components/src/date';
import { HttpService } from '../../components/http.service';

@Injectable()
export class LeagueGridService {
    constructor(
        private httpService: HttpService
    ) { }

    query(model: any): Observable<any> {
        let url = 'UniversalReports/api/punter-analysis/bet-type';
        return this.httpService.post<any>(url, {
            custId: model.custId,
            userName: model.userName
        });
    }
}
