import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../components/http.service';

export interface DataWarehouseDateRange {
    fromDate: string;
    toDate: string;
}

@Injectable()
export class FilterService {
    constructor(
        private httpService: HttpService
    ) { }

    queryDataWarehouseDateRange(): Observable<DataWarehouseDateRange> {
        let url = 'NonSportGameStatistics/Product/Query';
        return this.httpService.get<DataWarehouseDateRange>(url);
    }
}
