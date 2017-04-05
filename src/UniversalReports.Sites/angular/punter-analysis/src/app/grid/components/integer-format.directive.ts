import { Directive, ElementRef, Input, Renderer, OnInit, HostBinding } from '@angular/core';

@Directive({
  selector: '[napIntegerFormat]'
})
export class IntegerFormatDirective implements OnInit {
  private static integerFormat = new Intl.NumberFormat('en-US', {
    style: 'decimal',
    minimumFractionDigits: 0,
    maximumFractionDigits: 0
  });
  @Input('napIntegerFormat') value: number;
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
    const innerHTML = IntegerFormatDirective.integerFormat.format(this.value);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }
}
