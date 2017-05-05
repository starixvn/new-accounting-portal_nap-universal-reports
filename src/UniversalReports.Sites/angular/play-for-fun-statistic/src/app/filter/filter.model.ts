import { NgbDateStruct } from 'nap-components/src/date';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { Status } from './filter.model.status';

export interface FilterModel {
    fromDate: NgbDateStruct;
    toDate: NgbDateStruct;
    product: number;
    productOptions: SelectItem[];
    status: Status;
    userName: string;
    isExcludeTest: boolean;
}
