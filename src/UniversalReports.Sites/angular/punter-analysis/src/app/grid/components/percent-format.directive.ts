import { Directive, ElementRef, Input, Renderer, OnInit } from '@angular/core';
import * as _ from 'lodash';

@Directive({
  selector: '[napPercentFormat]'
})
export class PercentFormatDirective implements OnInit {
  private static percentFormat = new Intl.NumberFormat('en-US', {
    style: 'percent',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2
  });
  @Input('napPercentFormat') value: number;

  constructor(
    private el: ElementRef,
    private renderer: Renderer
  ) { }

  ngOnInit() {
    let innerHTML = '';
    if (this.isValidNumber()) {
      innerHTML = PercentFormatDirective.percentFormat.format(this.value);
      let className = '';
      if (this.value < 0) {
        className = 'number-negative';
      } else if (this.value > 0) {
        className = 'number-positive';
      }
      if (className !== '') {
        this.renderer.setElementClass(this.el.nativeElement, className, true);
      }
    } else {
      innerHTML = 'N/A';
    }
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }

  private isValidNumber(): boolean {
    return !_.isNaN(this.value) && _.isFinite(this.value) && _.isNumber(this.value);
  }
}
