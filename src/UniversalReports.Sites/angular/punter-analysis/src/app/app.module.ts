import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { HttpService } from '../../../components/src/http.service';
import { LegacyService } from '../../../components/src/legacy.service';
import { ExceptionService } from '../../../components/src/exception.service';
import { HeaderComponent } from '../../../components/src/header/header.component';
import { HeaderModule } from '../../../components/src/header/header.module';
import { ToastService } from '../../../components/src/toast';
import { SpinnerService } from '../../../components/src/spinner';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    CommonModule,
    HeaderModule.forRoot()
  ],
  providers: [
    HttpService,
    ExceptionService,
    LegacyService,
    ToastService,
    SpinnerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
