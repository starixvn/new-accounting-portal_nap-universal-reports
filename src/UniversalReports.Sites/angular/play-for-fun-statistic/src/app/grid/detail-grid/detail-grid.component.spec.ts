import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async, fakeAsync, tick } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { PaginationInstance } from 'ng2-pagination';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import * as _ from 'lodash';
import { expect } from 'nap-components/src/testing';
import { fakeFilterModel } from '../../filter/filter.model.spec';
import { GridService } from '../grid.service';
import { GridType } from '../grid.model';
import { fakeData } from './detail-grid.model.spec';
import { AppModule } from '../../app.module';
import { DetailGridComponent } from './detail-grid.component';
import { DetailGridService } from './detail-grid.service';
import { DetailGridModel } from './detail-grid.model';

class Page {
    constructor(
        private fixture: ComponentFixture<DetailGridComponent>
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
    let fixture: ComponentFixture<DetailGridComponent>;
    let component: DetailGridComponent;
    let page: Page;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                AppModule
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(DetailGridComponent);
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

    it('should mark hasExcel as false', () => {
        expect(component.hasData).toBe(false);
    });

    describe('mock', () => {
        let gridService: GridService;
        let selectedGridType: GridType;
        let service: DetailGridService;

        beforeEach(() => {
            gridService = fixture.debugElement.injector.get(GridService);
            gridService.filterModel = fakeFilterModel;
            gridService.generate = (gridType) => selectedGridType = gridType;
            service = fixture.debugElement.injector.get(DetailGridService);
            service.model = {
                Date: { year: 2017, month: 4, day: 2 }
            };

            spyOn(service, 'query').and.returnValue(Observable.of(fakeData));
            component.query();
            fixture.detectChanges();
        });

        it('should mark hasData as true if entities is not empty', () => {
            expect(component.hasData).toBe(true);
        });

        it('should have 2 items for pagination', () => {
            const expectedConfig: PaginationInstance = {
                id: 'custom',
                itemsPerPage: 100,
                currentPage: 1,
                totalItems: 2
            };
            expect(component.config).toEqual(expectedConfig);
        });

        it('all cells of first row should match', () => {
            const cellValues = [];
            // tslint:disable-next-line:max-line-length
            const expectedCellValue = ['SUPERTESTTE010500', 'BEST-ODDS', 'UUS', 'Super1', 'SUPERTESTTE010500001', '23534245', 'RNG Casino', 'Enabled', 'Yes', '500.00', '-402.00', '5'];
            const row = page.queryEntityRow(0);
            const tds = row.queryAll(By.css('td'));
            for (const td of tds) {
                cellValues.push(td.nativeElement.innerText);
            }

            expect(cellValues).toEqual(expectedCellValue);
        });

        it('all cells of second row should match', () => {
            const cellValues = [];
            // tslint:disable-next-line:max-line-length
            const expectedCellValue = ['SUPERTESTTE010502', 'BEST-ODDS', 'UUS', '', 'SUPERTESTTE010501002', '24144943', 'RNG Casino', 'Disabled', 'No', '9,650.00', '-9,549.00', '1,111'];
            const row = page.queryEntityRow(1);
            const tds = row.queryAll(By.css('td'));
            for (const td of tds) {
                cellValues.push(td.nativeElement.innerText);
            }

            expect(cellValues).toEqual(expectedCellValue);
        });

        it('all cells of total row should match', () => {
            const cellValues = [];
            const expectedCellValue = ['Total', '10,650.00', '-9,753.00', '1,371'];
            const row = page.queryTotalRow();
            const tds = row.queryAll(By.css('td'));
            for (const td of tds) {
                cellValues.push(td.nativeElement.innerText);
            }

            expect(cellValues).toEqual(expectedCellValue);
        });
    });
});
