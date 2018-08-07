export interface Exchange {
    LicenseeName: string;
    MemberCount: number;
    BetCount: number;
    TurnOver: number;
    MemberWinLoss: number;
    MemberCommission: number;
    MemberTotal: number;
    LicenseeWinLoss: number;
    LicenseeCommission: number;
    LicenseeTotal: number;
    CompanyWinLoss: number;
    CompanyCommission: number;
    PayToSupplier: number;
    CompanyNetIncome: number;
  }

  export interface ExchangeModel {
    Entities: Exchange[];
    Total: Exchange;
  }
