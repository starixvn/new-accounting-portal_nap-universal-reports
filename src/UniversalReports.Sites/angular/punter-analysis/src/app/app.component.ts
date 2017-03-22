import { Component } from '@angular/core';
import { AppService } from './app.service';
import { FilterModel } from './filter/filter.model';

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
  constructor(private service: AppService) { }

  onGenerate(filterModel: FilterModel) {
    this.service.querySummary(filterModel).subscribe(result => {
      console.log(result);
    });
  }
}
