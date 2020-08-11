export interface FilterModel {
  year: number;
  custLevel: number;
  username: string;
  isDownline: boolean;
  currencies: string;
  isAppliedVR: number;
  sports: string;
  leagueIds: string;
  divisions: string;
  pageSize: number;
  pageIndex: number;
  isGenerated: boolean;
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
  GroupName: string;
}
