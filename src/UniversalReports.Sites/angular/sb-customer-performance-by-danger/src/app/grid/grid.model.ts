export interface CustomerPerformanceByDangerModel {
  UserName: string;
  AgentName: string;
  MasterName: string;
  SuperName: string;
  Division: string;
  Currency: string;
  DangerLevel: string;
  BetCount: number;
  MemberTO: number;
  MemberWL: number;
  HouseTO: number;
  HouseIncome: number;
  AVGStake: number;
  NoAssociatedAccount: number;
  Margin: number;
}

export interface SummaryEntity {
  Entities: CustomerPerformanceByDangerModel[];
  Total:CustomerPerformanceByDangerModel;
}
