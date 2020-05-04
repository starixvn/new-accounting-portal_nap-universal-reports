export interface ReasonModel {
  ReasonId: number;
  ReasonName: string;
}

export interface BetTypeModel {
  BetTypeId: number;
  BetTypeName: string;
}

export interface SportModel {
  SportId: number;
  SportName: string;
}

export interface SiteModel {
  SiteId: number;
  SiteName: string;
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
}

