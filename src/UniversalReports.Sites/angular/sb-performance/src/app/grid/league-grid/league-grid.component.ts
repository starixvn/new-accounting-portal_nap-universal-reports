import { Component } from '@angular/core';
import { Grid } from '../grid.model';
import * as _ from 'lodash';
import { Observable } from 'rxjs/Observable';
import { LeagueDataModel } from './league-grid.model';
import { LeagueGridService } from './league-grid.service';

@Component({
  selector: 'app-league-grid',
  templateUrl: './league-grid.component.html',
  styleUrls: ['./league-grid.component.scss']
})
export class LeagueGridComponent implements Grid {

  data: LeagueDataModel;
  sortColumnName = '';
  sortDirection = '';

  constructor(
    private leagueGridService: LeagueGridService
  ) { }

  query() {
        return new Observable(observer => {
          this.leagueGridService.queryFromMarginBySite().subscribe(data => {
              this.data = data;
              observer.complete();
          });
      });
    }

    get hasData(): boolean {
        return !_.isNil(this.data) && this.data.Entities.length > 0;
    }

    get title(): string {
        return this.leagueGridService.getTitle();
    }

    get isShowFullColumn(): boolean {
      return this.leagueGridService.isShowFullColumn();
    }

    sort(sortColumnName: string) {
      if (this.sortColumnName !== sortColumnName) {
        this.sortDirection = '';
      }

      this.sortColumnName = sortColumnName;
      this.sortDirection = this.sortDirection !== 'asc' ? 'asc' : 'desc';
      this.data.Entities = _.orderBy(this.data.Entities, this.sortColumnName, this.sortDirection !== 'asc' ? 'asc' : 'desc');
    }

    showEvent() {
      
    }

}
