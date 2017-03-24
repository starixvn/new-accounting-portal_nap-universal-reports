import { Component } from '@angular/core';
import { PaginationInstance } from 'ng2-pagination';
import { PagingModel } from '../../../components/src/paging/paging.model';
import { AppService } from './app.service';
import { FilterModel } from './filter/filter.model';
import { SummaryData } from './grid/summary-grid/summary-grid.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [
    '../../../components/src/style/layout.scss',
    '../../../components/src/style/header.scss'
  ],
  providers: [
    AppService
  ]
})
export class AppComponent {
  summaryData: SummaryData;
  pagingModel: PagingModel;
  meals: string[];

  constructor(private service: AppService) {
  }

  onGenerate(filterModel: FilterModel) {
    this.service.querySummary(filterModel).subscribe(data => this.summaryData = data);
  }
}
