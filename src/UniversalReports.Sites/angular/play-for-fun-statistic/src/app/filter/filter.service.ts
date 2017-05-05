import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { HttpService } from 'nap-components/src/http.service';
import { RoleId } from 'nap-components/src/model';
import { FilterModel } from './filter.model';

interface Product {
    ProductId: number;
    ProductName: string;
}

@Injectable()
export class FilterService {
    private url = 'api/play-for-fun/filter';

    constructor(
        private httpService: HttpService
    ) { }

    queryProductOptions(): Observable<SelectItem[]> {
        const url = `${this.url}/product`;
        return this.httpService.post<Product[]>(url).map(products => {
            return products.map(product => <SelectItem>{
                text: product.ProductName,
                value: product.ProductId
            });
        });
    }

    queryUserNameSuggestion(userName: string): Observable<string[]> {
        const url = 'api/punter-analysis/filter/username-suggestion';
        return this.httpService.post<string[]>(url, {
            userName: userName,
            roleId: RoleId.Super
        });
    }
}
