export interface TicketItem {
  TransId: string;
  Username: string;
  MatchId: number;
  VoidedTime: string;
  HouseIncomeBeforeExtraPT: number;
  HouseIncomeAfterExtraPT: number;
}

export interface VoidTicketModel {
  Tickets: TicketItem[];
  Total: TicketItem;
  TotalItems: number;
}
