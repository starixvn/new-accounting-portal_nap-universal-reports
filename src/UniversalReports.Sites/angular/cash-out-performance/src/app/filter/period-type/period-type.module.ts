import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PeriodTypeComponent } from './period-type.component';
import { FormsModule } from '@angular/forms';
import { DateModule } from 'nap-components/date';

@NgModule({
  declarations: [
    PeriodTypeComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    DateModule
  ],
  exports: [
    PeriodTypeComponent
  ]
})
export class PeriodTypeModule { }
