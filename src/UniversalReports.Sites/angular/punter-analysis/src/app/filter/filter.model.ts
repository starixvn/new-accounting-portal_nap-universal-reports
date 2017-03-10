export enum SearchBy {
    User,
    League,
    Performance
}

export interface OptionItem {
    text: string;
    value: any;
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