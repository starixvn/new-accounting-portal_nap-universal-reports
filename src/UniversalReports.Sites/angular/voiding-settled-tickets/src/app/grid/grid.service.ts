import { Injectable } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { Grid } from './grid.model';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class GridService {
    filterModel: FilterModel;
    activeGrid: Grid;
    keyId: number;
    productName: string;
    generateTicketGridSubject: Subject<number>;
    showGridCompletedSubject: Subject<number>;
}
