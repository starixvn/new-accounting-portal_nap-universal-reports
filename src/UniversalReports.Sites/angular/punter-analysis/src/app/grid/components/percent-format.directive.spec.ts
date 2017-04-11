import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { PercentFormatDirective } from './percent-format.directive';

@Component({
  selector: 'nap-test',
  template: `
  <div [napPercentFormat]=""></div>
  <div [napPercentFormat]="0"></div>
  <div [napPercentFormat]="0/0"></div>
  <div [napPercentFormat]="1/0"></div>
  <div [napPercentFormat]="-1/0"></div>
  <div [napPercentFormat]="0.15323"></div>
  <div [napPercentFormat]="-0.15323"></div>
  `,
})
class TestComponent { }

describe('PercentFormatDirective', () => {
  let fixture: ComponentFixture<TestComponent>;
  let des: DebugElement[];

  beforeEach(() => {
    fixture = TestBed.configureTestingModule({
      declarations: [
        PercentFormatDirective,
        TestComponent
      ]
    }).createComponent(TestComponent);

    fixture.detectChanges();
    des = fixture.debugElement.queryAll(By.directive(PercentFormatDirective));
  });

  function expectElement(index: number, elementClasses: string[], text: string) {
    elementClasses.forEach(elementClass => {
      expect(des[index].nativeElement).toHaveCssClass(elementClass);
    });
    expect(des[index].nativeElement).toHaveText(text);
  }

  it('should mark empty value as text "N/A" and class "number"', () => {
    expectElement(0, ['number'], 'N/A');
  });

  it('should mark value 0 as text "0.00%" and class "number"', () => {
    expectElement(1, ['number'], '0.00%');
  });

  it('should mark value 0/0 as text "N/A" and class "number"', () => {
    expectElement(2, ['number'], 'N/A');
  });

  it('should mark value 1/0 as text "N/A" and class "number"', () => {
    expectElement(3, ['number'], 'N/A');
  });

  it('should mark value -1/0 as text "N/A" and class "number"', () => {
    expectElement(4, ['number'], 'N/A');
  });

  it('should mark value 0.15323 as text "15.32%" and class "number"', () => {
    expectElement(5, ['number'], '15.32%');
  });

  it('should mark value -0.15323 as text "-15.32%" and class "number, number-negative"', () => {
    expectElement(6, ['number', 'number-negative'], '-15.32%');
  });
});
