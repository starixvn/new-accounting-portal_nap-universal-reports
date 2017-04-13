import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { TreeviewItem } from 'ng2-dropdown-treeview';
import * as _ from 'lodash';
import { RoleId, SortBy, OptionItem } from 'nap-components/src/model';
import { Helper } from '../../components/helper';
import { HttpService } from '../../components/http.service';
import { GridService } from '../grid.service';
import { SummaryGridService } from './summary-grid.service';
import { SummaryData } from './summary-grid.model';
import { SearchBy, OrderBy, PeriodType } from '../../filter/filter.model';
import { fakeFilterModel } from '../../filter/filter.model.spec';
import { AppModule } from '../../app.module';

describe('SummaryGridService', () => {
    const expectedQueryModel = {
        topRow: 2,
        orderBy: 1,
        sortBy: 1,
        periodType: 1,
        fromDate: '2016-01-01T00:00:00',
        toDate: '2016-02-02T00:00:00',
        depth: 2,
        userName: 'ABC',
        listCombinationId: '1,2'
    };
    const expectedExcelModel = _.extend({}, expectedQueryModel, {
        title: 'Punter Analysis from Jan 01, 2016 to Feb 02, 2016 (Daily)',
        filter: [
            'Depth: Agent - Account name: ABC',
            'Top rows: 2 - Order by: WinLoss, Ascending',
            'Sport Type: SportType1, SportType2'
        ].join('\n')
    });

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

    it('query', inject([HttpService, SummaryGridService], (httpService: HttpService, service: SummaryGridService) => {
        const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));
        service.query();
        const mostRecentCall = spy.calls.mostRecent();
        const args = mostRecentCall.args;
        expect(args[0]).toBe('api/punter-analysis/summary');
        expect(args[1]).toEqual(expectedQueryModel);
    }));

    it('exportExcel', inject([HttpService, SummaryGridService], (httpService: HttpService, service: SummaryGridService) => {
        const downloadSpy = spyOn(httpService, 'download').and.returnValue(Observable.of(null));
        const saveSpy = spyOn(Helper, 'saveExcel').and.callFake(() => { });
        service.exportExcel();
        let mostRecentCall = downloadSpy.calls.mostRecent();
        let args = mostRecentCall.args;
        expect(args[0]).toBe('api/punter-analysis/summary/excel');
        expect(args[1]).toEqual(expectedExcelModel);
        mostRecentCall = saveSpy.calls.mostRecent();
        args = mostRecentCall.args;
        const expectedFileName = 'Top_Punter_Summary_Search_by_User_from_Jan_01_2016_to_Feb_02_2016.xlsx';
        expect(args[0]).toBe(null);
        expect(args[1]).toBe(expectedFileName);
    }));
});
