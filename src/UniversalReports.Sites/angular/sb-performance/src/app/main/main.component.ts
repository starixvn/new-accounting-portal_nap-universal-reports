import { MainService } from './main.service';
import { MainItemModel } from './../common/model';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { QueryModelService } from '../common/queryModel.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
  providers: [
    MainService,
    QueryModelService]
})
export class MainComponent implements OnChanges {
  @Input() filterModel: FilterModel;
  siteData: MainItemModel;
  sportData: MainItemModel;
  usernameData: MainItemModel;
  leagueData: MainItemModel;
  isShowFullColumn = false;

  constructor( private readonly mainService: MainService) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (!this.filterModel) {
      return;
    }

    this.isShowFullColumn = this.filterModel.isShowFullColumn;

    this.mainService.query(this.filterModel, true, false, false, false).subscribe(data => {
      this.siteData = data;
    });

    this.mainService.query(this.filterModel, false, true, false, false).subscribe(data => {
      this.sportData = data;
    });

    this.mainService.query(this.filterModel, false, false, true, false).subscribe(data => {
      this.leagueData = data;
    });

    this.mainService.query(this.filterModel, false, false, false, true).subscribe(data => {
      this.usernameData = data;
    });
  }
}
