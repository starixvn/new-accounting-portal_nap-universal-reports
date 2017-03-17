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

export enum Role {
    Agent,
    Member
}

export enum OrderBy {
    WinLoss,
    Turnover,
    Margin
}

export enum Order {
    Ascending,
    Descending
}

export interface FilterModel {
    searchBy: SearchBy,
    topRows: number,
    orderBy: OrderBy,
    order: Order,
    periodType: PeriodType,
    fromDate: NgbDateStruct,
    toDate: NgbDateStruct,
    depth: Role,
    userName: string
}
