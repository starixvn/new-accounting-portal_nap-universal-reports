import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/http';
import { GridService } from '../grid.service';
import { LeagueDataModel } from './league-grid.model';

@Injectable({
  providedIn: 'root'
})
export class LeagueGridService {
  private urlFromMarginBySite = 'api/sb-performance/main/margin-by-site/league';
    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    queryFromMarginBySite(): Observable<LeagueDataModel> {
        const queryModel = this.gridService.queryModel;
        return this.httpService.post<LeagueDataModel>(this.urlFromMarginBySite, queryModel);
    }

    getTitle(): string {
      return this.gridService.title;
    }

    isShowFullColumn(): boolean {
      return this.gridService.isShowFullColumn;
    }
}
