import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpService } from 'nap-components/src/http.service';
import { Helper } from 'nap-components/src/helper';
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

    exportExcel() {
        const url = `${this.url}/excel`;
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        const queryModel = this.createQueryModel();
        queryModel.title = `Play For Fun ${filterModelWrapper.productName} Statistics - ${filterModelWrapper.dateFromToTitle}`;
        this.httpService.download(url, queryModel).subscribe(response => {
            const fileName = `PFF_${filterModelWrapper.productFileName}_Statistic_Report_${filterModelWrapper.dateFromToFileName}.xlsx`;
            Helper.saveExcel(response, fileName);
        });
    }

    private createQueryModel(): any {
        const filterModel = this.gridService.filterModel;
        const filterModelWrapper = new FilterModelWrapper(filterModel);
        return {
            fromDate: filterModelWrapper.fromDateQueryString,
            toDate: filterModelWrapper.toDateQueryString,
            productId: filterModel.product,
            statusId: filterModel.status,
            userName: filterModel.userName,
            excludeTest: filterModel.isExcludeTest
        };
    }
}
