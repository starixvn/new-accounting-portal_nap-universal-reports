import { MainService } from './main.service';
import { MainItemModel } from './../common/model';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { QueryModelService } from '../common/queryModel.service';
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
    this.gridService.queryModel = null;

    this.mainService.query(this.filterModel, true, false, false, false).subscribe(data => {
      this.isHaveDrillDown = false;
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

  showGrid(model: object, mainTitle: string, title: string, reportType: number) {
    this.isHaveDrillDown = true;
    this.gridService.gridType = reportType;
    this.gridService.queryModel = model;
    this.gridService.mainTitle = mainTitle;
    this.gridService.sportTitle = title;
    this.gridService.isShowFullColumn = this.isShowFullColumn;
  }
}
