import { RoleId, SortBy } from 'nap-components/src/model';
import { NgbDateStruct } from 'nap-components/src/date';

export enum SearchBy {
    User,
    League,
    Performance
}

export enum PeriodType {
    Daily = 1,
    Weekly = 2,
    Monthly = 3,
    Annually = 4,
    MonthRange = 5
}

export enum OrderBy {
    WinLoss = 1,
    Turnover = 2,
    Margin = 3
}

export interface FilterModel {
    searchBy: SearchBy,
    topRow: number,
    orderBy: OrderBy,
    sortBy: SortBy,
    periodType: PeriodType,
    fromDate: NgbDateStruct,
    toDate: NgbDateStruct,
    depth: RoleId,
    userName: string,
    productBetTypes: number[];
}
