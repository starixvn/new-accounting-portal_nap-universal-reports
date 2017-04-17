///<reference path="../../testing/jasmine-matchers.d.ts" />
import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async, fakeAsync, tick } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { eventHelper } from '../../testing';
import { NgbDateStruct } from '../date-model';
import { DatePickerToggleDirective } from '../date-picker-toggle/date-picker-toggle.directive';
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
    inputDebugEl: DebugElement;

    constructor(fixture: ComponentFixture<TestComponent>) {
        this.inputDebugEl = fixture.debugElement.query(By.css('input'));
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
                DatePickerToggleDirective,
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
        expect(page.inputDebugEl.nativeElement.value).toBe('November 2, 2016');
    }));

    it('should emit event dateChange when change input value', fakeAsync(() => {
        fixture.detectChanges();
        tick();
        fixture.detectChanges();
        const spy = spyOn(component, 'onDateChange').and.callThrough();
        page.inputDebugEl.triggerEventHandler('change', { target: { value: 'November 3, 2016' } });
        fixture.detectChanges();
        tick();
        fixture.detectChanges();
        expect(spy.calls.count()).toBe(1);
    }));
});
