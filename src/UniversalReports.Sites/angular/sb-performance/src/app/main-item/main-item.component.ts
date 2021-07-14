import { Component, Input } from '@angular/core';
import * as _ from 'lodash';
import { MainItemModel } from '../common/model';

@Component({
  selector: 'app-main-item',
  templateUrl: './main-item.component.html',
  styleUrls: ['./main-item.component.scss']
})
export class MainItemComponent {
  @Input() title: string;
  @Input() firstColumnHeader: string;
  @Input() isShowFullColumn: boolean;
  @Input() isChangedColumnName = false;
  @Input() items: MainItemModel;
  sortColumnName = '';
  sortDirection = '';

  constructor() { }

  get hasData(): boolean {
    return this.items !== null && this.items.Entities.length > 0;
  }

  sort(sortColumnName: string) {
    if (this.sortColumnName !== sortColumnName) {
      this.sortDirection = '';
    }

    this.sortColumnName = sortColumnName;
    this.sortDirection = this.sortDirection !== 'asc' ? 'asc' : 'desc';
    this.items.Entities = _.orderBy(this.items.Entities, this.sortColumnName, this.sortDirection);
  }
}
