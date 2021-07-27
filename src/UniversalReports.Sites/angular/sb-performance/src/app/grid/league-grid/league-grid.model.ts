export interface LeagueDataItemModel {
    League: string;
    ActiveMembers: string;
    BetCount: number;
    RealIncome: number;
    RealTurnover: number;
    RealMargin: number;
  }

export interface LeagueDataModel {
    Entities: LeagueDataItemModel[];
    Total: LeagueDataItemModel;
}
