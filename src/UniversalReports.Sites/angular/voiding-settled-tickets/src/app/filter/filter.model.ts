export interface FilterModel {
    winlostDate: string;
    matchId: number;
    voidTime: string;
    productGroupID?: number;
    productName: string;
    pageSize?: number;
    pageIndex?: number;
    isPageChanged?: boolean;
}
