import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { TreeviewItem } from 'ngx-treeview';
import * as _ from 'lodash';
import { Helper } from 'nap-components/src/helper';
import { HttpService } from 'nap-components/src/http.service';
import { GridService } from '../grid.service';
import { BetCountGridService } from './bet-count-grid.service';
import { BetCountGridModel } from './bet-count-grid.model';
import { BetCountData } from './bet-count-grid.model';
import { fakeUserFilterModel, fakeLeagueFilterModel } from '../../filter/filter.model.spec';
import { SearchBy, OrderBy, PeriodType, FilterModel } from '../../filter/filter.model';
import { AppModule } from '../../app.module';

describe('BetCountGridService', () => {

    const fakeModel: BetCountGridModel = {
        custId: 1,
        custName: 'Customer 1',
        sportId: 1,
        liveStatusId: 2,
        betTypeId: 1
    };

    const expectedQueryModel = {
        user: {
            periodType: 1,
            fromDate: '2016-01-01T00:00:00',
            toDate: '2016-02-02T00:00:00',
            listCombinationId: '1,2',
            leagueId: 0,
            custId: 1,
            sportId: 1,
            betTypeId: 1,
            liveStatusId: 2
        },
        league: {
            periodType: 1,
            fromDate: '2016-01-01T00:00:00',
            toDate: '2016-02-02T00:00:00',
            listCombinationId: '1,2',
            leagueId: 1,
            custId: 1,
            sportId: 1,
            betTypeId: 1,
            liveStatusId: 2
        }
    };

    const expectedExcelModel = {
        user: _.extend({}, expectedQueryModel.user, {
            title: 'Punter Analysis - Customer 1 by bet count from Jan 01, 2016 to Feb 02, 2016 (Daily)',
            filter: 'Sport Type: SportType1, SportType2'
        }),
        league: _.extend({}, expectedQueryModel.league, {
            title: 'Punter Analysis - Customer 1 by bet count from Jan 01, 2016 to Feb 02, 2016 (Daily)',
            filter: 'Sport Type: SportType1\nLeague: League1'
        })
    };

    const expectedExcelFileName = {
        user: 'Top_Punter_Summary_Bet_Count_Search_by_User_from_Jan_01_2016_to_Feb_02_2016.xlsx',
        league: 'Top_Punter_Summary_Bet_Count_Search_by_League_from_Jan_01_2016_to_Feb_02_2016.xlsx'
    };

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                AppModule
            ]
        });
    });

    beforeEach(inject([BetCountGridService], (service: BetCountGridService) => {
        service.model = fakeModel;
    }));

    it('query', inject([HttpService, GridService, BetCountGridService],
        (httpService: HttpService, gridService: GridService, service: BetCountGridService) => {
            const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));

            function expectModel(fakeFilterModel: FilterModel, expectedModel: any) {
                gridService.filterModel = fakeFilterModel;
                service.query();
                const mostRecentCall = spy.calls.mostRecent();
                const args = mostRecentCall.args;
                expect(args[0]).toBe('api/punter-analysis/bet-count');
                expect(args[1]).toEqual(expectedModel);
            }

            expectModel(fakeUserFilterModel, expectedQueryModel.user);
            expectModel(fakeLeagueFilterModel, expectedQueryModel.league);
        }));

    it('exportExcel', inject([HttpService, GridService, BetCountGridService],
        (httpService: HttpService, gridService: GridService, service: BetCountGridService) => {
            const downloadSpy = spyOn(httpService, 'download').and.returnValue(Observable.of(null));
            const saveSpy = spyOn(Helper, 'saveExcel').and.callFake(() => { });

            function expectModel(fakeFilterModel: FilterModel, expectedExcel: any, expectedFileName: string) {
                gridService.filterModel = fakeFilterModel;
                service.exportExcel();
                let mostRecentCall = downloadSpy.calls.mostRecent();
                let args = mostRecentCall.args;

                expect(args[0]).toBe('api/punter-analysis/bet-count/excel');
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
