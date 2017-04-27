import { NgbDateStruct } from 'nap-components/src/date';
import { PeriodType } from '../filter.model.main';

export interface PeriodTypeEventModel {
    periodType: PeriodType;
    fromDate: NgbDateStruct;
    toDate: NgbDateStruct;
}
