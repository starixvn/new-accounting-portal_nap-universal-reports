import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { NumberFormatModule } from 'nap-components/src/number/number-format.module';
import { PerformanceComponent } from './performance.component';
import { PerformanceService } from './performance.service';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ChartsModule,
        NumberFormatModule
    ],
    declarations: [
        PerformanceComponent
    ],
    exports: [
        PerformanceComponent
    ],
    providers: [
        PerformanceService
    ]
})
export class PerformanceModule { }
