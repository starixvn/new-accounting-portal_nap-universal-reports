import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { DecimalFormatDirective } from './decimal-format.directive';

@Component({
  selector: 'nap-test',
  template: `
  <div [napDecimalFormat]=""></div>
  <div [napDecimalFormat]="0"></div>
  <div [napDecimalFormat]="153256.321962"></div>
  <div [napDecimalFormat]="-153256.321962"></div>
  `
})
class TestComponent { }

describe('DecimalFormatDirective', () => {
  let fixture: ComponentFixture<TestComponent>;
  let des: DebugElement[];

  beforeEach(() => {
    fixture = TestBed.configureTestingModule({
      declarations: [
        DecimalFormatDirective,
        TestComponent
      ]
    }).createComponent(TestComponent);

    fixture.detectChanges();
    des = fixture.debugElement.queryAll(By.directive(DecimalFormatDirective));
  });

  function expectElement(index: number, elementClasses: string[], text: string) {
    elementClasses.forEach(elementClass => {
      expect(des[index].nativeElement).toHaveCssClass(elementClass);
    });
    expect(des[index].nativeElement).toHaveText(text);
  }

  it('should mark empty value as text "NaN" and class "number"', () => {
    expectElement(0, ['number'], 'NaN');
  });

  it('should mark value 0 as text "0.00" and class "number"', () => {
    expectElement(1, ['number'], '0.00');
  });

  it('should mark value 153256.321962 as text "153,256.32" and class "number"', () => {
    expectElement(2, ['number'], '153,256.32');
  });

  it('should mark value  -153256.321962 as text "-153,256.32" and class "number, number-negative"', () => {
    expectElement(3, ['number', 'number-negative'], '-153,256.32');
  });
});
