import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { BetCount } from './performance.model';

@Injectable()
export class PerformanceService {
    private url = 'api/punter-analysis/summary';

    constructor(
        private httpService: HttpService
    ) { }

    query(): Observable<BetCount[]> {
        let fakeData:BetCount[] = [{
            Month : new Date(2016,1,1) ,
            BetCount: 200
        },
        {
            Month : new Date(2016,2,1) ,
            BetCount: 300
        }];

         return Observable.of(fakeData);
    }
}
