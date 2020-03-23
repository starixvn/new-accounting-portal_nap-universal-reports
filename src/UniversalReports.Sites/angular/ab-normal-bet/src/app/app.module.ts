import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FilterComponent } from './filter/filter.component';
import { MeberGridComponent } from './meber-grid/meber-grid.component';
import { LicenseeGridComponent } from './licensee-grid/licensee-grid.component';
import { MemberGridComponent } from './member-grid/member-grid.component';

@NgModule({
  declarations: [
    AppComponent,
    FilterComponent,
    MeberGridComponent,
    LicenseeGridComponent,
    MemberGridComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
