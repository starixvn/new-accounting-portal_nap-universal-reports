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
    excel(): void;
}
