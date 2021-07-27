import { Component } from '@angular/core';
import { Grid } from '../grid.model';
import { SiteDataModel } from './margin-by-site-grid.model';
import { MarginBySiteGridService } from './margin-by-site-grid.service';
import * as _ from 'lodash';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-margin-by-site-grid',
  templateUrl: './margin-by-site-grid.component.html',
  styleUrls: ['./margin-by-site-grid.component.scss']
})
export class MarginBySiteGridComponent implements Grid {
  siteData: SiteDataModel;

  constructor(
    private marginBySiteGridService: MarginBySiteGridService
  ) { }

  query() {
        return new Observable(observer => {
          this.marginBySiteGridService.query().subscribe(data => {
              this.siteData = data;
              observer.complete();
          });
      });
    }

    get hasData(): boolean {
        return !_.isNil(this.siteData) && this.siteData.Entities.length > 0;
    }

    get title(): string {
        return `Site 1`;
    }

}
