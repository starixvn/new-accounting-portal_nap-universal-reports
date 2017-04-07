import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { DropdownSelectModule } from 'nap-components/src/dropdown-select';
import { PeriodTypeComponent } from './period-type.component';
import { DatePickerToggleDirective } from './date-picker-toggle/date-picker-toggle.directive';
import { DatePickerComponent } from './date-picker/date-picker.component';
import { WeekPickerComponent } from './week-picker/week-picker.component';
import { MonthPickerComponent } from './month-picker/month-picker.component';
import { YearPickerComponent } from './year-picker/year-picker.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        NgbDatepickerModule.forRoot()
    ],
    declarations: [
        DatePickerToggleDirective,
        PeriodTypeComponent,
        DatePickerComponent,
        WeekPickerComponent,
        MonthPickerComponent,
        YearPickerComponent
    ],
    exports: [
        PeriodTypeComponent
    ]
})
export class PeriodTypeModule { }
