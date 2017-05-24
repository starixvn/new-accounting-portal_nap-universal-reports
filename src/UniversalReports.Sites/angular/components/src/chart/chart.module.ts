import { NgModule } from '@angular/core';
import { ChartDirective } from './chart.directive';

@NgModule({
    declarations: [
        ChartDirective
    ],
    exports: [
        ChartDirective
    ]
})
export class ChartsModule { }
