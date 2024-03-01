export interface LeagueModel {
    GroupId: number;
    GroupName: string;
    LeagueId: number;
    LeagueName: string;
}

export interface FilterModel {
    fromDate: string;
    toDate: string;
    sportBettype: string;
    sportId: number;
    leagueIds: string;
    pageIndex: number;
    pageSize: number;
    isPageChanged: boolean;
  }
