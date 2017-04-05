import { Directive, ElementRef, Input, Renderer, OnInit, HostBinding } from '@angular/core';

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
    const innerHTML = DecimalFormatDirective.decimalFormat.format(this.value);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }
}
