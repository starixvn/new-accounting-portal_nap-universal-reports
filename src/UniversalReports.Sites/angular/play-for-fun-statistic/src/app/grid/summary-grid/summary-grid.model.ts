export interface SummaryItem {
    Date: Date;
    NoPlayers: number;
    Turnover: number;
    MemberWinLoss: number;
    PlayCount: number;
}

export interface SummaryData {
    Entities: SummaryItem[];
    Total: SummaryItem;
}
