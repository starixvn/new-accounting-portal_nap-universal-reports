import { NgbDateStruct, DateHelper, DateFormat } from 'nap-components/src/date';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { FilterModel } from './filter.model';

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
        return this.dateFromToTitle.replace(/ /g, '_').replace(/,/g, '');
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
