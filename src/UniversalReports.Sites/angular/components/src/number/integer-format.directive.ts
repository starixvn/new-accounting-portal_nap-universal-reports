import { Directive, ElementRef, Input, Renderer, OnInit } from '@angular/core';
import { NumberHelper } from './number-helper';
import { NumberFormat } from './number-format';

@Directive({
  selector: '[napIntegerFormat]'
})
export class IntegerFormatDirective implements OnInit {
  @Input('napIntegerFormat') value: number;

  constructor(
    private el: ElementRef,
    private renderer: Renderer
  ) { }

  ngOnInit() {
    let className = '';
    if (this.value < 0) {
      className = 'number-negative';
    } else if (this.value > 0) {
      className = 'number-positive';
    }
    if (className !== '') {
      this.renderer.setElementClass(this.el.nativeElement, className, true);
    }
    const innerHTML = NumberHelper.format(this.value, NumberFormat.Integer);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }
}
