export interface TicketModel {
    WLDate: Date;
    Username: string;
    OrigID: number;
    BuyBackID: number;
    CashOutID: number;
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
    COTurnover_RM: number;
    BBAmount_RM: number;
    MemberWL_RM: number;
    Comm_RM: number;
    COIncome_RM: number;
    TotalIncome_RM: number;
  }

  export interface SummaryEntity {
    Entities: TicketModel[];
    Total: TicketModel;
  }

  export interface ExcelQueryModel {
    startDate: string;
    endDate: string;
    sports: string;
    sites: string;
    pageIndex: number;
    pageSize: number;
    isPageChanged: boolean;
    title: string;
  }