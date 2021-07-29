import { Observable } from 'rxjs/Observable';

export enum GridType {
    Main,
    Sport,
    League,
    Event,
    Match,
    BetType
}

export interface Grid {
    title: string;
    query(): Observable<any>;
    sort(sortColumnName: string): void;
}
