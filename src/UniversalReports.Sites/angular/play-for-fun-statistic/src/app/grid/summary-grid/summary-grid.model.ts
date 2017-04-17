export interface SummaryItem {
    Date: Date;
    PlayerCount: number;
    Turnover: number;
    MemberWinLoss: number;
    BetCount: number;
}

export interface SummaryData {
    Entities: SummaryItem[];
    Total: SummaryItem;
}
