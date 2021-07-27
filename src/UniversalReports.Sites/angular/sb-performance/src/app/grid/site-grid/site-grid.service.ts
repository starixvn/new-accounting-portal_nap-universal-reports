import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { SiteDataModel } from './site-grid.model';
import { HttpService } from 'nap-components/http';
import { GridService } from '../grid.service';

@Injectable({
  providedIn: 'root'
})
export class SiteGridService {
  private url = 'api/sb-performance/main/margin-by-site/site';
    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<SiteDataModel> {
        const queryModel = this.gridService.queryModel;
        return this.httpService.post<SiteDataModel>(this.url, queryModel);
    }

    getTitle(): string {
      return this.gridService.title;
    }

    isShowFullColumn(): boolean {
      return this.gridService.isShowFullColumn;
    }

}
