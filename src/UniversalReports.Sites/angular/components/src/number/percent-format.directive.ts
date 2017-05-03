import { Directive, ElementRef, Input, Renderer, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { NumberHelper } from './number-helper';
import { NumberFormat } from './number-format';

@Directive({
  selector: '[napPercentFormat]'
})
export class PercentFormatDirective implements OnInit {
  @Input('napPercentFormat') value: number;

  constructor(
    private el: ElementRef,
    private renderer: Renderer
  ) { }

  ngOnInit() {
    let innerHTML = '';
    if (this.isValidNumber()) {
      innerHTML = NumberHelper.format(this.value, NumberFormat.Percent);
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
