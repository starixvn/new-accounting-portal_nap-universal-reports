import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
import { DateHelper } from 'nap-components/src/date';
import { FilterModel, FilterModelWrapper } from '../../filter/filter.model';
import { GridService } from '../grid.service';
import { DetailData, DetailGridModel } from './detail-grid.model';

@Injectable()
export class DetailGridService {
    private url = 'api/play-for-fun/detail';
    model: DetailGridModel;

    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<DetailData> {
        const queryModel = this.createQueryModel();
        return this.httpService.post<DetailData>(this.url, queryModel);
    }

    private createQueryModel(): any {
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        const dateString = DateHelper.convertDateStructToString(this.model.Date);
        return {
            fromDate: dateString,
            toDate: dateString,
            productId: filterModel.product,
            statusId: filterModel.status,
            userName: filterModel.userName,
            excludeTest: filterModel.isExcludeTest
        };
    }
}
