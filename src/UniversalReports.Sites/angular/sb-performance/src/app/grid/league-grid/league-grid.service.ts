import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/http';
import { GridService } from '../grid.service';
import { LeagueDataModel } from './league-grid.model';

@Injectable({
  providedIn: 'root'
})
export class LeagueGridService {
  public leagueName: string;
  private url = 'api/sb-performance/main/league';
    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<LeagueDataModel> {
        const queryModel = this.gridService.queryModel;
        return this.httpService.post<LeagueDataModel>(this.url, queryModel);
    }

    getTitle(): string {
      return this.gridService.leagueTitle;
    }

    isShowFullColumn(): boolean {
      return this.gridService.isShowFullColumn;
    }
}
