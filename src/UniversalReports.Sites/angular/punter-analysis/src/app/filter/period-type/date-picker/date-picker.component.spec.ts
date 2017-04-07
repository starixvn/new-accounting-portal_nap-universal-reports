///<reference path="../../../../../node_modules/nap-components/src/testing/jasmine-matchers.d.ts" />
import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async, fakeAsync, tick } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbInputDatepicker, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
import { eventHelper } from 'nap-components/src/testing';
import { NgbDateStruct } from 'nap-components/src/date';
import { DatePickerComponent } from './date-picker.component';

@Component({
    template: `
        <nap-date-picker [(date)]="date" (dateChange)="onDateChange()"></nap-date-picker>
    `
})
class TestComponent {
    date: NgbDateStruct = { year: 2016, month: 11, day: 2 };
    onDateChange() { }
}

class Page {
    input: HTMLInputElement;

    constructor(fixture: ComponentFixture<TestComponent>) {
        this.input = fixture.debugElement.query(By.css('input')).nativeElement;
    }
}

describe('DatePickerComponent', () => {
    let fixture: ComponentFixture<TestComponent>;
    let component: TestComponent;
    let page: Page;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                FormsModule,
                NgbDatepickerModule.forRoot()
            ],
            declarations: [
                DatePickerComponent,
                TestComponent
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(TestComponent);
        component = fixture.componentInstance;
        page = new Page(fixture);
    });

    it('should display "November 2, 2016" in input', fakeAsync(() => {
        fixture.detectChanges();
        tick();
        fixture.detectChanges();
        expect(page.input.value).toBe('November 2, 2016');
    }));

    it('should emit event dateChange when change input value', fakeAsync(() => {
        fixture.detectChanges();
        tick();
        fixture.detectChanges();
        const spy = spyOn(component, 'onDateChange').and.callThrough();
        const inputDebugEl = fixture.debugElement.query(By.css('input'));
        inputDebugEl.triggerEventHandler('change', { target: { value: 'November 3, 2016' } });
        fixture.detectChanges();
        tick();
        fixture.detectChanges();
        expect(spy.calls.count()).toBe(1);
    }));
});
