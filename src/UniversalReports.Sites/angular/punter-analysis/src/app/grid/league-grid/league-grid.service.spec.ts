import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { TreeviewItem } from 'ng2-dropdown-treeview';
import * as _ from 'lodash';
import { RoleId, SortBy, OptionItem } from 'nap-components/src/model';
import { Helper } from '../../components/helper';
import { HttpService } from '../../components/http.service';
import { GridService } from '../grid.service';
import { LeagueGridService } from './league-grid.service';
import { LeagueData } from './league-grid.model';
import { SearchBy, OrderBy, PeriodType } from '../../filter/filter.model';
import { fakeFilterModel } from '../../filter/filter.model.spec';
import { AppModule } from '../../app.module';


describe('LeagueGridService', () => {

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
        title: `Punter Analysis from Jan 01, 2016 to Feb 02, 2016 (Daily)`,
        filter: `User Name: Customer 1\nOrder by: WinLoss, Ascending\nSport Type: Sport 1\nBet Type: Bet Type 1 - Status: Non-Live`
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

    beforeEach(inject([LeagueGridService], (service: LeagueGridService) => {
        service.model = {
            custId: 1,
            custName: 'Customer 1',
            betTypeId: 1,
            betTypeName: 'Bet Type 1',
            liveStatusId: 2,
            sportId: 1,
            sportName: 'Sport 1'
        };
    }));

    it('getLiveStatusTitle should return "Live" if liveStatusId is LiveStatus.Live',
        inject([LeagueGridService], (service: LeagueGridService) => {
            service.model.liveStatusId = 1;
            const title = service.getLiveStatusTitle();
            expect(title).toEqual('Live');
        }));

    it('getLiveStatusTitle should return "Non-Live" if liveStatusId is LiveStatus.NonLive',
        inject([LeagueGridService], (service: LeagueGridService) => {
            service.model.liveStatusId = 2;
            const title = service.getLiveStatusTitle();
            expect(title).toEqual('Non-Live');
        }));


    it('getLiveStatusTitle should return "Non-Live & Live" if liveStatusId is not LiveStatus.Live or LiveStatus.NonLive',
        inject([LeagueGridService], (service: LeagueGridService) => {
            service.model.liveStatusId = 0;
            const title = service.getLiveStatusTitle();
            expect(title).toEqual('Non-Live & Live');
        }));

    it('query', inject([HttpService, LeagueGridService], (httpService: HttpService, service: LeagueGridService) => {
        const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));

        service.query();
        const mostRecentCall = spy.calls.mostRecent();
        const args = mostRecentCall.args;
        expect(args[0]).toBe('api/punter-analysis/league');
        expect(args[1]).toEqual(expectedQueryModel);
    }));

    it('exportExcel', inject([HttpService, LeagueGridService], (httpService: HttpService, service: LeagueGridService) => {
        const downloadSpy = spyOn(httpService, 'download').and.returnValue(Observable.of(null));
        const saveSpy = spyOn(Helper, 'saveExcel').and.callFake(() => { });

        service.exportExcel();
        let mostRecentCall = downloadSpy.calls.mostRecent();
        let args = mostRecentCall.args;

        expect(args[0]).toBe('api/punter-analysis/league/excel');
        expect(args[1]).toEqual(expectedExcelModel);

        mostRecentCall = saveSpy.calls.mostRecent();
        args = mostRecentCall.args;
        const expectedFileName = 'Top_Punter_League_Search_by_User_from_Jan_01_2016_to_Feb_02_2016.xlsx';
        expect(args[0]).toBe(null);
        expect(args[1]).toBe(expectedFileName);
    }));
});
