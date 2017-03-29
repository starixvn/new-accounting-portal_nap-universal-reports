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

    query(id: number): Observable<string> {
        let url = `http://58.86.55.10/NAP-Reports-Legend-API/api/legend/${id}`;
        return this.httpService.get<string>(url);
    }
}
