import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { IntegerFormatDirective } from './integer-format.directive';

@Component({
  selector: 'nap-test',
  template: `
  <span class="positive-integer-text" [napIntegerFormat]="positiveValue"></span>
  <span class="negative-integer-text" [napIntegerFormat]="negativeValue"></span>
  <span class="zero-integer-text" [napIntegerFormat]="0"></span>
  <span class="undefined-integer-text" [napIntegerFormat]=""></span>
  `
})
class TestComponent {
  positiveValue = 153256.321962;
  negativeValue = -153256.321962;
}

describe('IntegerTextDirective', () => {
  let fixture: ComponentFixture<TestComponent>;

  beforeEach(async(() => {
    fixture = TestBed.configureTestingModule({
      declarations: [
        IntegerFormatDirective,
        TestComponent]
    }).createComponent(TestComponent);

    fixture.detectChanges();
  }));

  it('should mark the negative value with class negative', () => {
    const negativeSpan: DebugElement = fixture.debugElement.query(By.css('.negative-integer-text'));
    expect(negativeSpan.nativeElement.className).toContain('negative');
  });

  it('should mark the positive  value with class positive', () => {
    const positiveSpan: DebugElement = fixture.debugElement.query(By.css('.positive-integer-text'));
    expect(positiveSpan.nativeElement.className).toContain('positive');
  });

  it('should mark the zero  value with class positive', () => {
    const zeroSpan: DebugElement = fixture.debugElement.query(By.css('.zero-integer-text'));
    expect(zeroSpan.nativeElement.className).toContain('positive');
  });

  it('should mark the undefined  value with class positive', () => {
    const undefinedSpan: DebugElement = fixture.debugElement.query(By.css('.undefined-integer-text'));
    expect(undefinedSpan.nativeElement.className).toContain('positive');
  });

  it('should format negative value  with thousand seperator and no decimal digits', () => {
    const negativeSpan: DebugElement = fixture.debugElement.query(By.css('.negative-integer-text'));
    expect(negativeSpan.nativeElement.innerText).toBe('-153,256');
  });

  it('should format positive value  with thousand seperator and no decimal digits', () => {
    const positiveSpan: DebugElement = fixture.debugElement.query(By.css('.positive-integer-text'));
    expect(positiveSpan.nativeElement.innerText).toBe('153,256');
  });
});
