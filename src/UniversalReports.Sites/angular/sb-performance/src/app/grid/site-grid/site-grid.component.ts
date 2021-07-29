import { Component } from '@angular/core';
import { Grid, GridType } from '../grid.model';
import { SiteDataModel } from './site-grid.model';
import { SiteGridService } from './site-grid.service';
import * as _ from 'lodash';
import { Observable } from 'rxjs/Observable';
import { GridService } from '../grid.service';

@Component({
  selector: 'app-site-grid',
  templateUrl: './site-grid.component.html',
  styleUrls: ['./site-grid.component.scss']
})
export class SiteGridComponent implements Grid {
  data: SiteDataModel;
  sortColumnName = '';
  sortDirection = '';

  constructor(
    private siteGridService: SiteGridService,
    private readonly gridService: GridService
  ) { }

  query() {
        return new Observable(observer => {
          this.siteGridService.query().subscribe(data => {
              this.data = data;
              observer.complete();
          });
      });
    }

    get hasData(): boolean {
        return !_.isNil(this.data) && this.data.Entities.length > 0;
    }

    get title(): string {
        return this.gridService.siteTitle;
    }

    get isShowFullColumn(): boolean {
      return this.gridService.filterModel.isShowFullColumn;
    }

    sort(sortColumnName: string) {
      if (this.sortColumnName !== sortColumnName) {
        this.sortDirection = '';
      }

      this.sortColumnName = sortColumnName;
      this.sortDirection = this.sortDirection !== 'asc' ? 'asc' : 'desc';
      this.data.Entities = _.orderBy(this.data.Entities, this.sortColumnName, this.sortDirection !== 'asc' ? 'asc' : 'desc');
    }

    showLeague(id: string, site: string) {
      this.gridService.leagueTitle = site;
      this.gridService.generate(GridType.League, { SiteId: id, LeagueId: null, LiveIndicator: null, MatchId: null});
    }
}
