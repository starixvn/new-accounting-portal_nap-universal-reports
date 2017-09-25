import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import * as moment from 'moment';
import { AppComponent } from './app.component';
import { FilterComponent } from './filter/filter.component';
import { DropdownSelectModule } from 'nap-components/dropdown-select';
import { DateModule } from 'nap-components/date';
import { NavbarModule, NavbarService } from 'nap-components/navbar';
import { ToastService, ToastModule } from 'nap-components/toast';
import { SpinnerService, SpinnerModule } from 'nap-components/spinner';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LegendModule } from 'nap-components/legend';
import { PaginationModule, PaginationConfig } from 'nap-components/pagination';
import { UpdatedUsernameComponent } from './updated-username/updated-username.component';
import { UpdatedCreditComponent } from './updated-credit/updated-credit.component';
import { GridComponent } from './grid/grid.component';
import { NumberFormatModule } from 'nap-components/number-format';
import { BreadcrumbModule } from 'nap-components/breadcrumb';

@NgModule({
  declarations: [
    AppComponent,
    FilterComponent,
    UpdatedUsernameComponent,
    UpdatedCreditComponent,
    GridComponent
  ],
  imports: [
    BrowserModule,
    DropdownSelectModule,
    DateModule,
    NgbModule,
    LegendModule.forRoot(),
    PaginationModule.forRoot(),
    NumberFormatModule,
    BreadcrumbModule,
    SpinnerModule.forRoot(),
    ToastModule.forRoot(),
    NavbarModule.forRoot()
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private navbarService: NavbarService) {
    navbarService.url = 'state-api/application/header';
    navbarService.userMenus = [
        {
            name: 'Change Password',
            link: 'UserInfo/ChangePassword'
        },
        {
            name: 'Sign Out',
            link: 'UserLogin/Login/LogOut'
        }
    ];
}
}
