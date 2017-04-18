import { NgbDateStruct } from 'nap-components/src/date';

export interface DetailItem {
    Date: Date;
    GroupHeadline: string;
    Site: string;
    Currency: string;
    Super: string;
    Username: string;
    CustId: number;
    Product: string;
    Status: string;
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
