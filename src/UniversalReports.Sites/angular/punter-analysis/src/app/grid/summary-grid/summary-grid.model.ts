export interface SummaryItem {
    CustId: number;
    Username: string;
    WinLoss: number;
    Turnover: number;
    Margin: number;
    BetCount: number;
}

export interface ViewModelItem {
    Entities: SummaryItem[];
    Total: SummaryItem;
}
