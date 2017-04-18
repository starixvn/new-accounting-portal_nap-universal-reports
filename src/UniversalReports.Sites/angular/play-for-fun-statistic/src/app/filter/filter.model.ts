import { NgbDateStruct, DateHelper, DateFormat } from 'nap-components/src/date';
import { SelectItem } from 'nap-components/src/dropdown-select';

export enum Status {
    All = 0,
    Enabled = 1,
    Disabled = -1
}

export interface FilterModel {
    fromDate: NgbDateStruct;
    toDate: NgbDateStruct;
    product: number;
    productOptions: SelectItem[];
    status: Status;
    userName: string;
    isExcludeTest: boolean;
}

export class FilterModelWrapper {
    constructor(
        private filterModel: FilterModel
    ) { }

    get fromDateQueryString(): string {
        return DateHelper.convertDateStructToString(this.filterModel.fromDate);
    }

    get toDateQueryString(): string {
        return DateHelper.convertDateStructToString(this.filterModel.toDate);
    }

    get dateFromToFileName(): string {
        return this.dateFromToTitle.replace(/ /g, '_');
    }

    get productName(): string {
        const selectedOptions = this.filterModel.productOptions.filter(option => option.value === this.filterModel.product);
        return selectedOptions[0].text;
    }

    get productFileName(): string {
        return this.productName.replace(/ /g, '_');
    }

    get dateFromToTitle(): string {
        const fromDateString = DateHelper.formatDateStruct(this.filterModel.fromDate, DateFormat.Date);
        const toDateString = DateHelper.formatDateStruct(this.filterModel.toDate, DateFormat.Date);
        return `From ${fromDateString} To ${toDateString}`;
    }
}
