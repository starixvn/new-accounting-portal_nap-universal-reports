import { Injectable } from '@angular/core';
import { FilterModel } from './../filter/filter.model';
import { DateHelper, DateFormat } from 'nap-components/date';
import { QueryModel } from './query.model';

@Injectable()
export class QueryModelService {
    public createQueryModel(filterModel: FilterModel): QueryModel {
        const startDate =  DateHelper.formatMomentDate(filterModel.fromDate, DateFormat.Date);
        const endDate =  DateHelper.formatMomentDate(filterModel.toDate, DateFormat.Date);
        const model = new QueryModel(startDate, endDate, filterModel.userName);

        return model;
    }
}
