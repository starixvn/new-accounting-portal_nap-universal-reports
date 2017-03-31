export interface BetTypeGridModel{
    custId: number;
    sportId: number;
}

export interface BetTypeItem {
    BetTypeId: number;
    BetTypeName: string;

    NonLiveWinLoss: number;
    NonLiveTurnover: number;
    NonLiveMargin: number;
    NonLiveBetCount: number;

    LiveWinLoss: number;
    LiveTurnover: number;
    LiveMargin: number;
    LiveBetCount: number;

    WinLoss: number;
    Turnover: number;
    Margin: number;
    BetCount: number;
}

export interface BetTypeData {
    Entities: BetTypeItem[];
    Total: BetTypeItem;
}

export class ProductHasLeague {
    public static get SPORTSBOOK(): number { return 1; }
    public static get LIVE_CASINO(): number { return 4; }
    public static get NUMBER_GAME(): number { return 3; }
    public static get RACING(): number { return 2; }
    public static get VIRTUAL_SPORTS(): number { return 5; }
}
