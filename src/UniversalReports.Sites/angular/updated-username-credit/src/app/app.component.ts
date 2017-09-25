import { Component } from '@angular/core';
import { FilterModel } from './filter/filter.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'app';
  filterModel: FilterModel;

  generate(filterModel: FilterModel) {
    this.filterModel = filterModel;
    console.log(
      'Startdate is ' + filterModel.fromDate +
      ' & Enddate is ' + filterModel.toDate +
      ' & User name is ' + filterModel.userName);
  }
}
