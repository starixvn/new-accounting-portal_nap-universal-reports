import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { TreeviewItem } from 'ngx-treeview';
import * as _ from 'lodash';
import { Helper } from 'nap-components/src/helper';
import { HttpService } from 'nap-components/src/http.service';
import { GridService } from '../grid.service';
import { BetCountGridService } from './bet-count-grid.service';
import { BetCountData } from './bet-count-grid.model';
import { fakeFilterModel } from '../../filter/filter.model.spec';
import { SearchBy, OrderBy, PeriodType } from '../../filter/filter.model';
import { AppModule } from '../../app.module';

describe('BetCountGridService', () => {

    const expectedQueryModel = {
        periodType: 1,
        fromDate: '2016-01-01T00:00:00',
        toDate: '2016-02-02T00:00:00',
        listCombinationId: '1,2',
        custId: 1,
        sportId: 1,
        betTypeId: 1,
        liveStatusId: 2
    };
    const expectedExcelModel = {
        periodType: 1,
        fromDate: '2016-01-01T00:00:00',
        toDate: '2016-02-02T00:00:00',
        listCombinationId: '1,2',
        custId: 1,
        sportId: 1,
        betTypeId: 1,
        liveStatusId: 2,
        title: 'Punter Analysis - Customer 1 by bet count from Jan 01, 2016 to Feb 02, 2016 (Daily)',
        filter: 'Sport Type: SportType1, SportType2'
    };

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                AppModule
            ]
        });
    });

    beforeEach(inject([GridService], (gridService: GridService) => {
        gridService.filterModel = fakeFilterModel;
    }));

    beforeEach(inject([BetCountGridService], (service: BetCountGridService) => {
        service.model = {
            custId: 1,
            custName: 'Customer 1',
            sportId: 1,
            liveStatusId: 2,
            betTypeId: 1
        };
    }));

    it('query', inject([HttpService, BetCountGridService], (httpService: HttpService, service: BetCountGridService) => {
        const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));

        service.query();
        const mostRecentCall = spy.calls.mostRecent();
        const args = mostRecentCall.args;
        expect(args[0]).toBe('api/punter-analysis/bet-count');
        expect(args[1]).toEqual(expectedQueryModel);
    }));

    it('exportExcel', inject([HttpService, BetCountGridService], (httpService: HttpService, service: BetCountGridService) => {
        const downloadSpy = spyOn(httpService, 'download').and.returnValue(Observable.of(null));
        const saveSpy = spyOn(Helper, 'saveExcel').and.callFake(() => { });

        service.exportExcel();
        let mostRecentCall = downloadSpy.calls.mostRecent();
        let args = mostRecentCall.args;

        expect(args[0]).toBe('api/punter-analysis/bet-count/excel');
        expect(args[1]).toEqual(expectedExcelModel);

        mostRecentCall = saveSpy.calls.mostRecent();
        args = mostRecentCall.args;
        const expectedFileName = 'Top_Punter_Summary_Bet_Count_Search_by_User_from_Jan_01_2016_to_Feb_02_2016.xlsx';
        expect(args[0]).toBe(null);
        expect(args[1]).toBe(expectedFileName);
    }));
});
