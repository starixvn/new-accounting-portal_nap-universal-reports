export interface LeagueModel {
    GroupId: number;
    GroupName: string;
    LeagueId: number;
    LeagueName: string;
}

export interface FilterModel {
    fromDate: string;
    toDate: string;
    sportId: number;
    leagueGroupIds: string;
    leagueName?: string;
  }
