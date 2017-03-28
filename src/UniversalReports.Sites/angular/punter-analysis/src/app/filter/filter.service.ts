import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import * as _ from 'lodash';
import { TreeviewItem } from 'ng2-dropdown-treeview';
import { RoleId } from 'nap-components/src/model';
import { HttpService } from '../components/http.service';
import { FilterModel } from './filter.model';

export interface DataWarehouseDateRange {
    MinDate: string;
    MaxDate: string;
}

interface ProductSportTypeBetType {
    ProductName: string;
    SportGroup: string;
    SportName: string;
    BetTypeName: string;
    Value: number;
    RenderType: number;
}

enum RenderType {
    Product_SportGroup_Sport_BetType = 1,
    Product_Sport_BetType = 2,
    Product_BetType = 3
}

@Injectable()
export class FilterService {
    constructor(
        private httpService: HttpService
    ) { }

    queryDataWarehouseDateRange(): Observable<DataWarehouseDateRange> {
        let url = 'UniversalReports/api/punter-analysis/filter/available-date-range';
        return this.httpService.post<DataWarehouseDateRange>(url);
    }

    queryUserNameSuggestion(userName: string, roleId: RoleId): Observable<string[]> {
        let url = 'UniversalReports/api/punter-analysis/filter/username-suggestion';
        return this.httpService.post<string[]>(url, {
            userName: userName,
            roleId: roleId
        });
    }

    queryProductTreeviewItems(): Observable<TreeviewItem[]> {
        let url = 'UniversalReports/api/punter-analysis/filter/product-sport-bet-type';
        return this.httpService.post<ProductSportTypeBetType[]>(url).map(list => {
            const productItems: TreeviewItem[] = [];
            const productNames = _.uniq(list.map(x => x.ProductName));
            productNames.forEach(productName => {
                const productItem = new TreeviewItem({ text: productName, value: productName, collapsed: true });
                const listByProductName = list.filter(x => x.ProductName === productName);
                const renderTypeByProductName = listByProductName[0].RenderType;
                switch (renderTypeByProductName) {
                    case RenderType.Product_SportGroup_Sport_BetType:
                        const sportGroupItems: TreeviewItem[] = [];
                        const sportGroups = _.uniq(listByProductName.map(x => x.SportGroup));
                        sportGroups.forEach(sportGroup => {
                            const sportGroupItem = new TreeviewItem({ text: sportGroup, value: sportGroup, collapsed: true });
                            const listBySportGroup = listByProductName.filter(x => x.SportGroup === sportGroup);
                            const sportNames = _.uniq(listBySportGroup.map(x => x.SportName));
                            const sportNameItems: TreeviewItem[] = [];
                            sportNames.forEach(sportName => {
                                const sportNameItem = new TreeviewItem({ text: sportName, value: sportName, collapsed: true });
                                const listBySportName = listBySportGroup.filter(x => x.SportName === sportName);
                                sportNameItem.children = listBySportName.map(x => new TreeviewItem({ text: x.BetTypeName, value: x.Value }));
                                sportNameItems.push(sportNameItem);
                            });
                            sportGroupItem.children = sportNameItems;
                            sportGroupItems.push(sportGroupItem);
                        });
                        productItem.children = sportGroupItems;
                        break;
                    case RenderType.Product_Sport_BetType:
                        const sportNames = _.uniq(listByProductName.map(x => x.SportName));
                        const sportNameItems: TreeviewItem[] = [];
                        sportNames.forEach(sportName => {
                            const sportNameItem = new TreeviewItem({ text: sportName, value: sportName, collapsed: true });
                            const listBySportName = listByProductName.filter(x => x.SportName === sportName);
                            sportNameItem.children = listBySportName.map(x => new TreeviewItem({ text: x.BetTypeName, value: x.Value }));
                            sportNameItems.push(sportNameItem);
                        });
                        productItem.children = sportNameItems;
                        break;
                    case RenderType.Product_BetType:
                        productItem.children = listByProductName.map(x => new TreeviewItem({ text: x.BetTypeName, value: x.Value }));
                        break;
                }

                productItems.push(productItem);
            });

            return productItems;
        });
    }

    checkDatabaseAvailable(): Observable<boolean> {
        let url = 'UniversalReports/api/punter-analysis/filter/available-database';
        return this.httpService.post<boolean>(url);
    }
}
