export interface PeriodGroupItem {
    WinLoss: number;
    Turnover: number;
    Margin: number;
    BetCount: number;
}

export interface LeagueItem {
    LeagueName: string;
    PeriodGroups: PeriodGroupItem[]
}

export interface ViewModelItem {
    Entities: LeagueItem[];
    Total: LeagueItem;
    GroupNames: string[]
}
