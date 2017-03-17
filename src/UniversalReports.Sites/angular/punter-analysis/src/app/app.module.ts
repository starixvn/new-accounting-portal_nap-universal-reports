import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { HttpService } from './components/http.service';
import { HttpService as HttpService2 } from 'nap-components/src/http.service';
import { LegacyService } from 'nap-components/src/legacy.service';
import { ExceptionService } from 'nap-components/src/exception.service';
import { HeaderModule } from 'nap-components/src/header';
import { DropdownSelectModule } from 'nap-components/src/dropdown-select';
import { ToastService } from 'nap-components/src/toast';
import { SpinnerService } from 'nap-components/src/spinner';

import { AppComponent } from './app.component';
import { FilterComponent } from './filter/filter.component';
import { PeriodTypeModule } from './filter/period-type/period-type.module';

@NgModule({
  declarations: [
    AppComponent,
    FilterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    CommonModule,
    HeaderModule.forRoot(),
    DropdownSelectModule.forRoot(),
    PeriodTypeModule
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
