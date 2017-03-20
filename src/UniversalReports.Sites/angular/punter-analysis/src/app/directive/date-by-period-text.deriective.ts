import { Directive, ElementRef, Input, Renderer } from '@angular/core';
import * as moment from 'moment';
import { PeriodType } from '../filter/filter.model'

@Directive({
  selector: '[date-by-period-text]'
})

export class DateByPeriodTextDirective {

  constructor(private el: ElementRef, private renderer: Renderer) {
  }

  @Input() date: Date;

  @Input('period-type') periodType: number;

  ngOnInit() {
    let innerHTML: string = this.getDateText();
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }

  private getDateText(): string {

    switch (this.periodType) {
      case PeriodType.Annually:
      case PeriodType.MonthRange:
      case PeriodType.Monthly:
        return moment(this.date).format("MM/YYYY");
      case PeriodType.Daily:
        return moment(this.date).format("YYYY/MM/DD");
      case PeriodType.Weekly:
        return moment(this.date).format("MM/YYYY") + " - Week " + moment(this.date).format("W");
      default:
        return "";
    }
  }
}