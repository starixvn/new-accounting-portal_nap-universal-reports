///<reference path="../../../../node_modules/nap-components/src/testing/jasmine-matchers.d.ts" />
import { Component, DebugElement } from '@angular/core';
import { TestBed, ComponentFixture, async, fakeAsync, tick } from '@angular/core/testing';
import { BrowserModule, By } from '@angular/platform-browser';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import * as _ from 'lodash';
import { PaginationInstance } from 'ng2-pagination';
import { GridService } from '../grid.service';
import { GridType } from '../grid.model';
import { SummaryGridService } from './summary-grid.service';
import { BetCountGridService } from '../bet-count-grid/bet-count-grid.service';
import { BetCountGridModel } from '../bet-count-grid/bet-count-grid.model';
import { AssociatedAccountGridService } from '../associated-account-grid/associated-account-grid.service';
import { AssociatedAccountGridModel } from '../associated-account-grid/associated-account-grid.model';
import { SportTypeGridService } from '../sport-type-grid/sport-type-grid.service';
import { SportTypeGridModel } from '../sport-type-grid/sport-type-grid.model';
import { SummaryGridComponent } from './summary-grid.component';
import { SummaryData } from './summary-grid.model';
import { AppModule } from '../../app.module';

class Page {
    constructor(
        private fixture: ComponentFixture<SummaryGridComponent>
    ) { }

    queryEntityRow(rowIndex: number): DebugElement {
        const tableDebugElements = this.fixture.debugElement.queryAll(By.css('table'));
        return tableDebugElements[1].query(By.css('tr'));
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
        expect(rowDebugElements[1].nativeElement).toHaveText('There is no data');
    });

    describe('mock', () => {
        let gridService: GridService;
        let selectedGridType: GridType;
        let service: SummaryGridService;

        beforeEach(() => {
            gridService = fixture.debugElement.injector.get(GridService);
            gridService.generate = (gridType) => selectedGridType = gridType;
            service = fixture.debugElement.injector.get(SummaryGridService);
            const fakeData: SummaryData = {
                Entities: [
                    { CustId: 23266239, Username: 'HecbetRMB011154', WinLoss: 13024.2343, Turnover: 2490.1800, Margin: 5.2302380952380952380952380952, BetCount: 10 },
                    { CustId: 20117001, Username: 'PYB0201002', WinLoss: 12337.5491, Turnover: 2712.8971, Margin: 4.5477394258705942072038043758, BetCount: 31 }
                ],
                Total: { CustId: 0, Username: '', WinLoss: 25361.7834, Turnover: 5203.0771, Margin: 4.8743816231360477053088450294, BetCount: 41 }
            };
            spyOn(service, 'query').and.returnValue(Observable.of(fakeData));
            component.query();
            fixture.detectChanges();
        });

        it('should have 2 items for pagination', () => {
            const expectedConfig: PaginationInstance = {
                id: 'custom',
                itemsPerPage: 100,
                currentPage: 1,
                totalItems: 2
            }
            expect(_.isEqual(component.config, expectedConfig)).toBe(true);
        });

        it('should have title "Main - Punter Analysis" if it is the last grid', () => {
            gridService.activeGrid = component;
            expect(component.title).toBe('Main - Punter Analysis');
        });

        it('should invoke exportExcel in service when call exportExcel', () => {
            const spy = spyOn(service, 'exportExcel').and.callFake(() => { });
            component.exportExcel();
            expect(spy.calls.count()).toBe(1);
        });

        it('should have title "Main" if it is not the last grid', () => {
            expect(component.title).toBe('Main');
        });

        it('should have 3 tables', () => {
            const tables = fixture.debugElement.queryAll(By.css('table'));
            expect(tables.length).toBe(3);
        });

        it('should invoke to generate SportType when click on the first cell', () => {
            const row = page.queryEntityRow(0);
            const tds = row.queryAll(By.css('td'));
            const link = tds[0].query(By.css('a'));
            link.triggerEventHandler('click', {});
            expect(selectedGridType).toBe(GridType.SportType);
            const sportTypeGridService = fixture.debugElement.injector.get(SportTypeGridService);
            const expectedModel: SportTypeGridModel = {
                custId: 23266239,
                custName: 'HecbetRMB011154'
            };
            expect(sportTypeGridService.model).toEqual(expectedModel);
        });

        it('should invoke to generate BetCount when click on the fifth cell', () => {
            const row = page.queryEntityRow(0);
            const tds = row.queryAll(By.css('td'));
            const link = tds[4].query(By.css('a'));
            link.triggerEventHandler('click', {});
            expect(selectedGridType).toBe(GridType.BetCount);
            const betCountGridService = fixture.debugElement.injector.get(BetCountGridService);
            const expectedModel: BetCountGridModel = {
                custId: 23266239,
                custName: 'HecbetRMB011154'
            };
            expect(betCountGridService.model).toEqual(expectedModel);
        });

        it('should invoke to generate AssociatedAccount when click on the last cell', () => {
            const row = page.queryEntityRow(0);
            const tds = row.queryAll(By.css('td'));
            const link = tds[tds.length - 1].query(By.css('a'));
            link.triggerEventHandler('click', {});
            expect(selectedGridType).toBe(GridType.AssociatedAccount);
            const asssociatedAccountGridService = fixture.debugElement.injector.get(AssociatedAccountGridService);
            const expectedModel: AssociatedAccountGridModel = {
                custId: 23266239,
                custName: 'HecbetRMB011154'
            };
            
            expect(asssociatedAccountGridService.model).toEqual(expectedModel);
        });
    });
});
