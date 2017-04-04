import { Component } from '@angular/core';
import { FilterModel } from './filter/filter.model';

@Component({
  selector: 'nap-root',
  templateUrl: './app.component.html',
  styleUrls: [
    '../../../components/src/style/layout.scss',
    '../../../components/src/style/header.scss'
  ]
})
export class AppComponent {
  filterModel: FilterModel;

  onReset() {
    this.filterModel = undefined;
  }

  onGenerate(filterModel: FilterModel) {
    this.filterModel = filterModel;
  }
}
