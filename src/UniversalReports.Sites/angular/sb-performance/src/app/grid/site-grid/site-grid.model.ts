export interface SiteDataItemModel {
  Sport: string;
  ActiveMembers: string;
  BetCount: number;
  RealIncome: number;
  RealTurnover: number;
  RealMargin: number;
}

export interface SiteDataModel {
  Entities: SiteDataItemModel[];
  Total: SiteDataItemModel;
}
