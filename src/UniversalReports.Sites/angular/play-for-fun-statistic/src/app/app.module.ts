import { NavbarService } from 'nap-components/navbar';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { HttpService } from 'nap-components/src/http.service';
import { LegacyService } from 'nap-components/src/legacy.service';
import { ExceptionService } from 'nap-components/src/exception.service';
import { NavbarModule } from 'nap-components/src/navbar';
import { ToastService, ToastModule } from 'nap-components/src/toast';
import { SpinnerService, SpinnerModule } from 'nap-components/src/spinner';

import { FilterModule } from './filter/filter.module';
import { GridModule } from './grid/grid.module';
import { AppComponent } from './app.component';
import { CustomNavbarService } from './custom-navbar-service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    CommonModule,
    SpinnerModule,
    ToastModule,
    NavbarModule,
    FilterModule,
    GridModule
  ],
  providers: [
    HttpService,
    ExceptionService,
    LegacyService,
    ToastService,
    SpinnerService,
   { provide: NavbarService, useClass: CustomNavbarService },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
