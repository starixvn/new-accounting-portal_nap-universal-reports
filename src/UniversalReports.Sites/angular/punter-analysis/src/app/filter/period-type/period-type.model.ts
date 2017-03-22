import { NgbDateStruct, WeekRange } from 'nap-components/src/date';
import { PeriodType } from '../filter.model';

export interface PeriodTypeEventModel {
    periodType: PeriodType,
    fromDate: NgbDateStruct,
    toDate: NgbDateStruct
}
