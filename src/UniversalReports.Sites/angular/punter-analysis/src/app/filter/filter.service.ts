import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import * as _ from 'lodash';
import { TreeviewItem, TreeItem } from 'ng2-dropdown-treeview';
import { RoleId } from 'nap-components/src/model';
import { HttpService } from 'nap-components/src/http.service';
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
        const url = 'api/punter-analysis/filter/available-date-range';
        return this.httpService.post<DataWarehouseDateRange>(url);
    }

    queryUserNameSuggestion(userName: string, roleId: RoleId): Observable<string[]> {
        const url = 'api/punter-analysis/filter/username-suggestion';
        return this.httpService.post<string[]>(url, {
            userName: userName,
            roleId: roleId
        });
    }

    queryProductTreeviewItems(): Observable<TreeviewItem[]> {
        const url = 'api/punter-analysis/filter/product-sport-bet-type';
        return this.httpService.post<ProductSportTypeBetType[]>(url).map(list => {
            return this.buildProductTreeviewItems(list);
        });
    }

    checkDatabaseAvailable(): Observable<boolean> {
        const url = 'api/punter-analysis/filter/available-database';
        return this.httpService.post<boolean>(url);
    }

    private buildProductTreeviewItems(list: ProductSportTypeBetType[]): TreeviewItem[] {
        const productItems: TreeviewItem[] = [];
        const productNames = _.uniq(list.map(x => x.ProductName));
        productNames.forEach(productName => {
            const productItem = new TreeviewItem({
                text: productName,
                value: productName,
                collapsed: true
            });
            productItems.push(productItem);
            const listByProductName = list.filter(x => x.ProductName === productName);
            listByProductName.forEach(item => {
                let currentTreeviewItem = productItem;
                const treeItems = this.getProductTreeItems(item);
                treeItems.forEach(treeItem => {
                    let childItem: TreeviewItem;
                    if (currentTreeviewItem.children) {
                        for (let i = 0; i < currentTreeviewItem.children.length; i++) {
                            const child = currentTreeviewItem.children[i];
                            if (child.text === treeItem.text && child.value === treeItem.value) {
                                childItem = child;
                                break;
                            }
                        }
                    }
                    if (!childItem) {
                        childItem = new TreeviewItem(treeItem);
                        if (currentTreeviewItem.children) {
                            currentTreeviewItem.children.push(childItem);
                        } else {
                            currentTreeviewItem.children = [childItem];
                        }
                    }
                    currentTreeviewItem = childItem;
                });
            });
        });

        return productItems;
    }

    private getProductTreeItems(item: ProductSportTypeBetType): TreeItem[] {
        let renderTypeNodes: string[] = [];
        switch (item.RenderType) {
            case RenderType.Product_SportGroup_Sport_BetType:
                renderTypeNodes = [item.SportGroup, item.SportName];
                break;
            case RenderType.Product_Sport_BetType:
                renderTypeNodes = [item.SportName];
                break;
        }

        const treeItems = renderTypeNodes.map(node => <TreeItem>{
            text: node,
            value: item.RenderType,
            collapsed: true
        });
        treeItems.push({
            text: item.BetTypeName,
            value: item.Value,
            collapsed: true
        });
        return treeItems;
    }
}
