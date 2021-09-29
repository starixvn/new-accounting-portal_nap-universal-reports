export interface CommonTicketModel {
  COTurnover_RM: number;
  BBAmount_RM: number;
  MemberWL_RM: number;
  Comm_RM: number;
  COIncome_RM: number;
  TotalIncome_RM: number;
}
export interface TicketModel extends CommonTicketModel {
    WLDate: Date;
    Username: string;
    Currency: string;
    OrigID: number;
    BuyBackID: number;
    CashOutID: number;
    SportName: string;
    LeagueName: string;
    MatchName: string;
    BetTime: Date;
    CashOutTime: Date;
    BetOdd: string;
    BetTypeName: string;
    BetChoice: string;
    COTurnover: number;
    BBAmount: number;
    MemberWL: number;
  }

export interface SportLevelModel extends CommonTicketModel {
    SportType: number;
    SportName: string;
}

export interface EventStatusLevelModel extends CommonTicketModel {
    LiveStatus: number;
}

export interface BetTypeLevelModel extends CommonTicketModel {
  BetType: number;
  BetTypeName: string;
}

export interface MatchDetailLevelModel extends CommonTicketModel {
  WLDate: Date;
  Username: string;
  Currency: string;
  OrigID: number;
  BuyBackID: number;
  CashOutID: number;
  SportName: string;
  LeagueName: string;
  MatchName: string;
  BetTime: Date;
  CashOutTime: Date;
  BetOdd: string;
  BetTypeName: string;
  BetChoice: string;
  COTurnover: number;
  BBAmount: number;
  MemberWL: number;
}

export interface TicketViewModel<T> {
    TicketList: T[];
    TotalTicket: T;
    Total: number;
  }

export interface ExcelQueryModel {
    startDate: string;
    endDate: string;
    sportBettype: string;
    sites: string;
    pageIndex: number;
    pageSize: number;
    isPageChanged: boolean;
    title: string;
  }