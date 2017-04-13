import { Directive, ElementRef, Input, Renderer, OnInit } from '@angular/core';

@Directive({
  selector: '[napDecimalFormat]'
})
export class DecimalFormatDirective implements OnInit {
  private static decimalFormat = new Intl.NumberFormat('en-US', {
    style: 'decimal',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2
  });
  @Input('napDecimalFormat') value: number;

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
    const innerHTML = DecimalFormatDirective.decimalFormat.format(this.value);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }
}
