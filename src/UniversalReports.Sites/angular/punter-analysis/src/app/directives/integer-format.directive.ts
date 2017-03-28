import { Directive, ElementRef, Input, Renderer, OnInit } from '@angular/core';

@Directive({
  selector: '[napIntegerFormat]',
  host: {
    'class': 'number'
  }
})
export class IntegerFormatDirective implements OnInit {
  @Input('napIntegerFormat') value: number;
  private static integerFormat = new Intl.NumberFormat('en-US', {
    style: 'decimal',
    minimumFractionDigits: 0,
    maximumFractionDigits: 0
  });

  constructor(private el: ElementRef, private renderer: Renderer) { }

  ngOnInit() {
    if (this.value < 0) {
      this.renderer.setElementClass(this.el.nativeElement, 'number-negative', true);
    }
    const innerHTML = IntegerFormatDirective.integerFormat.format(this.value);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }
}
