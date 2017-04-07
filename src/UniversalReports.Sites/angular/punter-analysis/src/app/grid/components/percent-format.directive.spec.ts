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

  it('should mark first element has class "number" and text "N/A"', () => {
    expectElement(0, ['number'], 'N/A');
  });

  it('should mark second element has class "number" and text "0.00%"', () => {
    expectElement(1, ['number'], '0.00%');
  });

  it('should mark third element has class "number" and text "N/A"', () => {
    expectElement(2, ['number'], 'N/A');
  });

  it('should mark forth element has class "number" and text "N/A"', () => {
    expectElement(3, ['number'], 'N/A');
  });

  it('should mark fifth element has class "number" and text "N/A"', () => {
    expectElement(4, ['number'], 'N/A');
  });

  it('should mark sixth element has class "number" and text "15.32%"', () => {
    expectElement(5, ['number'], '15.32%');
  });

  it('should mark seventh element has class "number, number-negative" and text "-15.32%"', () => {
    expectElement(6, ['number', 'number-negative'], '-15.32%');
  });
});
