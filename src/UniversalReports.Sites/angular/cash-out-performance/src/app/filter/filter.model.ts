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
    leagueGroupIDs: string;
    sites: string;
    leagues: string;
    betType: string;
    pageIndex: number;
    pageSize: number;
    isPageChanged: boolean;
  }
