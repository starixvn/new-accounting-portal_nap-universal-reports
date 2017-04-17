import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { DecimalFormatDirective } from './components/decimal-format.directive';
import { IntegerFormatDirective } from './components/integer-format.directive';
import { PercentFormatDirective } from './components/percent-format.directive';
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
        PercentFormatDirective,
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
