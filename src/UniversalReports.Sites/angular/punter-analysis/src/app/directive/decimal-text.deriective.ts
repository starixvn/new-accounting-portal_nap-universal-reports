import { Directive, ElementRef, Input, Renderer } from '@angular/core';
@Directive({
  selector: '[decimal-text]'
})

export class DecimalTextDirective {

  constructor(private el: ElementRef, private renderer: Renderer) {
  }

  @Input() decimal: number;

  ngOnInit() {
    let className: string = this.decimal < 0 ? "negative" : "positive";
    let innerHTML: string = this.getDecimalText();
    this.renderer.setElementClass(this.el.nativeElement, className, true || false);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }

  private getDecimalText(): string {
    let decimalFormater = new Intl.NumberFormat('en-US', {
      style: 'decimal',
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    });
    return decimalFormater.format(this.decimal);
  }
}