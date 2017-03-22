export interface SportTypeItem {
    SportId: number;
    SportName: string;
    WinLoss: number;
    Turnover: number;
    Margin: number;
    BetCount: number;
}

export interface ViewModelItem {
    Entities: SportTypeItem[];
    Total: SportTypeItem;
}
