import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PeriodTypeModule } from './period-type/period-type.module';
import { FilterComponent } from './filter.component';
import { FilterItemTreeviewPipe } from './filter-item-treeview.pipe';
import { LegendModule } from 'nap-components/legend';

@NgModule({
  declarations: [
    FilterComponent,
    FilterItemTreeviewPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    LegendModule,
    PeriodTypeModule
  ],
  exports: [
    FilterComponent
  ]
})
export class FilterModule { }
