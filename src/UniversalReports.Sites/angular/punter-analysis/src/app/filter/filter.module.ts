import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TreeviewModule } from 'ngx-treeview';

import { LegendModule } from 'nap-components/src/legend';
import { DateModule } from 'nap-components/src/date';
import { InputIntegerDirective } from 'nap-components/src/number/input-integer.directive';
import { DropdownTypeaheadModule } from 'nap-components/src/dropdown-typeahead';
import { DropdownSelectModule } from 'nap-components/src/dropdown-select';

import { PeriodTypeModule } from './period-type/period-type.module';
import { FilterComponent } from './filter.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        TreeviewModule.forRoot(),
        LegendModule,
        DateModule,
        DropdownTypeaheadModule,
        DropdownSelectModule,
        PeriodTypeModule
    ],
    declarations: [
        InputIntegerDirective,
        FilterComponent
    ],
    exports: [
        FilterComponent
    ]
})
export class FilterModule { }
