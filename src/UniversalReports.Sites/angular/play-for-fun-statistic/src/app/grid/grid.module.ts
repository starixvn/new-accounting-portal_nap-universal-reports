import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { DecimalFormatDirective } from 'nap-components/src/number/decimal-format.directive';
import { IntegerFormatDirective } from 'nap-components/src/number/integer-format.directive';
import { GridComponent } from './grid.component';
import { GridService } from './grid.service';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule
    ],
    declarations: [
        DecimalFormatDirective,
        IntegerFormatDirective,
        GridComponent,
        BreadcrumbComponent
    ],
    exports: [
        GridComponent
    ],
    providers: [
        GridService
    ]
})
export class GridModule { }
