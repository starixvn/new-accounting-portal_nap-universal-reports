import { Pipe, PipeTransform } from '@angular/core';
import { TreeviewItem } from 'ngx-treeview';
import { FilterItemModel } from './filter.model';
import * as _ from 'lodash';

@Pipe({
  name: 'filterItemTreeview'
})
export class FilterItemTreeviewPipe implements PipeTransform {

  transform(filterModels: FilterItemModel[]): TreeviewItem[] {
    const treeItems: TreeviewItem[] = [];

    if (_.isNil(filterModels)) {
      return undefined;
    }

    filterModels.forEach(itemModel => {
      const item = new TreeviewItem({ text: itemModel.Name, value: itemModel.Id });
      treeItems.push(item);
    });

    return treeItems;
  }

}
