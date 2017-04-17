import { Directive, ElementRef, Input, Renderer, OnInit } from '@angular/core';

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
    const innerHTML = IntegerFormatDirective.integerFormat.format(this.value);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }
}
