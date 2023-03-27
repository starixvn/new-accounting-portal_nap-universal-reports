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
  accountStatus: string;
  vrSettings: string;
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
  SiteGroup: string;
  SiteId: number;
  SiteName: string;
  SiteLabel: string;
}

export interface Sport {
  SportGroup: string;
  SportIds: string;
}

export interface LeagueGroup {
  GroupId: string;
  GroupName: string;
}

export interface CommonItem {
  Value: string;
  Text: string;
}
