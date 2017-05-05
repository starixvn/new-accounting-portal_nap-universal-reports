import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DropdownSelectModule } from 'nap-components/src/dropdown-select';
import { DateModule } from 'nap-components/src/date';
import { PeriodTypeComponent } from './period-type.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        DateModule
    ],
    declarations: [
        PeriodTypeComponent
    ],
    exports: [
        PeriodTypeComponent
    ]
})
export class PeriodTypeModule { }
