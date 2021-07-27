import { Observable } from 'rxjs/Observable';

export enum GridType {
    MarginBySite
}

export interface Grid {
    title: string;
    query(): Observable<any>;
    sort(sortColumnName: string): void;
}
