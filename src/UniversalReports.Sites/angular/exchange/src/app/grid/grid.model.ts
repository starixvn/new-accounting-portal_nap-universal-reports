import { Observable } from "rxjs";

export interface Grid {
    title: string;
    query(): Observable<ExchangeModel>;
    exportExcel(): void;
}

export enum GridType {
    Licensee,
    Sport,
    Event
}

export interface QueryModel {
  licenseeName: string;
  eventType: string;
  drillLevel: number;
}

export interface Exchange {
    Name: string;
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