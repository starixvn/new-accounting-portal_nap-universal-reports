export interface SummaryItem {
    Date: string;
    PlayerCount: number;
    Turnover: number;
    WinLoss: number;
    BetCount: number;
}

export interface SummaryData {
    Entities: SummaryItem[];
    Total: SummaryItem;
}
