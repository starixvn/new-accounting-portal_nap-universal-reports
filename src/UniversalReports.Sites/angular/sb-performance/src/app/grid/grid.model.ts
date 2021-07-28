import { Observable } from 'rxjs/Observable';

export enum GridType {
    Sport,
    League,
    Event
}

export interface Grid {
    title: string;
    query(): Observable<any>;
    sort(sortColumnName: string): void;
}
