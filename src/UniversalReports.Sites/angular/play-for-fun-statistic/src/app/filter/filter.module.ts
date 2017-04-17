import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DateModule } from 'nap-components/src/date';
import { LegendModule } from 'nap-components/src/legend';
import { DropdownTypeaheadModule } from 'nap-components/src/dropdown-typeahead';
import { DropdownSelectModule } from 'nap-components/src/dropdown-select';
import { NoteModule } from 'nap-components/src/note';
import { FilterComponent } from './filter.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        DateModule,
        LegendModule,
        DropdownTypeaheadModule,
        DropdownSelectModule,
        NoteModule
    ],
    declarations: [
        FilterComponent
    ],
    exports: [
        FilterComponent
    ]
})
export class FilterModule { }
