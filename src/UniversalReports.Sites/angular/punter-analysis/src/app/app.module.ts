import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { HttpService } from './components/http.service';
import { HttpService as HttpService2 } from 'nap-components/src/http.service';
import { LegacyService } from 'nap-components/src/legacy.service';
import { ExceptionService } from 'nap-components/src/exception.service';
import { HeaderModule } from 'nap-components/src/header';
import { ToastService } from 'nap-components/src/toast';
import { SpinnerService } from 'nap-components/src/spinner';

import { AppComponent } from './app.component';
import { FilterComponent } from './filter/filter.component';
import { PeriodTypeComponent } from './filter/period-type/period-type.component';
import { DatePickerToggle } from './filter/period-type/date-picker-toggle/date-picker-toggle.directive';
import { DatePickerComponent } from './filter/period-type/date-picker/date-picker.component';
import { WeekPickerComponent } from './filter/period-type/week-picker/week-picker.component';

@NgModule({
  declarations: [
    AppComponent,
    FilterComponent,
    PeriodTypeComponent,
    DatePickerComponent,
    WeekPickerComponent,
    DatePickerToggle
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    CommonModule,
    NgbModule.forRoot(),
    HeaderModule.forRoot()
  ],
  providers: [
    HttpService,
    HttpService2,
    ExceptionService,
    LegacyService,
    ToastService,
    SpinnerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
