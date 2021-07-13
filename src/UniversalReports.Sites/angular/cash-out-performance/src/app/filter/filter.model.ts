export enum TimePeriod {
    Today,
    Yesterday,
    CurrentWeek,
    LastWeek,
    CurrentMonth,
    LastMonth,
    SinceLastMonth,
    SpecificDate,
    LastThreeMonths
}
export interface FilterItemModel {
    Id: number;
    Name: string;
}

export interface LeagueModel {
    Id: string;
    Name: string;
  }

export interface FilterModel {
    startDate: string;
    endDate: string;
    sports: string;
    sites: string;
    leagues: string;
    pageIndex: number;
    pageSize: number;
    isPageChanged: boolean;
  }
