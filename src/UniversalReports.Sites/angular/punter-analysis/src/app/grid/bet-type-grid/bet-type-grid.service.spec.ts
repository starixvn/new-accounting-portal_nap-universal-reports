import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { TreeviewItem } from 'ng2-dropdown-treeview';
import * as _ from 'lodash';
import { RoleId, SortBy } from 'nap-components/src/model';
import { Helper } from 'nap-components/src/helper';
import { HttpService } from 'nap-components/src/http.service';
import { GridService } from '../grid.service';
import { BetTypeGridService } from './bet-type-grid.service';
import { BetTypeData } from './bet-type-grid.model';
import { fakeFilterModel } from '../../filter/filter.model.spec';
import { SearchBy, OrderBy, PeriodType } from '../../filter/filter.model';
import { AppModule } from '../../app.module';

describe('BetTypeGridService', () => {
    const expectedQueryModel = {
        periodType: 1,
        fromDate: '2016-01-01T00:00:00',
        toDate: '2016-02-02T00:00:00',
        listCombinationId: '1,2',
        custId: 1,
        sportId: 1
    };
    const expectedExcelModel = {
        periodType: 1,
        fromDate: '2016-01-01T00:00:00',
        toDate: '2016-02-02T00:00:00',
        listCombinationId: '1,2',
        custId: 1, sportId: 1,
        title: 'Punter Analysis from Jan 01, 2016 to Feb 02, 2016 (Daily)',
        filter: `User Name: Customer 1\nOrder by: WinLoss, Ascending\nSport Type: Sport 1`
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

    beforeEach(inject([BetTypeGridService], (service: BetTypeGridService) => {
        service.model = {
            custId: 1,
            custName: 'Customer 1',
            sportId: 1,
            sportName: 'Sport 1'
        };
    }));

    it('query', inject([HttpService, BetTypeGridService], (httpService: HttpService, service: BetTypeGridService) => {
        const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));

        service.query();
        const mostRecentCall = spy.calls.mostRecent();
        const args = mostRecentCall.args;
        expect(args[0]).toBe('api/punter-analysis/bet-type');
        expect(args[1]).toEqual(expectedQueryModel);
    }));

    it('exportExcel', inject([HttpService, BetTypeGridService], (httpService: HttpService, service: BetTypeGridService) => {
        const downloadSpy = spyOn(httpService, 'download').and.returnValue(Observable.of(null));
        const saveSpy = spyOn(Helper, 'saveExcel').and.callFake(() => { });

        service.exportExcel();
        let mostRecentCall = downloadSpy.calls.mostRecent();
        let args = mostRecentCall.args;

        expect(args[0]).toBe('api/punter-analysis/bet-type/excel');
        expect(args[1]).toEqual(expectedExcelModel);

        mostRecentCall = saveSpy.calls.mostRecent();
        args = mostRecentCall.args;
        const expectedFileName = 'Top_Punter_Bettype_Search_by_User_from_Jan_01_2016_to_Feb_02_2016.xlsx';
        expect(args[0]).toBe(null);
        expect(args[1]).toBe(expectedFileName);
    }));
});
