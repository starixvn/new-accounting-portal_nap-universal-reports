import { RoleId, Order } from 'nap-components/src/model';
import { NgbDateStruct } from './period-type/period-type.model';

export enum SearchBy {
    User,
    League,
    Performance
}

export enum PeriodType {
    Daily,
    Weekly,
    Monthly,
    Annually,
    MonthRange
}

export enum OrderBy {
    WinLoss,
    Turnover,
    Margin
}

export interface FilterModel {
    searchBy: SearchBy,
    topRows: number,
    orderBy: OrderBy,
    order: Order,
    periodType: PeriodType,
    fromDate: NgbDateStruct,
    toDate: NgbDateStruct,
    depth: RoleId,
    userName: string
}
