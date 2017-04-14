import { Observable } from 'rxjs/Observable';

export class TypeaheadQuery {
    readonly search: (term: string) => Observable<string[]>;

    constructor(search: (term: string) => Observable<string[]>) {
        this.search = search;
    };
}
