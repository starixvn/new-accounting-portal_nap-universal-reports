import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { DecimalFormatDirective } from './decimal-format.directive';

@Component({
  selector: 'nap-test',
  template: `
  <span class="positive-decimal-text" [napDecimalFormat]="positiveValue"></span>
  <span class="negative-decimal-text" [napDecimalFormat]="negativeValue"></span>
  <span class="zero-decimal-text" [napDecimalFormat]="0"></span>
  <span class="undefined-decimal-text" [napDecimalFormat]=""></span>  
  `,
})
class TestComponent {
  private positiveValue: number = 153256.321962;
  private negativeValue: number = -153256.321962;
}

describe('DecimalTextDirective', () => {
  let fixture: ComponentFixture<TestComponent>;

  beforeEach(async(() => {
    fixture = TestBed.configureTestingModule({
      declarations: [
        DecimalFormatDirective,
        TestComponent]
    }).createComponent(TestComponent);

    fixture.detectChanges();
  }));

  it('should mark the negative value with class negative', () => {
    let negativeSpan: DebugElement = fixture.debugElement.query(By.css(".negative-decimal-text"));
    expect(negativeSpan.nativeElement.className).toContain('negative');
  });

  it('should mark the positive  value with class positive', () => {
    let positiveSpan: DebugElement = fixture.debugElement.query(By.css(".positive-decimal-text"));
    expect(positiveSpan.nativeElement.className).toContain('positive');
  });

  it('should mark the zero  value with class positive', () => {
    let zeroSpan: DebugElement = fixture.debugElement.query(By.css(".undefined-decimal-text"));
    expect(zeroSpan.nativeElement.className).toContain('positive');
  });

  it('should mark the undefined  value with class positive', () => {
    let undefinedSpan: DebugElement = fixture.debugElement.query(By.css(".undefined-decimal-text"));
    expect(undefinedSpan.nativeElement.className).toContain('positive');
  });

  it('should format negative value with thousand seperator and 2 decimal digits', () => {
    let negativeSpan: DebugElement = fixture.debugElement.query(By.css(".negative-decimal-text"));
    expect(negativeSpan.nativeElement.innerText).toBe('-153,256.32');
  });

  it('should format positive value with thousand seperator and 2 decimal digits', () => {
    let positiveSpan: DebugElement = fixture.debugElement.query(By.css(".positive-decimal-text"));
    expect(positiveSpan.nativeElement.innerText).toBe('153,256.32');
  });
});
