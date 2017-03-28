import { Directive, ElementRef, Input, Renderer, OnInit } from '@angular/core';

@Directive({
  selector: '[napDecimalFormat]',
  host: {
    'class': 'number'
  }
})
export class DecimalFormatDirective implements OnInit {
  @Input('napDecimalFormat') value: number;
  private static decimalFormat = new Intl.NumberFormat('en-US', {
    style: 'decimal',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2
  });

  constructor(private el: ElementRef, private renderer: Renderer) { }

  ngOnInit() {
    if (this.value < 0) {
      this.renderer.setElementClass(this.el.nativeElement, 'number-negative', true);
    }
    const innerHTML = DecimalFormatDirective.decimalFormat.format(this.value);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }
}
