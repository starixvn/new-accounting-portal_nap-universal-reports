///<reference path="../../../../node_modules/nap-components/src/testing/jasmine-matchers.d.ts" />
import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async, fakeAsync, tick } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { eventHelper } from 'nap-components/src/testing';
import { DropdownTypeaheadComponent } from './dropdown-typeahead.component';
import { TypeaheadQuery } from './dropdown-typeahead.model';

class Page {
    dropdown: HTMLElement;
    input: HTMLInputElement;

    constructor(fixture: ComponentFixture<DropdownTypeaheadComponent>) {
        this.dropdown = fixture.debugElement.query(By.css('.dropdown')).nativeElement;
        this.input = fixture.debugElement.query(By.css('input')).nativeElement;
    }
}

describe('DropdownTypeaheadComponent', () => {
    const query = new TypeaheadQuery(term => {
        return Observable.of(['1', '2']);
    });
    let fixture: ComponentFixture<DropdownTypeaheadComponent>;
    let component: DropdownTypeaheadComponent;
    let page: Page;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [FormsModule],
            declarations: [
                DropdownTypeaheadComponent
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(DropdownTypeaheadComponent);
        component = fixture.componentInstance;
        page = new Page(fixture);
    });

    it('should display placeholder', () => {
        component.placeholder = 'ABC';
        fixture.detectChanges();
        expect(page.input.placeholder).toBe('ABC');
    });

    it('should hide dropdown by default', () => {
        fixture.detectChanges();
        expect(page.dropdown).not.toHaveCssClass('show');
    });

    it('should call query if input value has length >= minLengthHasSuggestion', () => {
        component.minLengthHasSuggestion = 2;
        component.query = query;
        const spy = spyOn(query, 'search').and.callThrough();
        eventHelper.raiseInput(page.input, 'A');
        fixture.detectChanges();
        expect(spy.calls.count()).toBe(0);
        eventHelper.raiseInput(page.input, 'AA');
        fixture.detectChanges();
        expect(spy.calls.count()).toBe(1);
    });

    it('should show dropdown after quering', async(() => {
        component.minLengthHasSuggestion = 2;
        component.query = query;
        fixture.detectChanges();
        eventHelper.raiseInput(page.input, 'AA');
        fixture.detectChanges();
        fixture.whenStable().then(() => {
            fixture.detectChanges();
            expect(page.dropdown).toHaveCssClass('show');
        });
    }));

    describe('hide dropdown after showing', () => {
        beforeEach(() => {
            component.minLengthHasSuggestion = 2;
            component.query = query;
            component.text = 'AA';
            component.items = ['1', '2'];
            fixture.detectChanges();
        });

        it('should show dropdown', () => {
            expect(page.dropdown).toHaveCssClass('show');
        });

        it('should hide dropdown again if input value has length < minLengthHasSuggestion', () => {
            eventHelper.raiseInput(page.input, 'A');
            fixture.detectChanges();
            expect(page.dropdown).not.toHaveCssClass('show');
        });

        it('should hide dropdown if click out component', () => {
            document.body.click();
            fixture.detectChanges();
            expect(page.dropdown).not.toHaveCssClass('show');
        });

        it('should hide dropdown if press Esc', () => {
            eventHelper.raiseKeydown(page.input, 'Escape');
            fixture.detectChanges();
            expect(page.dropdown).not.toHaveCssClass('show');
        });
    });

    describe('items', () => {
        let dropdownItems: DebugElement[];

        beforeEach(() => {
            component.minLengthHasSuggestion = 2;
            component.query = query;
            component.text = 'AA';
            component.items = ['1', '2'];
            fixture.detectChanges();
            dropdownItems = fixture.debugElement.queryAll(By.css('.dropdown-item'));
        });

        it('should have no item with class "active"', () => {
            dropdownItems.forEach(item => {
                expect(item.nativeElement).not.toHaveCssClass('active');
            });
        });

        it('should set input value "1" if click on dropdown item "1" and hide dropdown', fakeAsync(() => {
            const spy = spyOn(component, 'textChange').and.callThrough();
            eventHelper.raiseClick(dropdownItems[0].nativeElement);
            fixture.detectChanges();
            tick();
            fixture.detectChanges();
            expect(page.input.value).toBe('1');
            expect(page.dropdown).not.toHaveCssClass('show');
        }));

        it('should active the first item when press Down', () => {
            eventHelper.raiseKeydown(page.input, 'ArrowDown');
            fixture.detectChanges();
            expect(dropdownItems[0].nativeElement).toHaveCssClass('active');
        });

        it('should active the first item when press Up & being activating the second item', () => {
            component.index = 1;
            fixture.detectChanges();
            eventHelper.raiseKeydown(page.input, 'ArrowUp');
            fixture.detectChanges();
            expect(dropdownItems[0].nativeElement).toHaveCssClass('active');
        });

        it('should set input value "1" if press Enter on the active item', fakeAsync(() => {
            component.index = 0;
            fixture.detectChanges();
            eventHelper.raiseKeydown(page.input, 'Enter');
            fixture.detectChanges();
            tick();
            fixture.detectChanges();
            expect(page.input.value).toBe('1');
        }));

        it('should raise textChange event when item is selected', fakeAsync(() => {
            let selectedItem: string;
            component.index = 0;
            component.textChange.subscribe(text => selectedItem = text);
            fixture.detectChanges();
            eventHelper.raiseKeydown(page.input, 'Enter');
            fixture.detectChanges();
            tick();
            fixture.detectChanges();
            expect(selectedItem).toBe('1');
        }));
    });
});
