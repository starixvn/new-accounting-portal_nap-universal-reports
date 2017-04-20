import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async, fakeAsync, tick } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import * as _ from 'lodash';
import { PaginationInstance } from 'ng2-pagination';
import { expect } from 'nap-components/src/testing';
import { GridService } from '../grid.service';
import { GridType } from '../grid.model';
import { PeriodType } from '../../filter/filter.model';
import { AssociatedAccountGridService } from './associated-account-grid.service';
import { AssociatedAccountGridModel } from './associated-account-grid.model';
import { AssociatedAccountGridComponent } from './associated-account-grid.component';
import { UserRoleItem } from './associated-account-grid.model';
import { AppModule } from '../../app.module';

class Page {
    constructor(
        private fixture: ComponentFixture<AssociatedAccountGridComponent>
    ) { }

    queryEntityRow(rowIndex: number): DebugElement {
        const tableDebugElements = this.fixture.debugElement.queryAll(By.css('table'));
        return tableDebugElements[1].query(By.css('tr'));
    }
}

describe('AssociatedAccountGridComponent', () => {
    let fixture: ComponentFixture<AssociatedAccountGridComponent>;
    let component: AssociatedAccountGridComponent;
    let page: Page;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                AppModule
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(AssociatedAccountGridComponent);
        component = fixture.componentInstance;
        page = new Page(fixture);
    });

    it('should have no table if no binding data', () => {
        fixture.detectChanges();
        const tableDebugElements = fixture.debugElement.queryAll(By.css('table'));
        expect(tableDebugElements.length).toBe(0);
    });

    it('should have one table to show message "There is no data"', () => {
        component.data = [];
        fixture.detectChanges();
        const tableDebugElements = fixture.debugElement.queryAll(By.css('table'));
        expect(tableDebugElements.length).toBe(1);
        const rowDebugElements = tableDebugElements[0].queryAll(By.css('tr'));
        const firstTdCell = rowDebugElements[1].query(By.css('th'));
        expect(firstTdCell.nativeElement).toHaveText('There is no data');
    });

    it('should mark hasData as false if entities is empty', () => {
        expect(component.hasData).toBe(false);
    });

    describe('mock', () => {
        let gridService: GridService;
        let selectedGridType: GridType;
        let service: AssociatedAccountGridService;

        beforeEach(() => {
            gridService = fixture.debugElement.injector.get(GridService);
            gridService.filterModel = {
                fromDate: { year: 2016, month: 1, day: 1 },
                toDate: { year: 2016, month: 1, day: 10 },
                periodType: undefined,
                searchBy: undefined,
                topRow: undefined,
                orderBy: undefined,
                sortBy: undefined,
                depth: undefined,
                userName: undefined,
                selectedBetTypeTreeviewItems: undefined,
                searchByOptions: undefined,
                depthOptions: undefined,
                orderByOptions: undefined,
                sortByOptions: undefined
            };

            gridService.generate = (gridType) => selectedGridType = gridType;
            const fakeAssociatedAccountGridModel: AssociatedAccountGridModel = {
                custId: 1,
                custName: 'Customer 1'
            };

            const fakeData: UserRoleItem[] = [
                { Username: 'User 1', RoleName: 'master' },
                { Username: 'User 2', RoleName: 'member' }
            ];

            service = fixture.debugElement.injector.get(AssociatedAccountGridService);
            service.model = fakeAssociatedAccountGridModel;
            spyOn(service, 'query').and.returnValue(Observable.of(fakeData));

            component.query();
            fixture.detectChanges();
        });

        it('should mark hasData as true if entities is not empty', () => {
            expect(component.hasData).toBe(true);
        });

        it('should have title "Associated accounts of Punter Customer 1', () => {
            expect(component.title).toBe('Associated accounts of Punter Customer 1');
        });

        it('should invoke exportExcel in service when call exportExcel', () => {
            const spy = spyOn(service, 'exportExcel').and.callFake(() => { });
            component.exportExcel();
            expect(spy.calls.count()).toBe(1);
        });

        it('should have 2 tables', () => {
            const tables = fixture.debugElement.queryAll(By.css('table'));
            expect(tables.length).toBe(2);
        });
    });
});
