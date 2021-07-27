import { MainService } from './main.service';
import { MainItemModel } from './../common/model';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { QueryModelService } from '../common/queryModel.service';
import { ReportType } from './main.model';
import { GridService } from '../grid/grid.service';

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
  isHaveDrillDown = false;

  constructor(
    private readonly mainService: MainService,
    private readonly gridService: GridService
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (!this.filterModel) {
      return;
    }

    this.isShowFullColumn = this.filterModel.isShowFullColumn;

    this.mainService.query(this.filterModel, true, false, false, false).subscribe(data => {
      this.isHaveDrillDown = false;
      this.siteData = data;
      this.siteData.ReportType = ReportType.MarginBySite;
    });

    this.mainService.query(this.filterModel, false, true, false, false).subscribe(data => {
      this.sportData = data;
      this.sportData.ReportType = ReportType.MarginBySports;
    });

    this.mainService.query(this.filterModel, false, false, true, false).subscribe(data => {
      this.leagueData = data;
      this.leagueData.ReportType = ReportType.TopLosingLeagues;
    });

    this.mainService.query(this.filterModel, false, false, false, true).subscribe(data => {
      this.usernameData = data;
      this.usernameData.ReportType = ReportType.TopWinningMembers;
    });
  }

  showGrid(model: object, mainTitle: string, title: string) {
    this.isHaveDrillDown = true;
    this.gridService.queryModel = model;
    this.gridService.mainTitle = mainTitle;
    this.gridService.title = title;
    this.gridService.isShowFullColumn = this.isShowFullColumn;
  }
}
