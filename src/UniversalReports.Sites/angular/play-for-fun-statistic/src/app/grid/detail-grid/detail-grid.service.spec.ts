import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import * as _ from 'lodash';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { AppModule } from '../../app.module';
import { fakeFilterModel } from '../../filter/filter.model.spec';
import { GridService } from '../grid.service';
import { DetailGridService } from './detail-grid.service';
import { DetailGridModel } from './detail-grid.model';

describe('DetailGridService', () => {
    const fakeModel: DetailGridModel = {
        Date: { year: 2017, month: 4, day: 2 }
    };
    const expectedQueryModel = {
        fromDate: '2017-04-02T00:00:00',
        toDate: '2017-04-02T00:00:00',
        productId: 1,
        statusId: 2,
        userName: 'ABC',
        excludeTest: true
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

    beforeEach(inject([DetailGridService], (service: DetailGridService) => {
        service.model = fakeModel;
    }));

    it('query', inject([HttpService, DetailGridService], (httpService: HttpService, service: DetailGridService) => {
        const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));
        service.query();
        const mostRecentCall = spy.calls.mostRecent();
        const args = mostRecentCall.args;
        expect(args[0]).toBe('api/play-for-fun/detail');
        expect(args[1]).toEqual(expectedQueryModel);
    }));
});
