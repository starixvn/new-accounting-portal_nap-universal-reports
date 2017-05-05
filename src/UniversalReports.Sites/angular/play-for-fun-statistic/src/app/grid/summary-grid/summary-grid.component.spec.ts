import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async, fakeAsync, tick } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import * as _ from 'lodash';
import { expect } from 'nap-components/src/testing';
import { fakeFilterModel } from '../../filter/filter.model.spec';
import { GridService } from '../grid.service';
import { GridType } from '../grid.model';
import { SummaryGridService } from './summary-grid.service';
import { SummaryGridComponent } from './summary-grid.component';
import { fakeData } from './summary-grid.model.spec';
import { AppModule } from '../../app.module';
import { DetailGridService } from '../detail-grid/detail-grid.service';
import { DetailGridModel } from '../detail-grid/detail-grid.model';

class Page {
    constructor(
        private fixture: ComponentFixture<SummaryGridComponent>
    ) { }

    queryEntityRow(rowIndex: number): DebugElement {
        const tableDebugElements = this.fixture.debugElement.queryAll(By.css('table'));
        const trs = tableDebugElements[1].queryAll(By.css('tr'));
        return trs[rowIndex];
    }

    queryTotalRow(): DebugElement {
        const tableDebugElements = this.fixture.debugElement.queryAll(By.css('table'));
        return tableDebugElements[2].query(By.css('tr'));
    }
}

describe('SummaryGridComponent', () => {
    let fixture: ComponentFixture<SummaryGridComponent>;
    let component: SummaryGridComponent;
    let page: Page;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                AppModule
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(SummaryGridComponent);
        component = fixture.componentInstance;
        page = new Page(fixture);
    });

    it('should have no table if no binding data', () => {
        fixture.detectChanges();
        const tableDebugElements = fixture.debugElement.queryAll(By.css('table'));
        expect(tableDebugElements.length).toBe(0);
    });

    it('should have one table to show message "There is no data"', () => {
        component.data = {
            Entities: [],
            Total: null
        };
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

    it('should mark hasExcel as false if entities is empty', () => {
        expect(component.hasData).toBe(false);
    });

    describe('mock', () => {
        let gridService: GridService;
        let selectedGridType: GridType;
        let service: SummaryGridService;

        beforeEach(() => {
            gridService = fixture.debugElement.injector.get(GridService);
            gridService.filterModel = fakeFilterModel;
            gridService.generate = (gridType) => selectedGridType = gridType;
            service = fixture.debugElement.injector.get(SummaryGridService);

            spyOn(service, 'query').and.returnValue(Observable.of(fakeData));
            component.query();
            fixture.detectChanges();
        });

        it('should mark hasData as true if entities is not empty', () => {
            expect(component.hasData).toBe(true);
        });

        it('should mark hasExcel as true if entities is not empty', () => {
            expect(component.hasData).toBe(true);
        });

        it('should have title "Play For Fun Statistics From Apr 01, 2017 To Apr 19, 2017" if it is the last grid', () => {
            gridService.activeGrid = component;
            expect(component.title).toBe('Play For Fun Statistics From Apr 01, 2017 To Apr 19, 2017');
        });

        it('should invoke exportExcel in service when call exportExcel', () => {
            const spy = spyOn(service, 'exportExcel').and.callFake(() => { });
            component.exportExcel();
            expect(spy.calls.count()).toBe(1);
        });

        it('should invoke to generate Detail when click on the first cell', () => {
            const row = page.queryEntityRow(0);
            const tds = row.queryAll(By.css('td'));
            const link = tds[0].query(By.css('a'));
            link.triggerEventHandler('click', {});
            expect(selectedGridType).toBe(GridType.Detail);
            const detailGridService = fixture.debugElement.injector.get(DetailGridService);
            const expectedModel: DetailGridModel = {
                Date: { year: 2017, month: 4, day: 1 }
            };
            expect(detailGridService.model).toEqual(expectedModel);
        });

        it('all cells of first row should match', () => {
            const cellValues = [];
            const expectedCellValue = ['Apr 01, 2017', '1', '300.00', '0.00', '3'];
            const row = page.queryEntityRow(0);
            const tds = row.queryAll(By.css('td'));
            for (const td of tds) {
                cellValues.push(td.nativeElement.innerText);
            }

            expect(cellValues).toEqual(expectedCellValue);
        });

        it('all cells of second row should match', () => {
            const cellValues = [];
            const expectedCellValue = ['Apr 02, 2017', '4', '10,650.00', '-9,753.00', '1,371'];
            const row = page.queryEntityRow(1);
            const tds = row.queryAll(By.css('td'));
            for (const td of tds) {
                cellValues.push(td.nativeElement.innerText);
            }

            expect(cellValues).toEqual(expectedCellValue);
        });

        it('all cells of total row should match', () => {
            const cellValues = [];
            const expectedCellValue = ['Total', '70', '25,450.00', '2,229.00', '4,751'];
            const row = page.queryTotalRow();
            const tds = row.queryAll(By.css('td'));
            for (const td of tds) {
                cellValues.push(td.nativeElement.innerText);
            }

            expect(cellValues).toEqual(expectedCellValue);
        });
    });
});
