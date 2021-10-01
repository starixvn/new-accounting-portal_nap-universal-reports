import { Injectable } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { Grid, GridType } from './grid.model';

@Injectable({
  providedIn: 'root'
})
export class GridService {
  filterModel: FilterModel;
  orginalSportBettype: string;
  cachedSportBettype: string;
  activeGrid: Grid;
  eventTitle: string;
  betTypeTitle: string;
  matchDetailTitle: string;
  generate: (gridType: GridType) => void;
}
