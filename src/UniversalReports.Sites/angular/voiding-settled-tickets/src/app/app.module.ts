import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER  } from '@angular/core';
import * as moment from 'moment';
import { AppComponent } from './app.component';
import { FilterComponent } from './filter/filter.component';
import { NavbarModule, NavbarService } from 'nap-components/navbar';
import { SpinnerModule } from 'nap-components/spinner';
import { CustomNavbarService } from './custom-navbar-service';
import { HttpModule } from 'nap-components/http';
import { DateModule } from 'nap-components/date';
import { AppService } from './app.service';
import { CONFIG, DateConfig } from './common/config';
import { FormsModule } from '@angular/forms';
import { GridModule } from './grid/grid.module';

@NgModule({
  declarations: [
    AppComponent,
    FilterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    DateModule,
    HttpModule,
    NavbarModule,
    SpinnerModule,
    GridModule,
  ],
  providers: [
     { provide: NavbarService, useClass: CustomNavbarService },
     AppService,
     {
       provide: APP_INITIALIZER,
       useFactory: initConfiguration,
       deps: [AppService],
       multi: true
     },
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }

export function initConfiguration(service: AppService) {
  return () => new Promise(resolve => {
    service.getToday().subscribe(model => {
      const today = moment.utc(model);
      CONFIG.date = new DateConfig(today);
      resolve(true);
    });
  });
}

