import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PaginationModule } from 'nap-components/src/pagination';
import { DecimalFormatDirective } from 'nap-components/src/number/decimal-format.directive';
import { IntegerFormatDirective } from 'nap-components/src/number/integer-format.directive';
import { GridComponent } from './grid.component';
import { GridService } from './grid.service';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { SummaryGridComponent } from './summary-grid/summary-grid.component';
import { SummaryGridService } from './summary-grid/summary-grid.service';
import { DetailGridComponent } from './detail-grid/detail-grid.component';
import { DetailGridService } from './detail-grid/detail-grid.service';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        PaginationModule
    ],
    declarations: [
        DecimalFormatDirective,
        IntegerFormatDirective,
        GridComponent,
        BreadcrumbComponent,
        SummaryGridComponent,
        DetailGridComponent
    ],
    exports: [
        GridComponent
    ],
    providers: [
        GridService,
        SummaryGridService,
        DetailGridService
    ]
})
export class GridModule { }
