import { NapDateStruct } from 'nap-components/date';
import { PeriodType } from '../filter.model';

export class PeriodTypeEventModel {
    periodType: PeriodType;
    fromDate: NapDateStruct;
    toDate: NapDateStruct;
}
