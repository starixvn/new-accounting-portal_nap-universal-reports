export interface FilterModel {
  year: number;
  custLevel: number;
  username: string;
  isDownline: boolean;
  currencies: string;
  isAppliedVR: number;
  sports: string;
  leagueGroupIds: string;
  divisions: string;
  pageSize: number;
  pageIndex: number;
  isPageChanged: boolean;
}

export class SelectItem {
  name: string;
  value: number;

  constructor(name: string, value: number) {
    this.name = name;
    this.value = value;
  }

  public get Name() {
    return this.name;
  }

  public get Value() {
    return this.value;
  }
}

export interface Currency {
  CurrencyId: number;
  CurrencyName: string;
}

export interface Site {
  SiteGroup: number;
  SiteId: number;
  SiteName: string;
}

export interface Sport {
  SportGroup: string;
  SportIds: string;
}

export interface LeagueGroup {
  GroupId: string;
  GroupName: string;
}
