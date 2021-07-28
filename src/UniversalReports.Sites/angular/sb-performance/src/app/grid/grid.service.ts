import { Injectable } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { Grid, GridType } from './grid.model';

@Injectable({
  providedIn: 'root'
})
export class GridService {
  filterModel: FilterModel;
  activeGrid: Grid;
  queryModel: any;
  mainTitle: string;
  leagueTitle: string;
  sportTitle: string;
  eventTitle: string;
  isShowFullColumn: boolean;
  gridType: GridType;
  generate: (gridType: GridType, queryModel: any) => void;
}
