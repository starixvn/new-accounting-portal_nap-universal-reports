import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { SiteDataModel } from './margin-by-site-grid.model';
import { HttpService } from 'nap-components/http';
import { GridService } from '../grid.service';

@Injectable({
  providedIn: 'root'
})
export class MarginBySiteGridService {
  private url = 'api/sb-performance/main/site';
    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<SiteDataModel> {
        const queryModel = this.gridService.queryModel;
        return this.httpService.post<SiteDataModel>(this.url, queryModel);
    }
}
