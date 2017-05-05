import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DecimalFormatDirective } from './decimal-format.directive';
import { IntegerFormatDirective } from './integer-format.directive';
import { PercentFormatDirective } from './percent-format.directive';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        DecimalFormatDirective,
        IntegerFormatDirective,
        PercentFormatDirective
    ],
    exports: [
        DecimalFormatDirective,
        IntegerFormatDirective,
        PercentFormatDirective
    ]
})
export class NumberFormatModule { }
