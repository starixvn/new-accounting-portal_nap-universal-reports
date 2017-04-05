import { Directive, ElementRef, Input, Renderer, OnInit, HostBinding } from '@angular/core';
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
  @HostBinding('class') get elementClass(): string {
    if (this.value < 0) {
      return 'number number-negative';
    } else {
      return 'number';
    }
  }

  constructor(
    private el: ElementRef,
    private renderer: Renderer
  ) { }

  ngOnInit() {
    let innerHTML = '';
    if (this.isValidNumber()) {
      innerHTML = PercentFormatDirective.percentFormat.format(this.value);
    } else {
      innerHTML = 'N/A';
    }
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }

  private isValidNumber(): boolean {
    return !_.isNaN(this.value) && _.isFinite(this.value) && _.isNumber(this.value);
  }
}
