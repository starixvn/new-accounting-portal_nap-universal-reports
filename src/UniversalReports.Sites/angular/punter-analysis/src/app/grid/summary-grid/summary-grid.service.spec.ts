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
import { AppModule } from '../../app.module';
import { SearchBy, OrderBy, PeriodType } from '../../filter/filter.model';

describe('SummaryGridService', () => {
    const filterModel = {
        searchBy: SearchBy.User,
        topRow: 2,
        orderBy: OrderBy.WinLoss,
        sortBy: SortBy.Ascending,
        periodType: PeriodType.Daily,
        fromDate: { year: 2016, month: 1, day: 1 },
        toDate: { year: 2016, month: 2, day: 2 },
        depth: RoleId.Agent,
        userName: 'ABC',
        selectedBetTypeTreeviewItems: [
            {
                item: new TreeviewItem({ text: 'BetType1', value: 1 }),
                parent: { item: new TreeviewItem({ text: 'SportType1', value: 1 }), parent: null }
            },
            {
                item: new TreeviewItem({ text: 'BetType2', value: 2 }),
                parent: { item: new TreeviewItem({ text: 'SportType2', value: 1 }), parent: null }
            }
        ],
        searchByOptions: [
            { text: 'User', value: SearchBy.User }
        ],
        depthOptions: [
            { text: 'Agent', value: RoleId.Agent }
        ],
        orderByOptions: [
            { text: 'WinLoss', value: OrderBy.WinLoss }
        ],
        sortByOptions: [
            { text: 'Ascending', value: SortBy.Ascending }
        ]
    };
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
        gridService.filterModel = filterModel;
    }));

    it('query', inject([HttpService, SummaryGridService], (httpService: HttpService, service: SummaryGridService) => {
        const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));
        service.query();
        const mostRecentCall = spy.calls.mostRecent();
        const args = mostRecentCall.args;
        expect(args[0]).toBe('api/punter-analysis/summary');
        expect(_.isEqual(args[1], expectedQueryModel)).toBe(true);
    }));

    it('exportExcel', inject([HttpService, SummaryGridService], (httpService: HttpService, service: SummaryGridService) => {
        const downloadSpy = spyOn(httpService, 'download').and.returnValue(Observable.of(null));
        const saveSpy = spyOn(Helper, 'saveExcel').and.callFake(() => { });
        service.exportExcel();
        let mostRecentCall = downloadSpy.calls.mostRecent();
        let args = mostRecentCall.args;
        expect(args[0]).toBe('api/punter-analysis/summary/excel');
        expect(_.isEqual(args[1], expectedExcelModel)).toBe(true);
        mostRecentCall = saveSpy.calls.mostRecent();
        args = mostRecentCall.args;
        const expectedFileName = 'Top_Punter_Summary_Search_by_User_From_Jan_01_2016_To_Feb_02_2016.xlsx';
        expect(args[0]).toBe(null);
        expect(args[1]).toBe(expectedFileName);
    }));
});
