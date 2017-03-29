import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { DropdownTreeviewModule } from 'ng2-dropdown-treeview';

import { LegendModule } from 'nap-components/src/legend';
import { InputIntegerDirective } from 'nap-components/src/number/input-integer.directive';

import { DropdownTypeaheadModule } from '../components/dropdown-typeahead';
import { PeriodTypeModule } from './period-type/period-type.module';
import { FilterComponent } from './filter.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        NgbDatepickerModule.forRoot(),
        NgbModalModule.forRoot(),
        DropdownTreeviewModule.forRoot(),
        LegendModule.forRoot(),
        DropdownTypeaheadModule.forRoot(),
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
