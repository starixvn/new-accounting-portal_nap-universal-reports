import { Injectable } from '@angular/core';
import { URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../http.service';

@Injectable()
export class LegendService {
    constructor(
        private httpService: HttpService
    ) { }

    query(id: number): Observable<string> {
        const url = `https://nap.oneops.net/NAP-Reports-Legend-API/api/legend/${id}`;
        return this.httpService.get<string>(url);
    }
}
