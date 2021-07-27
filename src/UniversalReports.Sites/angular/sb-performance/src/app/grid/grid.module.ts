import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BreadcrumbModule } from 'nap-components/breadcrumb';
import { GridComponent } from './grid.component';
import { MarginBySiteGridComponent } from './margin-by-site-grid/margin-by-site-grid.component';
import { GridService } from './grid.service';
import { MarginBySiteGridService } from './margin-by-site-grid/margin-by-site-grid.service';
import { NumberFormatModule } from 'nap-components/number-format';

@NgModule({
  declarations: [
    GridComponent,
    MarginBySiteGridComponent
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
    MarginBySiteGridService
  ]
})
export class GridModule { }
