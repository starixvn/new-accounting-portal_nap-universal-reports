import { ItemModel } from '../../../app/common/model';

export interface SiteDataItemModel extends ItemModel {
  Sport: string;
  ActiveMembers: string;
}

export interface SiteDataModel {
  Entities: SiteDataItemModel[];
  Total: SiteDataItemModel;
}
