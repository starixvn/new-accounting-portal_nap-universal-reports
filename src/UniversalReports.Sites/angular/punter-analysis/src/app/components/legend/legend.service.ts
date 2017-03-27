import { Injectable } from '@angular/core';
import { URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpService } from '../http.service';

@Injectable()
export class LegendService {
    constructor(
        private httpService: HttpService
    ) {
    }

    query(menuName: string): Observable<string> {
        let url = 'LegendManagement/Legend/GetReportLegend';
        let params = new URLSearchParams();
        params.set('menuName', menuName);
        //return this.httpService.get<string>(url, { search: params });
        return Observable.of<string>('<div>Test</div>');
    }
}
