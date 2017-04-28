import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { TypeaheadQuery } from 'nap-components/src/dropdown-typeahead';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { NgbDateStruct, NgbDate, DateHelper, DateFormat } from 'nap-components/src/date';
import { FilterModel } from './filter.model';
import { Status } from './filter.model.status';
import { FilterService } from './filter.service';

@Component({
    selector: 'nap-filter',
    templateUrl: './filter.component.html',
    styleUrls: [
        '../../../node_modules/nap-components/src/style/filter.scss',
        './filter.component.scss'
    ],
    providers: [
        FilterService
    ]
})
export class FilterComponent implements OnInit {
    @Output() generate = new EventEmitter<FilterModel>();
    @Output() reset = new EventEmitter();
    minDateNote: string;
    minDate: NgbDateStruct;
    maxDate: NgbDateStruct;
    fromDate: NgbDateStruct;
    toDate: NgbDateStruct;
    productOptions: SelectItem[];
    product: number;
    status = Status.All;
    statusOptions = this.getStatusOptions();
    userName = '';
    userNameTypeaheadQuery = this.buildUserNameTypeaheadQuery();
    isExcludeTest = true;

    constructor(
        private service: FilterService
    ) {
        const todayNgbDate = NgbDate.fromToday();
        this.minDate = { year: todayNgbDate.year, month: todayNgbDate.month - 1, day: todayNgbDate.day };
        this.maxDate = todayNgbDate.toDateStruct();
        this.fromDate = todayNgbDate.toDateStruct();
        this.toDate = todayNgbDate.toDateStruct();
        this.minDateNote = DateHelper.formatDateStruct(this.minDate, DateFormat.Date);
    }

    ngOnInit() {
        this.service.queryProductOptions().subscribe(productOptions => {
            this.productOptions = productOptions;
            this.product = this.productOptions[0].value;
        });
    }

    onGenerate() {
        this.reset.emit();
        const model = this.createModel();
        this.generate.emit(model);
    }

    private buildUserNameTypeaheadQuery(): TypeaheadQuery {
        return new TypeaheadQuery(term => {
            return this.service.queryUserNameSuggestion(term);
        });
    }

    private createModel(): FilterModel {
        return {
            fromDate: this.fromDate,
            toDate: this.toDate,
            product: this.product,
            productOptions: this.productOptions,
            status: this.status,
            userName: this.userName,
            isExcludeTest: this.isExcludeTest
        };
    }

    private getStatusOptions(): SelectItem[] {
        return [{
            text: 'All',
            value: Status.All
        }, {
            text: 'Enabled',
            value: Status.Enabled
        }, {
            text: 'Disabled',
            value: Status.Disabled
        }];
    }
}
