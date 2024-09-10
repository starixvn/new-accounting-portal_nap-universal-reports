  export enum TurnoverType {
    Normal,
    NoDraw
  }

  export interface SportItemModel {
    SportId: number;
    Sport: string;
    MatchCount: number;
    BetCount: number;
    MemberWinLoss: number;
    MemberTurnover: number;
    HouseIncome: number;
    HouseTurnover: number;
    AmountDueToBC: number;
  }

  export interface SportModel {
    Items: SportItemModel[];
    Total: SportItemModel;
  }
