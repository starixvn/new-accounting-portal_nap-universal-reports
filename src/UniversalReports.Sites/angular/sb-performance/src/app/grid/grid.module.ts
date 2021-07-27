import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BreadcrumbModule } from 'nap-components/breadcrumb';
import { GridComponent } from './grid.component';
import { SiteGridComponent } from './site-grid/site-grid.component';
import { GridService } from './grid.service';
import { SiteGridService } from './site-grid/site-grid.service';
import { NumberFormatModule } from 'nap-components/number-format';
import { LeagueGridComponent } from './league-grid/league-grid.component';

@NgModule({
  declarations: [
    GridComponent,
    SiteGridComponent,
    LeagueGridComponent
  ],
  imports: [
    CommonModule,
    BreadcrumbModule,
    NumberFormatModule
  ],
  exports: [
    GridComponent
  ],
  providers: [
    GridService,
    SiteGridService
  ]
})
export class GridModule { }
