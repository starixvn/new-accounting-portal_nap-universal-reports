import * as moment from 'moment';
import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { DateByPeriodTextDirective } from './date-by-period-text.deriective';

@Component({
  selector: 'nap-test',
  template: `<span class="daily-text" date-by-period-text [date]="date" [period-type]="0"></span>
  <span class="weekly-text" date-by-period-text [date]="date" [period-type]="1"></span>
  <span class="monthly-text" date-by-period-text [date]="date" [period-type]="2"></span>
  <span class="anually-text" date-by-period-text [date]="date" [period-type]="3"></span>
  <span class="month-range-text" date-by-period-text [date]="date" [period-type]="4"></span>
  <span class="undefined-date-text" date-by-period-text [date]="" [period-type]="4"></span>
  <span class="undefined-period-type-text" date-by-period-text [date]="date" [period-type]=""></span>
  `,
})
class TestComponent {
  date = moment.utc('2015-12-26');
}

describe('DateByPeriodTextDirective', () => {
  let fixture: ComponentFixture<TestComponent>;

  beforeEach(async(() => {
    fixture = TestBed.configureTestingModule({
      declarations: [DateByPeriodTextDirective, TestComponent]
    })
      .createComponent(TestComponent);

    fixture.detectChanges();

  }));

  it('should mark the daily value with format YYYY/MM/DD', () => {
    let dailySpan: DebugElement = fixture.debugElement.query(By.css(".daily-text"));
    expect(dailySpan.nativeElement.innerText).toBe('2015/12/26');
  });

  it('should mark the weekly value with format MM/YYYY - Week week', () => {
    let weeklySpan: DebugElement = fixture.debugElement.query(By.css(".weekly-text"));
    expect(weeklySpan.nativeElement.innerText).toBe('12/2015 - Week 52');
  });

  it('should mark the monthly value with format MM/YYYY', () => {
    let monthlySpan: DebugElement = fixture.debugElement.query(By.css(".monthly-text"))
    expect(monthlySpan.nativeElement.innerText).toBe('12/2015');
  });

  it('should mark the anually value with format MM/YYYY', () => {
    let anuallySpan: DebugElement = fixture.debugElement.query(By.css(".anually-text"));
    expect(anuallySpan.nativeElement.innerText).toBe('12/2015');
  });

  it('should mark the month range value with format MM/YYYY', () => {
    let monthRangeSpan: DebugElement = fixture.debugElement.query(By.css(".month-range-text"));
    expect(monthRangeSpan.nativeElement.innerText).toBe('12/2015');
  });

  it('should mark the undefined date with current date', () => {
    let undefinedDateSpan: DebugElement = fixture.debugElement.query(By.css(".undefined-date-text"));
    expect(undefinedDateSpan.nativeElement.innerText).toBe(moment().format("MM/YYYY"));
  });

  it('should mark the undefined period type with empty text', () => {
    let undefinedPeriodTypeSpan: DebugElement = fixture.debugElement.query(By.css(".undefined-period-type-text"));
    expect(undefinedPeriodTypeSpan.nativeElement.innerText).toBe('');
  });
});
