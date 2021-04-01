import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PeriodTypeModule } from './period-type/period-type.module';
import { FilterComponent } from './filter.component';
import { FilterItemTreeviewPipe } from './filter-item-treeview.pipe';
import { LegendModule, LegendService } from 'nap-components/legend';
import { TreeviewModule } from 'ngx-treeview';

@NgModule({
  declarations: [
    FilterComponent,
    FilterItemTreeviewPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    LegendModule,
    PeriodTypeModule,
    TreeviewModule.forRoot(),
    LegendModule.forRoot(),
  ],
  exports: [
    FilterComponent
  ]
})
export class FilterModule {
  constructor(
    private readonly legendService: LegendService
  ) {
    legendService.resolveUrl = (id) => {
      return `https://nap.oneops.net/NAP-Reports-Legend-API/api/legend/${id}`;
    };
  }
}
