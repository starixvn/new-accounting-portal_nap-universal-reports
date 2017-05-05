import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { DatePickerComponent } from './date-picker/date-picker.component';
import { DatePickerToggleDirective } from './date-picker-toggle/date-picker-toggle.directive';
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
        DatePickerComponent,
        WeekPickerComponent,
        MonthPickerComponent,
        YearPickerComponent,
        DatePickerToggleDirective
    ],
    exports: [
        DatePickerComponent,
        WeekPickerComponent,
        MonthPickerComponent,
        YearPickerComponent,
        DatePickerToggleDirective
    ]
})
export class DateModule { }
