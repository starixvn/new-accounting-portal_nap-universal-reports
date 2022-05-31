import { FormsModule } from '@angular/forms';
import { HttpModule } from 'nap-components/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FilterComponent } from './filter/filter.component';
import { SpinnerModule } from 'nap-components/spinner';
import { NavbarModule, NavbarService } from 'nap-components/navbar';
import { CustomNavbarService } from './custom-navbar-service';

@NgModule({
  declarations: [
    AppComponent,
    FilterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule.forRoot(),
    NavbarModule.forRoot(),
    SpinnerModule.forRoot(),
  ],
  providers: [
    { provide: NavbarService, useClass: CustomNavbarService }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
