import { Component } from '@angular/core';
import { FilterModel } from './filter/filter.model';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss',
    '../../node_modules/nap-theme/scss/header.scss'
  ],
})
export class AppComponent {
  filterModel: FilterModel;
  generate(filterModel: FilterModel) {
    this.filterModel = filterModel;
  }
}
