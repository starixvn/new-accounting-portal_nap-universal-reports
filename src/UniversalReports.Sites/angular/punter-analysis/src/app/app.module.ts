import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { DropdownTreeviewModule } from 'ng2-dropdown-treeview';

import { HttpService } from './components/http.service';
import { HttpService as HttpService2 } from 'nap-components/src/http.service';
import { LegacyService } from 'nap-components/src/legacy.service';
import { ExceptionService } from 'nap-components/src/exception.service';
import { HeaderModule } from 'nap-components/src/header';
import { DropdownSelectModule } from 'nap-components/src/dropdown-select';
import { DropdownTypeaheadModule } from './components/dropdown-typeahead';
import { ToastService } from 'nap-components/src/toast';
import { SpinnerService } from 'nap-components/src/spinner';

import { DecimalTextDirective } from './directive/decimal-text.deriective';
import { IntegerTextDirective } from './directive/integer-text.deriective';
import { MarginTextDirective } from './directive/margin-text.deriective';
import { DateByPeriodTextDirective } from './directive/date-by-period-text.deriective';


import { AppComponent } from './app.component';
import { PagingComponent } from '../../../components/src/paging/paging.component'
import { FilterComponent } from './filter/filter.component';
import { PeriodTypeModule } from './filter/period-type/period-type.module';
import { SummaryGridComponent } from './grid/summary-grid/summary-grid.component';
import { BetCountGridComponent } from './grid/bet-count-grid/bet-count-grid.component';
import { AssociatedAccountGridComponent } from './grid/associated-account-grid/associated-account-grid.component';
import { SportTypeGridComponent } from './grid/sport-type-grid/sport-type-grid.component';
import { BetTypeGridComponent } from './grid/bet-type-grid/bet-type-grid.component';
import { LeagueGridComponent } from './grid/league-grid/league-grid.component';

@NgModule({
  declarations: [
    DecimalTextDirective,
    IntegerTextDirective,
    MarginTextDirective,
    DateByPeriodTextDirective,
    AppComponent,
    FilterComponent,
    PagingComponent,
    SummaryGridComponent,
    BetCountGridComponent,
    AssociatedAccountGridComponent,
    SportTypeGridComponent,
    BetTypeGridComponent,
    LeagueGridComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    CommonModule,
    DropdownTreeviewModule.forRoot(),
    HeaderModule.forRoot(),
    DropdownSelectModule.forRoot(),
    DropdownTypeaheadModule.forRoot(),
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
