import { Observable } from 'rxjs/Observable';

export enum GridType {
    Main,
    Sport,
    League,
    Event,
    Match,
    BetType,
    Site
}

export interface Grid {
    title: string;
    query(): Observable<any>;
    sort(sortColumnName: string): void;
}
