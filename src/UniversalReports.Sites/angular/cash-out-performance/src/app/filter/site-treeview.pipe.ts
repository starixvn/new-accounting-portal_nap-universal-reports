import { Pipe, PipeTransform } from '@angular/core';
import * as _ from 'lodash';
import { SiteModel } from './filter.model';
import { TreeviewItem } from 'ngx-treeview';

@Pipe({
  name: 'siteTreeview'
})

export class SiteTreeviewPipe implements PipeTransform {
  transform(sites: SiteModel[]): TreeviewItem[] {
    const creditGroup = false;
    const creditSites = new TreeviewItem({ text: 'Credit', value: 0 });
    const depoSitSites = new TreeviewItem({ text: 'Deposit', value: 1 });

    if (_.isNil(sites)) {
      return undefined;
    }

    sites.forEach(site => {
      const item = new TreeviewItem({ text: site.Name, value: site.Name });
      let groupTreeviewItem: TreeviewItem;

      groupTreeviewItem = site.IsDeposit ? depoSitSites: creditSites;

      if (_.isNil(groupTreeviewItem.children)) {
        groupTreeviewItem.children = [item];
      } else {
        groupTreeviewItem.children.push(item);
      }
    });

    const siteTreeItems = [
      creditSites,
      depoSitSites
    ];

    return siteTreeItems.filter(item => !_.isNil(item.children) && item.children.length > 0);
  }
}

