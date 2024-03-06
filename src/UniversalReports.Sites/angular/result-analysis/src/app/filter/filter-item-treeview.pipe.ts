import { Pipe, PipeTransform } from '@angular/core';
import { TreeviewItem } from 'ngx-treeview';
import { LeagueModel } from './filter.model';
import * as _ from 'lodash';

@Pipe({
  name: 'leagueGroupTreeviewItem'
})
export class FilterItemTreeviewPipe implements PipeTransform {

  transform(values: LeagueModel[]): TreeviewItem[] {
    const treeItems: TreeviewItem[] = [];

    if (values.length === 0) {
      return [];
    }

    values = _.uniqBy(values, 'GroupId');

    values.forEach(data => {
      const item = new TreeviewItem({ text: data.GroupName, value: data.GroupId });
      treeItems.push(item);
    });

    return treeItems;
  }
}
