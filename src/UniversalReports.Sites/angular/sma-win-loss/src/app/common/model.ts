export interface QueryModel {
  year: number;
  custLevel: number;
  username: string;
  isDownline: boolean;
  currencies: string;
  isAppliedVR: boolean;
  sports: string;
  leagueIds: string;
  divisions: string;
  pageSize: number;
  pageIndex: number;
  isGenerated: boolean;
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
  Months: MonthModel[];
}

export interface WinLossModel {
  UsernameWinLosses: UsernameModel[];
  Total: UsernameModel;
  TotalItems: number;
}
