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
  @HostBinding('class') elementClass = 'number';
  @Input('napDecimalFormat') value: number;

  constructor(
    private el: ElementRef,
    private renderer: Renderer
  ) { }

  ngOnInit() {
    if (this.value < 0) {
      this.renderer.setElementClass(this.el.nativeElement, 'number-negative', true);
    }
    const innerHTML = DecimalFormatDirective.decimalFormat.format(this.value);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }
}
