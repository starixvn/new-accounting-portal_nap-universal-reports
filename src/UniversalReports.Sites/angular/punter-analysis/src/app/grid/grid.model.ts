import { Observable } from 'rxjs/Observable';

export enum GridType {
    UserName,
    AssociatedAccount,
    BetCount,
    SportType,
    BetType,
    League
}

export interface Grid {
    hasData: boolean;
    title: string;
    query(): Observable<any>;
    exportExcel(): void;
}

export enum LiveStatus {
    Live = 1,
    NonLive = 2
}
