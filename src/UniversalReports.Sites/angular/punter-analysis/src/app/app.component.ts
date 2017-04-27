import { Component } from '@angular/core';
import { FilterModel } from './filter/filter.model';
import { SearchBy } from './filter/filter.model.main';


@Component({
  selector: 'nap-root',
  templateUrl: './app.component.html',
  styleUrls: [
    '../../../components/src/style/layout.scss',
    '../../../components/src/style/header.scss'
  ]
})
export class AppComponent {
  SearchBy = SearchBy;
  filterModel: FilterModel;

  onReset() {
    this.filterModel = undefined;
  }

  onGenerate(filterModel: FilterModel) {
    this.filterModel = filterModel;
  }
}
