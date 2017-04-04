import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { PercentFormatDirective } from './percent-format.directive';

@Component({
  selector: 'nap-test',
  template: `
  <span class="positive-win-loss-text" margin-text [win-loss]="positiveValue" [turnover]="100"></span>
  <span class="negative-win-loss-text" margin-text [win-loss]="negativeValue" [turnover]="100"></span>
  <span class="zero-win-loss-text" margin-text [win-loss]="0" [turnover]="100"></span>
  <span class="zero-turnover-text" margin-text [win-loss]="12.321" [turnover]="0"></span>
  <span class="undefined-win-loss-text" margin-text [win-loss]="" [turnover]="100"></span>  
  <span class="undefined-turnover-text" margin-text [win-loss]="" [turnover]=""></span>  
  `,
})
class TestComponent {
  positiveValue = 15.323;
  negativeValue = -15.323;
}

describe('MarginTextDirective', () => {
  let fixture: ComponentFixture<TestComponent>;

  beforeEach(async(() => {
    fixture = TestBed.configureTestingModule({
      declarations: [
        PercentFormatDirective,
        TestComponent]
    }).createComponent(TestComponent);

    fixture.detectChanges();
  }));

  it('should mark the negative win loss with class negative', () => {
    const negativeWinLossSpan: DebugElement = fixture.debugElement.query(By.css('.negative-win-loss-text'));
    expect(negativeWinLossSpan.nativeElement.className).toContain('negative');
  });

  it('should mark the positive win loss with class positive', () => {
    const positiveWinLossSpan: DebugElement = fixture.debugElement.query(By.css('.positive-win-loss-text'));
    expect(positiveWinLossSpan.nativeElement.className).toContain('positive');
  });

  it('should mark the zero win loss with class positive', () => {
    const zeroWinLossSpan: DebugElement = fixture.debugElement.query(By.css('.zero-win-loss-text'));
    expect(zeroWinLossSpan.nativeElement.className).toContain('positive');
  });

  it('should mark the undefined win loss with class positive', () => {
    const undefinedWinLossSpan: DebugElement = fixture.debugElement.query(By.css('.undefined-win-loss-text'));
    expect(undefinedWinLossSpan.nativeElement.className).toContain('positive');
  });

  it('should mark the zero turnover as N/A', () => {
    const zeroTurnoverSpan: DebugElement = fixture.debugElement.query(By.css('.zero-turnover-text'));
    expect(zeroTurnoverSpan.nativeElement.innerText).toBe('N/A');
  });

  it('should mark the undefined turnover as N/A', () => {
    const undefinedTurnoverSpan: DebugElement = fixture.debugElement.query(By.css('.undefined-turnover-text'));
    expect(undefinedTurnoverSpan.nativeElement.innerText).toBe('N/A');
  });

  it('should format negative margin with 2 decimal digits and percentage sign', () => {
    const negativeWinLossSpan: DebugElement = fixture.debugElement.query(By.css('.negative-win-loss-text'));
    expect(negativeWinLossSpan.nativeElement.innerText).toBe('-15.32%');
  });

  it('should format positive margin with 2 decimal digits and percentage sign', () => {
    const positiveWinLossSpan: DebugElement = fixture.debugElement.query(By.css('.positive-win-loss-text'));
    expect(positiveWinLossSpan.nativeElement.innerText).toBe('15.32%');
  });
});
