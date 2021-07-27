import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { FilterModel } from '../filter/filter.model';
import { Grid, GridType } from './grid.model';

@Injectable({
  providedIn: 'root'
})
export class GridService {
  filterModel: FilterModel;
  activeGrid: Grid;
  breadCrumb: string;
  showGridCompletedSubject: Subject<number>;
  queryModel: any;
  generate: (gridType: GridType, queryModel: any) => void;
}
