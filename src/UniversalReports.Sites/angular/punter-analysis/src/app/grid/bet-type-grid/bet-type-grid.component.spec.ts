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
import { BetTypeGridService } from './bet-type-grid.service';
import { BetTypeGridModel } from './bet-type-grid.model';
import { BetTypeGridComponent } from './bet-type-grid.component';
import { BetTypeData } from './bet-type-grid.model';
import { BetCountGridService } from '../bet-count-grid/bet-count-grid.service';
import { BetCountGridModel } from '../bet-count-grid/bet-count-grid.model';
import { LeagueGridService } from '../league-grid/league-grid.service';
import { LeagueGridModel } from '../league-grid/league-grid.model';

import { AppModule } from '../../app.module';

class Page {
    constructor(
        private fixture: ComponentFixture<BetTypeGridComponent>
    ) { }

    queryEntityRow(rowIndex: number): DebugElement {
        const tableDebugElements = this.fixture.debugElement.queryAll(By.css('table'));
        return tableDebugElements[1].query(By.css('tr'));
    }
}

describe('BetTypeGridComponent', () => {
    let fixture: ComponentFixture<BetTypeGridComponent>;
    let component: BetTypeGridComponent;
    let page: Page;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                AppModule
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(BetTypeGridComponent);
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
        expect(rowDebugElements[2].nativeElement).toHaveText('There is no data');
    });

    it('should mark hasData as true if entities is empty', () => {
        expect(component.hasData).toBe(false);
    });

    describe('mock', () => {
        let gridService: GridService;
        let selectedGridType: GridType;
        let service: BetTypeGridService;

        beforeEach(() => {
            gridService = fixture.debugElement.injector.get(GridService);
            gridService.generate = (gridType) => selectedGridType = gridType;

            const fakeBetTypeGridModel: BetTypeGridModel = {
                custId: 1,
                custName: "Customer 1",
                sportId: 1,
                sportName: "Sport 1"
            };

            const fakeData: BetTypeData = {
                Entities: [
                    { BetTypeId: 1, BetTypeName: 'Bet Type 1', HasLeague: true, NonLiveWinLoss: 13024.2343, NonLiveTurnover: 2490.1800, NonLiveMargin: 5.2302380952380952380952380952, NonLiveBetCount: 10, LiveWinLoss: 13024.2343, LiveTurnover: 2490.1800, LiveMargin: 5.2302380952380952380952380952, LiveBetCount: 10, WinLoss: 13024.2343, Turnover: 2490.1800, Margin: 5.2302380952380952380952380952, BetCount: 10 },
                    { BetTypeId: 2, BetTypeName: 'Bet Type 2', HasLeague: true, NonLiveWinLoss: 12337.5491, NonLiveTurnover: 2712.8971, NonLiveMargin: 4.5477394258705942072038043758, NonLiveBetCount: 31, LiveWinLoss: 12337.5491, LiveTurnover: 2712.8971, LiveMargin: 4.5477394258705942072038043758, LiveBetCount: 31, WinLoss: 12337.5491, Turnover: 2712.8971, Margin: 4.5477394258705942072038043758, BetCount: 31 }
                ],
                Total: { BetTypeId: 0, BetTypeName: '', HasLeague: false, NonLiveWinLoss: 25361.7834, NonLiveTurnover: 5203.0771, NonLiveMargin: 4.8743816231360477053088450294, NonLiveBetCount: 41, LiveWinLoss: 25361.7834, LiveTurnover: 5203.0771, LiveMargin: 4.8743816231360477053088450294, LiveBetCount: 41, WinLoss: 25361.7834, Turnover: 5203.0771, Margin: 4.8743816231360477053088450294, BetCount: 41 }
            };

            service = fixture.debugElement.injector.get(BetTypeGridService);
            service.model = fakeBetTypeGridModel;
            spyOn(service, 'query').and.returnValue(Observable.of(fakeData));

            component.query();
            fixture.detectChanges();
        });

        it('should mark hasData as true if entities is not empty', () => {
            expect(component.hasData).toBe(true);
        });

        it('should have title "Sport 1"', () => {
            expect(component.title).toBe('Sport 1');
        });

        it('should invoke exportExcel in service when call exportExcel', () => {
            const spy = spyOn(service, 'exportExcel').and.callFake(() => { });
            component.exportExcel();
            expect(spy.calls.count()).toBe(1);
        });

        it('should have 3 tables', () => {
            const tables = fixture.debugElement.queryAll(By.css('table'));
            expect(tables.length).toBe(3);
        });

        it('should invoke to generate League when click on the second cell', () => {
            const row = page.queryEntityRow(0);
            const tds = row.queryAll(By.css('td'));
            const link = tds[1].query(By.css('a'));
            link.triggerEventHandler('click', {});
            expect(selectedGridType).toBe(GridType.League);
            const leagueGridService = fixture.debugElement.injector.get(LeagueGridService);
            const expectedModel: LeagueGridModel = {
                betTypeId: 1,
                betTypeName: "Bet Type 1",
                custId: 1,
                custName: "Customer 1",
                liveStatusId: 2,
                sportId: 1,
                sportName: "Sport 1"
            };
            expect(leagueGridService.model).toEqual(expectedModel);
        });

        it('should invoke to generate BetCount when click on the fifth cell', () => {
            const row = page.queryEntityRow(0);
            const tds = row.queryAll(By.css('td'));
            const link = tds[4].query(By.css('a'));
            link.triggerEventHandler('click', {});
            expect(selectedGridType).toBe(GridType.BetCount);
            const betCountGridService = fixture.debugElement.injector.get(BetCountGridService);
            const expectedModel: BetCountGridModel = {
                custId: 1,
                custName: 'Customer 1',
                sportId: 1,
                betTypeId: 1,
                liveStatusId: 2
            };
            expect(betCountGridService.model).toEqual(expectedModel);
        });
    });
});
