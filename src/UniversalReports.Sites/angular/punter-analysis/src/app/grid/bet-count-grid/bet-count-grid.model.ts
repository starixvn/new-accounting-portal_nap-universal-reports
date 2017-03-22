export interface BetCountItem {
    Date: Date;
    WinLoss: number;
    BetCount: number;
    WinCount: number;
    DrawCount: number;
}

export interface ViewModelItem {
    Entities: BetCountItem[];
    Total: BetCountItem;
}
