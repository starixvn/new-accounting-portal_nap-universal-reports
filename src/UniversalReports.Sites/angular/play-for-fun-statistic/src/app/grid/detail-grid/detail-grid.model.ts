import { NgbDateStruct } from 'nap-components/src/date';

export interface DetailItem {
    Date: string;
    GroupHeadline: string;
    Site: string;
    Currency: string;
    Super: string;
    Username: string;
    CustId: number;
    Product: string;
    Status: boolean;
    MemberRequest: boolean;
    Turnover: number;
    WinLoss: number;
    BetCount: number;
}

export interface DetailData {
    Entities: DetailItem[];
    Total: DetailItem;
}

export interface DetailGridModel {
    Date: NgbDateStruct;
}
