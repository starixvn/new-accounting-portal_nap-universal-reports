import { Pipe, PipeTransform } from '@angular/core';
import * as _ from 'lodash';
import * as moment from 'moment';
import { PeriodType } from '../../filter/filter.model';

@Pipe({
    name: 'napPeriodDate'
})
export class PeriodDatePipe implements PipeTransform {
    transform(date: any, periodType: PeriodType): string {
        if (_.isNil(date) || _.isNil(periodType)) {
            return '';
        }

        switch (periodType) {
            case PeriodType.Daily:
                return moment.utc(date).format('YYYY-MM-DD');
            case PeriodType.Weekly:
                return moment.utc(date).format('MM/YYYY') + ' - Week ' + moment(date).format('W');
            case PeriodType.MonthRange:
            case PeriodType.Monthly:
            case PeriodType.Annually:
                return moment.utc(date).format('MM/YYYY');
        }
    }
}
