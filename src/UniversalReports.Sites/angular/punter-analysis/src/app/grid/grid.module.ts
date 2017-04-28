import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TreeviewModule } from 'ngx-treeview';
import { PaginationModule } from 'nap-components/src/pagination';
import { NumberFormatModule } from 'nap-components/src/number/number-format.module';
import { GridComponent } from './grid.component';
import { GridService } from './grid.service';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { SummaryGridComponent } from './summary-grid/summary-grid.component';
import { SummaryGridService } from './summary-grid/summary-grid.service';
import { BetCountGridComponent } from './bet-count-grid/bet-count-grid.component';
import { BetCountGridService } from './bet-count-grid/bet-count-grid.service';
import { AssociatedAccountGridComponent } from './associated-account-grid/associated-account-grid.component';
import { AssociatedAccountGridService } from './associated-account-grid/associated-account-grid.service';
import { SportTypeGridComponent } from './sport-type-grid/sport-type-grid.component';
import { SportTypeGridService } from './sport-type-grid/sport-type-grid.service';
import { BetTypeGridComponent } from './bet-type-grid/bet-type-grid.component';
import { BetTypeGridService } from './bet-type-grid/bet-type-grid.service';
import { LeagueGridComponent } from './league-grid/league-grid.component';
import { LeagueGridService } from './league-grid/league-grid.service';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        TreeviewModule.forRoot(),
        PaginationModule,
        NumberFormatModule
    ],
    declarations: [
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
    ],
    providers: [
        GridService,
        SummaryGridService,
        BetCountGridService,
        AssociatedAccountGridService,
        SportTypeGridService,
        BetTypeGridService,
        LeagueGridService
    ]
})
export class GridModule { }
