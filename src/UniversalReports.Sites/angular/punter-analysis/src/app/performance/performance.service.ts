import { Injectable } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { Performance, PerformanceType } from './performance.model';

@Injectable()
export class PerformanceService {
    filterModel: FilterModel;
    activePerformance: Performance;
    performances: Performance[];
    goBack: (index: number) => void;
    generate: (performanceType: PerformanceType) => void;
}
