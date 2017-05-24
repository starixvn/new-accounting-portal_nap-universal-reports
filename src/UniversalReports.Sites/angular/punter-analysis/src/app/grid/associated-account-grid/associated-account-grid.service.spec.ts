import { TestBed, async, inject } from '@angular/core/testing';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { TreeviewItem } from 'ngx-treeview';
import * as _ from 'lodash';
import { Helper } from 'nap-components/src/helper';
import { HttpService } from 'nap-components/src/http.service';
import { GridService } from '../grid.service';
import { AssociatedAccountGridService } from './associated-account-grid.service';
import { UserRoleItem } from './associated-account-grid.model';
import { fakeUserFilterModel } from '../../filter/filter.model.spec';
import { SearchBy, OrderBy, PeriodType } from '../../filter/filter.model.main';
import { AppModule } from '../../app.module';

describe('AssociatedAccountGridService', () => {

    const expectedQueryModel = {
        custId: 1,
        userName: 'Customer 1'
    };
    const expectedExcelModel = {
        custId: 1,
        userName: 'Customer 1',
        title: 'Associated Account of Punter Customer 1 from Jan 01, 2016 to Feb 02, 2016 (Daily)',
        filter: `User Name: Customer 1\nTop rows: 9,999 - Order by: WinLoss, Ascending\nSport Type: SportType 1, SportType 2`
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

    beforeEach(inject([AssociatedAccountGridService], (service: AssociatedAccountGridService) => {
        service.model = {
            custId: 1,
            custName: 'Customer 1'
        };
    }));

    it('query', inject([HttpService, AssociatedAccountGridService], (httpService: HttpService, service: AssociatedAccountGridService) => {
        const spy = spyOn(httpService, 'post').and.returnValue(Observable.of(null));

        service.query();
        const mostRecentCall = spy.calls.mostRecent();
        const args = mostRecentCall.args;
        expect(args[0]).toBe('api/punter-analysis/associated-account');
        expect(args[1]).toEqual(expectedQueryModel);
    }));
});
