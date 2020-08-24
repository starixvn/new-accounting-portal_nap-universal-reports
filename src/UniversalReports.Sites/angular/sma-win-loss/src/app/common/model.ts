export interface QueryModel {
  year: number;
  custLevel: number;
  username: string;
  isDownline: boolean;
  currencies: string;
  isAppliedVR: boolean;
  sports: string;
  leagueGroupIds: string;
  divisions: string;
  pageSize: number;
  pageIndex: number;
}

export interface MonthModel {
  Month: string;
  Value: number;
}

export interface UsernameModel {
  CustId: number;
  Username: string;
  Currency: string;
  Name: string;
  VirtualRate: boolean;
  Months: MonthModel[];
}

export interface WinLossModel {
  UsernameWinLosses: UsernameModel[];
  Total: UsernameModel;
  TotalItems: number;
}

export interface VirtualRateModel {
  Sport: string;
  Bettype: string;
  IsLive: string;
  VirtualMultiplier: number;
}
