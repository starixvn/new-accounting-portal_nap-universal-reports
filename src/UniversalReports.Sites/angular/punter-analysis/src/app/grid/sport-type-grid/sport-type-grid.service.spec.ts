import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { TreeviewItem } from 'ng2-dropdown-treeview';
import * as _ from 'lodash';
import { RoleId, SortBy, OptionItem } from 'nap-components/src/model';
import { Helper } from '../../components/helper';
import { HttpService } from '../../components/http.service';
import { GridService } from '../grid.service';
import { SportTypeGridService } from './sport-type-grid.service';
import { SportTypeData } from './sport-type-grid.model';
import { fakeFilterModel } from '../../filter/filter.model.spec';
import { SearchBy, OrderBy, PeriodType } from '../../filter/filter.model';
import { AppModule } from '../../app.module';


describe('SportTypeGridService', () => {

    const expectedQueryModel = {
        periodType: 1,
        fromDate: '2016-01-01T00:00:00',
        toDate: '2016-02-02T00:00:00',
        listCombinationId: '1,2',
        custId: 1
    };
    const expectedExcelModel = {
        custId: 1,
        filter: 'User Name: Customer 1\nOrder by: WinLoss, Ascending\nSport Type: SportType1, SportType2',
        fromDate: '2016-01-01T00:00:00',
        listCombinationId: '1,2',
        periodType: 1,
        title: 'Punter Analysis from Jan 01, 2016 to Feb 02, 2016 (Daily)',
        toDate: '2016-02-02T00:00:00'
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

    beforeEach(inject([SportTypeGridService], (service: SportTypeGridService) => {
        service.model = {
            custId: 1,
            custName: 'Customer 1'
        };
    }));

    it('query', inject([HttpService, SportTypeGridService], (httpService: HttpService, service: SportTypeGridService) => {
        const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));

        service.query();
        const mostRecentCall = spy.calls.mostRecent();
        const args = mostRecentCall.args;
        expect(args[0]).toBe('api/punter-analysis/sport-type');
        expect(args[1]).toEqual(expectedQueryModel);
    }));

    it('exportExcel', inject([HttpService, SportTypeGridService], (httpService: HttpService, service: SportTypeGridService) => {
        const downloadSpy = spyOn(httpService, 'download').and.returnValue(Observable.of(null));
        const saveSpy = spyOn(Helper, 'saveExcel').and.callFake(() => { });

        service.exportExcel();
        let mostRecentCall = downloadSpy.calls.mostRecent();
        let args = mostRecentCall.args;

        expect(args[0]).toBe('api/punter-analysis/sport-type/excel');
        expect(args[1]).toEqual(expectedExcelModel);

        mostRecentCall = saveSpy.calls.mostRecent();
        args = mostRecentCall.args;
        const expectedFileName = 'Top_Punter_Sporttype_Search_by_User_From_Jan_01_2016_To_Feb_02_2016.xlsx';
        expect(args[0]).toBe(null);
        expect(args[1]).toBe(expectedFileName);
    }));
});
