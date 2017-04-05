import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { IntegerFormatDirective } from './integer-format.directive';

@Component({
  selector: 'nap-test',
  template: `
  <div [napIntegerFormat]=""></div>
  <div [napIntegerFormat]="0"></div>
  <div [napIntegerFormat]="153256.321962"></div>
  <div [napIntegerFormat]="-153256.321962"></div>
  `
})
class TestComponent { }

describe('IntegerFormatDirective', () => {
  let fixture: ComponentFixture<TestComponent>;
  let des: DebugElement[];

  beforeEach(async(() => {
    fixture = TestBed.configureTestingModule({
      declarations: [
        IntegerFormatDirective,
        TestComponent
      ]
    }).createComponent(TestComponent);

    fixture.detectChanges();
    des = fixture.debugElement.queryAll(By.directive(IntegerFormatDirective));
  }));

  function expectElement(index: number, elementClasses: string[], text: string) {
    elementClasses.forEach(elementClass => {
      expect(des[index].nativeElement).toHaveCssClass(elementClass);
    });
    expect(des[index].nativeElement).toHaveText(text);
  }

  it('should mark first element has class "number" and text "NaN"', () => {
    expectElement(0, ['number'], 'NaN');
  });

  it('should mark second element has class "number" and text "0"', () => {
    expectElement(1, ['number'], '0');
  });

  it('should mark third element has class "number" and text "153,256"', () => {
    expectElement(2, ['number'], '153,256');
  });

  it('should mark forth element has class "number, number-negative" and text "-153,256"', () => {
    expectElement(3, ['number', 'number-negative'], '-153,256');
  });
});
