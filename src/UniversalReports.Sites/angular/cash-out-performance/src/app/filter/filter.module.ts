import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FilterComponent } from './filter.component';
import { FilterItemTreeviewPipe } from './filter-item-treeview.pipe';
import { LegendModule, LegendService } from 'nap-components/legend';
import { TreeviewModule } from 'ngx-treeview';
import { DropdownSelectModule } from 'nap-components/dropdown-select';
import { DateModule } from 'nap-components/date';
import { DropdownTypeaheadModule } from 'nap-components/dropdown-typeahead';

@NgModule({
  declarations: [
    FilterComponent,
    FilterItemTreeviewPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    LegendModule,
    TreeviewModule.forRoot(),
    LegendModule.forRoot(),
    DropdownSelectModule,
    DropdownTypeaheadModule,
    DateModule
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
