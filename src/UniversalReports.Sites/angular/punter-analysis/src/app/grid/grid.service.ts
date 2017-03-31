import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { FilterModel } from '../filter/filter.model';
import { Grid, GridType } from './grid.model';
import { BetCountGridModel } from './bet-count-grid/bet-count-grid.model';
import { AssociatedAccountGridModel } from './associated-account-grid/associated-account-grid.model';

@Injectable()
export class GridService {
    filterModel: FilterModel;
    activeGrid: Grid;
    show = new Subject<GridType>();

    showGrid(gridType: GridType) {
        this.show.next(gridType);
    }
}
