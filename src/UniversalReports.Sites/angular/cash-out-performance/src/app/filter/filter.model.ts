export enum PeriodType {
    Yesterday = 1,
    CurrentWeek = 2,
    LastWeek = 3,
    CurrentMonth = 4,
    LastMonth = 5,
    SinceLastMonth = 6,
    SpecificDate = 7,
    Last3Months = 8
}

export interface FilterItemModel {
    Id: number;
    Name: string;
}

export interface FilterModel {
    fromDate: string;
    toDate: string;
    reason: number[];
    sport: number[];
    bettype: number[];
    licensee: number[];
    member: string;
    isTest: boolean;
    leagueId: string;
    pageIndex: number;
    pageSize: number;
    isPageChanged: boolean;
    currencyId: string;
  }