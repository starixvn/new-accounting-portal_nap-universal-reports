import { Directive, ElementRef, Input, Renderer } from '@angular/core';
@Directive({
  selector: '[margin-text]'
})

export class MarginTextDirective {

  constructor(private el: ElementRef, private renderer: Renderer) {
  }

  @Input() turnover: number;

  @Input('win-loss') winLoss: number;

  ngOnInit() {
    let className: string = this.winLoss < 0 ? "negative" : "positive";
    let innerHTML: string = this.isTurnoverZero() ? "N/A" : this.getMarginText();
    this.renderer.setElementClass(this.el.nativeElement, className, true || false);
    this.renderer.setElementProperty(this.el.nativeElement, 'innerHTML', innerHTML);
  }

  private getMarginText(): string {
    let decimalFormater = new Intl.NumberFormat('en-US', {
      style: 'decimal',
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    });

    let margin: number = this.winLoss * 100 / this.turnover;

    return decimalFormater.format(margin) + "%";
  }

  private isTurnoverZero(): boolean {
    return this.turnover === null || this.turnover === undefined || this.turnover === 0;
  }
}