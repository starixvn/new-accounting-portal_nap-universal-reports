import { Directive, ElementRef, Input, Renderer } from '@angular/core';
@Directive({
  selector: '[integer-text]'
})

export class IntegerTextDirective {

  constructor(private el: ElementRef, private renderer: Renderer) {
  }

  @Input() integer: number;

  ngOnInit() {
    let className: string = this.integer < 0 ? "negative" : "positive";
    let innerHTML: string = this.getIntegerText();
    this.renderer.setElementClass(this.el.nativeElement, className, true || false);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }

  private getIntegerText(): string {
    let integerFormater = new Intl.NumberFormat('en-US', {
      style: 'decimal',
      minimumFractionDigits: 0,
      maximumFractionDigits: 0
    });
    return integerFormater.format(this.integer);
  }
}