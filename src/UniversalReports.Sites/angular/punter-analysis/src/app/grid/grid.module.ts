import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PaginationModule } from 'nap-components/src/pagination';

import { DecimalFormatDirective } from './directives/decimal-format.directive';
import { IntegerFormatDirective } from './directives/integer-format.directive';
import { PercentFormatDirective } from './directives/percent-format.directive';
import { DateByPeriodTextDirective } from './directives/date-by-period-text.directive';
import { GridComponent } from './grid.component';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { SummaryGridComponent } from './summary-grid/summary-grid.component';
import { BetCountGridComponent } from './bet-count-grid/bet-count-grid.component';
import { AssociatedAccountGridComponent } from './associated-account-grid/associated-account-grid.component';
import { SportTypeGridComponent } from './sport-type-grid/sport-type-grid.component';
import { BetTypeGridComponent } from './bet-type-grid/bet-type-grid.component';
import { LeagueGridComponent } from './league-grid/league-grid.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        PaginationModule.forRoot()
    ],
    declarations: [
        DecimalFormatDirective,
        IntegerFormatDirective,
        PercentFormatDirective,
        DateByPeriodTextDirective,
        GridComponent,
        BreadcrumbComponent,
        SummaryGridComponent,
        BetCountGridComponent,
        AssociatedAccountGridComponent,
        SportTypeGridComponent,
        BetTypeGridComponent,
        LeagueGridComponent
    ],
    exports: [
        GridComponent
    ]
})
export class GridModule { }
