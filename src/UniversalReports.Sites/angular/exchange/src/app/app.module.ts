import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FilterComponent } from './filter/filter.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DropdownSelectModule } from 'nap-components/dropdown-select';
import { DateModule } from 'nap-components/date';
import { NavbarModule, NavbarService } from 'nap-components/navbar';
import { TreeviewModule } from 'ngx-treeview';

import { ToastService, ToastModule } from 'nap-components/toast';
import { SpinnerService, SpinnerModule } from 'nap-components/spinner';
import { NumberFormatModule } from 'nap-components/number-format';
import { BreadcrumbModule } from 'nap-components/breadcrumb';
import { PaginationModule, PaginationConfig } from 'nap-components/pagination';
import { CustomPaginationConfig } from './common/config';
import { CustomNavbarService } from './custom-navbar-service';
import { GridComponent } from './grid/grid.component';

@NgModule({
  declarations: [
    AppComponent,
    FilterComponent,
    GridComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    TreeviewModule.forRoot(),
    DropdownSelectModule,
    DateModule,
    PaginationModule.forRoot(),
    NumberFormatModule,
    BreadcrumbModule,
    SpinnerModule.forRoot(),
    ToastModule.forRoot(),
    NavbarModule.forRoot()
  ],
  providers: [
    { provide: NavbarService, useClass: CustomNavbarService },
    { provide: PaginationConfig, useClass: CustomPaginationConfig }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
