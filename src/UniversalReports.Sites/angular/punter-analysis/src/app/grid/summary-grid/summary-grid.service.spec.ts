import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { TreeviewItem } from 'ngx-treeview';
import * as _ from 'lodash';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { GridService } from '../grid.service';
import { SummaryGridService } from './summary-grid.service';
import { SummaryData } from './summary-grid.model';
import { FilterModel } from '../../filter/filter.model';
import { SearchBy, OrderBy, PeriodType } from '../../filter/filter.model.main';
import { fakeUserFilterModel, fakeLeagueFilterModel } from '../../filter/filter.model.spec';
import { AppModule } from '../../app.module';

describe('SummaryGridService', () => {
    const expectedQueryModel = {
        user: {
            topRow: 2,
            orderBy: 1,
            sortBy: 1,
            periodType: 1,
            fromDate: '2016-01-01T00:00:00',
            toDate: '2016-02-02T00:00:00',
            depth: 2,
            userName: 'ABC',
            listCombinationId: '1,2',
            leagueId: 0
        },
        league: {
            topRow: 2,
            orderBy: 1,
            sortBy: 1,
            periodType: 1,
            fromDate: '2016-01-01T00:00:00',
            toDate: '2016-02-02T00:00:00',
            depth: 0,
            userName: '',
            listCombinationId: '1,2',
            leagueId: 1
        }
    };

    const expectedExcelModel = {
        user: _.extend({}, expectedQueryModel.user, {
            title: 'Punter Analysis from Jan 01, 2016 to Feb 02, 2016 (Daily)',
            filter: 'Depth: Agent - Account name: ABC\nTop rows: 2 - Order by: WinLoss, Ascending\nSport Type: SportType1, SportType2'
        }),
        league: _.extend({}, expectedQueryModel.league, {
            title: 'Punter Analysis from Jan 01, 2016 to Feb 02, 2016 (Daily)',
            filter: 'User Name: All\nTop rows: 2 - Order by: WinLoss, Ascending\nSport Type: SportType1\nLeague: League1'
        })
    };

    const expectedExcelFileName = {
        user: 'Top_Punter_Summary_Search_by_User_from_Jan_01_2016_to_Feb_02_2016.xlsx',
        league: 'Top_Punter_Summary_Search_by_League_from_Jan_01_2016_to_Feb_02_2016.xlsx'
    };

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                AppModule
            ]
        });
    });

    beforeEach(inject([GridService], (gridService: GridService) => {
        gridService.filterModel = fakeUserFilterModel;
    }));

    it('query', inject([HttpService, GridService, SummaryGridService],
        (httpService: HttpService, gridService: GridService, service: SummaryGridService) => {
            const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));

            function expectModel(fakeFilterModel: FilterModel, expectedModel: any) {
                gridService.filterModel = fakeFilterModel;
                service.query();
                const mostRecentCall = spy.calls.mostRecent();
                const args = mostRecentCall.args;
                expect(args[0]).toBe('api/punter-analysis/summary');
                expect(args[1]).toEqual(expectedModel);
            }

            expectModel(fakeUserFilterModel, expectedQueryModel.user);
            expectModel(fakeLeagueFilterModel, expectedQueryModel.league);
        }));

    it('exportExcel', inject([HttpService, GridService, SummaryGridService],
        (httpService: HttpService, gridService: GridService, service: SummaryGridService) => {
            const downloadSpy = spyOn(httpService, 'download').and.returnValue(Observable.of(null));
            const saveSpy = spyOn(Helper, 'saveExcel').and.callFake(() => { });

            function expectModel(fakeFilterModel: FilterModel, expectedExcel: any, expectedFileName: string) {
                gridService.filterModel = fakeFilterModel;
                service.exportExcel();
                let mostRecentCall = downloadSpy.calls.mostRecent();
                let args = mostRecentCall.args;
                expect(args[0]).toBe('api/punter-analysis/summary/excel');
                expect(args[1]).toEqual(expectedExcel);
                mostRecentCall = saveSpy.calls.mostRecent();
                args = mostRecentCall.args;
                expect(args[0]).toBe(null);
                expect(args[1]).toBe(expectedFileName);
            }

            expectModel(fakeUserFilterModel, expectedExcelModel.user, expectedExcelFileName.user);
            expectModel(fakeLeagueFilterModel, expectedExcelModel.league, expectedExcelFileName.league);
        }));
});
