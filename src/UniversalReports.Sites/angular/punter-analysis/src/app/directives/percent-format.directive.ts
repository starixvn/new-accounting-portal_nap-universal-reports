import { Directive, ElementRef, Input, Renderer, OnInit } from '@angular/core';
import * as _ from 'lodash';

@Directive({
  selector: '[napPercentFormat]',
  host: {
    'class': 'number'
  }
})
export class PercentFormatDirective implements OnInit {
  @Input('napPercentFormat') value: number;
  private static percentFormat = new Intl.NumberFormat('en-US', {
    style: 'percent',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2
  });

  constructor(private el: ElementRef, private renderer: Renderer) { }

  ngOnInit() {
    let innerHTML = '';
    if (this.isValid()) {
      innerHTML = PercentFormatDirective.percentFormat.format(this.value);
      if (this.value < 0) {
        this.renderer.setElementClass(this.el.nativeElement, 'number-negative', true);
      }
    } else {
      innerHTML = 'N/A';
    }
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }

  private isValid(): boolean {
    return _.isNumber(this.value) && this.value !== Infinity;
  }
}
