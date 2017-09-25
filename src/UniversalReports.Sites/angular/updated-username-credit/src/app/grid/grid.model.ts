import { FilterModel } from './../filter/filter.model';

export interface Grid {
    hasExcel: boolean;
    query(filterModel: FilterModel): void;
    exportExcel(filterModel: FilterModel): void;
}
