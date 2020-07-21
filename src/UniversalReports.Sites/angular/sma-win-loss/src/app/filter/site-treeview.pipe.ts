import { Pipe, PipeTransform } from '@angular/core';
import * as _ from 'lodash';
import { Site } from './filter.model';
import { TreeviewItem } from 'ngx-treeview';

@Pipe({
  name: 'siteTreeview'
})

export class SiteTreeviewPipe implements PipeTransform {
  transform(sites: Site[]): TreeviewItem[] {
    const creditGroup = 0;
    const treeItems: TreeviewItem[] = [];

    const creditSites = new TreeviewItem({ text: 'Credit Group', value: 0 });
    const licenseeSites = new TreeviewItem({ text: 'Licensee Group', value: 1 });

    if (_.isNil(sites)) {
      return undefined;
    }

    sites.forEach(site => {
      const item = new TreeviewItem({ text: site.SiteName, value: site.SiteId });
      let groupTreeviewItem: TreeviewItem;

      switch (site.SiteGroup) {
        case creditGroup:
          groupTreeviewItem = creditSites;
          break;
        default:
          groupTreeviewItem = licenseeSites;
          break;
      }

      if (_.isNil(groupTreeviewItem.children)) {
        groupTreeviewItem.children = [item];
      } else {
        groupTreeviewItem.children.push(item);
      }
    });

    const siteTreeItems = [
      creditSites,
      licenseeSites
    ];

    return siteTreeItems.filter(item => !_.isNil(item.children) && item.children.length > 0);
  }
}

