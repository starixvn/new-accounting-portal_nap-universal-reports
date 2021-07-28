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
        return this.siteGridService.getTitle();
    }

    get isShowFullColumn(): boolean {
      return this.siteGridService.isShowFullColumn();
    }

    sort(sortColumnName: string) {
      if (this.sortColumnName !== sortColumnName) {
        this.sortDirection = '';
      }

      this.sortColumnName = sortColumnName;
      this.sortDirection = this.sortDirection !== 'asc' ? 'asc' : 'desc';
      this.data.Entities = _.orderBy(this.data.Entities, this.sortColumnName, this.sortDirection !== 'asc' ? 'asc' : 'desc');
    }

    showSport(id: string, sport: string) {
      this.gridService.leagueTitle = sport;
      this.gridService.generate(GridType.League, { SportId: id });
    }
}
