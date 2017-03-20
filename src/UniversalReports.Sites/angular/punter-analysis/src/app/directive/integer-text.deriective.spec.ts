
import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { IntegerTextDirective } from './integer-text.deriective';

@Component({
  selector: 'nap-test',
  template: `<span class="positive-integer-text" integer-text [integer]="positiveValue"></span>
  <span class="negative-integer-text" integer-text [integer]="negativeValue"></span>
  <span class="zero-integer-text" integer-text [integer]="0"></span>
  <span class="undefined-integer-text" integer-text [integer]=""></span>  
  `,
})
class TestComponent {
  private positiveValue: number = 153256.321962;
  private negativeValue: number = -153256.321962;
}

describe('IntegerTextDirective', () => {
  let fixture: ComponentFixture<TestComponent>;

  beforeEach(async(() => {
    fixture = TestBed.configureTestingModule({
      declarations: [IntegerTextDirective, TestComponent]
    })
      .createComponent(TestComponent);

    fixture.detectChanges();
  }));

  it('should mark the negative value with class negative', () => {
    let negativeSpan: DebugElement = fixture.debugElement.query(By.css(".negative-integer-text"));
    expect(negativeSpan.nativeElement.className).toContain('negative');
  });

  it('should mark the positive  value with class positive', () => {
    let positiveSpan: DebugElement = fixture.debugElement.query(By.css(".positive-integer-text"));
    expect(positiveSpan.nativeElement.className).toContain('positive');
  });

  it('should mark the zero  value with class positive', () => {
    let zeroSpan: DebugElement = fixture.debugElement.query(By.css(".zero-integer-text"));
    expect(zeroSpan.nativeElement.className).toContain('positive');
  });

  it('should mark the undefined  value with class positive', () => {
    let undefinedSpan: DebugElement = fixture.debugElement.query(By.css(".undefined-integer-text"));
    expect(undefinedSpan.nativeElement.className).toContain('positive');
  });

  it('should format negative value  with thousand seperator and no decimal digits', () => {
    let negativeSpan: DebugElement = fixture.debugElement.query(By.css(".negative-integer-text"));
    expect(negativeSpan.nativeElement.innerText).toBe('-153,256');
  });

  it('should format positive value  with thousand seperator and no decimal digits', () => {
    let positiveSpan: DebugElement = fixture.debugElement.query(By.css(".positive-integer-text"));
    expect(positiveSpan.nativeElement.innerText).toBe('153,256');
  });
});
