import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridComponent } from './grid.component';
import { GridService } from './grid.service';
import { TicketGridService } from './ticket-grid/ticket-grid.service';
import { ProductGridService } from './product-grid/product-grid.service';
import { TicketGridComponent } from './ticket-grid/ticket-grid.component';
import { ProductGridComponent } from './product-grid/product-grid.component';
import { NumberFormatModule } from 'nap-components/number-format';
import { BreadcrumbModule } from 'nap-components/breadcrumb';
import { PaginationService, PaginationConfig, PaginationModule } from 'nap-components/pagination';
import { CustomPaginationConfig } from '../common/config';

@NgModule({
    imports: [
        CommonModule,
        NumberFormatModule,
        BreadcrumbModule,
        PaginationModule
    ],
    schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
    declarations: [
        GridComponent,
        ProductGridComponent,
        TicketGridComponent
    ],
    exports: [
        GridComponent
    ],
    providers: [
        GridService,
        ProductGridService,
        TicketGridService,
        PaginationService,
        PaginationConfig,
        { provide: PaginationConfig, useClass: CustomPaginationConfig },
    ]
})

export class GridModule { }
