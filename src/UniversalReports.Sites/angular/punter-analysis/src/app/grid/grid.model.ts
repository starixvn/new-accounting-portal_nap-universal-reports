export enum GridType {
    UserName,
    AssociatedAccount,
    BetCount,
    SportType,
    BetType,
    League
}

export interface Grid {
    hasExcel: boolean;
    title: string;
    query(): void;
    exportExcel(): void;
}

export enum LiveStatus {
    Live = 1,
    NonLive = 2
}
