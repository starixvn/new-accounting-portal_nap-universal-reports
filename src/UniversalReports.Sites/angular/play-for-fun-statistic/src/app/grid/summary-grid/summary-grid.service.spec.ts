import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import * as _ from 'lodash';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { AppModule } from '../../app.module';
import { fakeFilterModel } from '../../filter/filter.model.spec';
import { GridService } from '../grid.service';
import { SummaryGridService } from './summary-grid.service';

describe('SummaryGridService', () => {
    const expectedQueryModel = {
        fromDate: '2017-04-01T00:00:00',
        toDate: '2017-04-19T00:00:00',
        productId: 1,
        statusId: 2,
        userName: 'ABC',
        excludeTest: true
    };
    const expectedExcelModel = _.extend({}, expectedQueryModel, {
        title: 'Play For Fun Product 1 Summary - From Apr 01, 2017 To Apr 19, 2017',
        productName: 'Product 1'
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
        expect(args[0]).toBe('api/play-for-fun/summary');
        expect(args[1]).toEqual(expectedQueryModel);
    }));

    it('exportExcel', inject([HttpService, SummaryGridService], (httpService: HttpService, service: SummaryGridService) => {
        const downloadSpy = spyOn(httpService, 'download').and.returnValue(Observable.of(null));
        const saveSpy = spyOn(Helper, 'saveExcel').and.callFake(() => { });
        service.exportExcel();
        let mostRecentCall = downloadSpy.calls.mostRecent();
        let args = mostRecentCall.args;
        expect(args[0]).toBe('api/play-for-fun/summary/excel');
        expect(args[1]).toEqual(expectedExcelModel);
        mostRecentCall = saveSpy.calls.mostRecent();
        args = mostRecentCall.args;
        const expectedFileName = 'PFF_Product_1_Statistic_Report_From_Apr_01_2017_To_Apr_19_2017.xlsx';
        expect(args[0]).toBe(null);
        expect(args[1]).toBe(expectedFileName);
    }));
});
