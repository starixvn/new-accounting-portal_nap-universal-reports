import { DecimalPipe } from '@angular/common';
import { Directive, ElementRef, Input, OnChanges, SimpleChanges, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appDecimalFormat]',
  providers: [DecimalPipe]
})
export class DecimalFormatDirective implements OnChanges {
  @Input('appDecimalFormat') value!: number;

  constructor(private readonly element: ElementRef,
    private readonly decimalPipe: DecimalPipe,
    private render: Renderer2
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    let data = this.decimalPipe.transform(this.value, '1.2-2');
    this.render.setProperty(this.element.nativeElement, 'innerHTML', data);
    if (this.value < 0) {
      this.element.nativeElement.style.color = 'red';
    }
  }
}
