///<reference path="../../testing/jasmine-matchers.d.ts" />
import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async, fakeAsync, tick } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { eventHelper } from '../../testing';
import { NgbDateStruct } from '../date-model.date-struct';
import { YearPickerComponent } from './year-picker.component';

@Component({
    template: `
        <nap-year-picker [(date)]="date" [minDate]="minDate" [maxDate]="maxDate" (dateChange)="onDateChange($event)"></nap-year-picker>
    `
})
class TestComponent {
    selectedDate: NgbDateStruct;
    date: NgbDateStruct = { year: 2016, month: 11, day: 2 };
    minDate: NgbDateStruct = { year: 2016, month: 2, day: 2 };
    maxDate: NgbDateStruct = { year: 2017, month: 3, day: 31 };
    onDateChange(date: NgbDateStruct) {
        this.selectedDate = date;
    }
}

class Page {
    yearDebugEl: DebugElement;

    constructor(fixture: ComponentFixture<TestComponent>) {
        this.yearDebugEl = fixture.debugElement.query(By.css('select'));
    }
}

describe('MonthPickerComponent', () => {
    let fixture: ComponentFixture<TestComponent>;
    let component: TestComponent;
    let page: Page;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                FormsModule
            ],
            declarations: [
                YearPickerComponent,
                TestComponent
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(TestComponent);
        component = fixture.componentInstance;
        page = new Page(fixture);
    });

    it('should display and year "2016"', fakeAsync(() => {
        fixture.detectChanges();
        tick();
        fixture.detectChanges();
        expect(page.yearDebugEl.nativeElement.value).toBe('2016');
    }));

    it('should change year of selectedDate when change year dropdown', fakeAsync(() => {
        fixture.detectChanges();
        tick();
        fixture.detectChanges();
        page.yearDebugEl.triggerEventHandler('change', { target: { value: '2017' } });
        fixture.detectChanges();
        const date = component.selectedDate;
        const expectedDate: NgbDateStruct = { year: 2017, month: 1, day: 1 };
        expect(date).toEqual(expectedDate);
    }));
});
