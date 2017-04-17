import * as _ from 'lodash';
import { DownlineTreeviewItem } from 'ng2-dropdown-treeview';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { RoleId, SortBy } from 'nap-components/src/model';
import { NgbDateStruct, DateHelper } from 'nap-components/src/date';

export enum SearchBy {
    User = 1,
    League = 2,
    Performance = 3
}

export enum PeriodType {
    Daily = 1,
    Weekly = 2,
    Monthly = 3,
    Annually = 4,
    MonthRange = 5
}

export enum OrderBy {
    WinLoss = 1,
    Turnover = 2,
    Margin = 3
}

export interface FilterModel {
    searchBy: SearchBy;
    topRow: number;
    orderBy: OrderBy;
    sortBy: SortBy;
    periodType: PeriodType;
    fromDate: NgbDateStruct;
    toDate: NgbDateStruct;
    depth: RoleId;
    userName: string;
    selectedBetTypeTreeviewItems: DownlineTreeviewItem[];
    searchByOptions: SelectItem[];
    depthOptions: SelectItem[];
    orderByOptions: SelectItem[];
    sortByOptions: SelectItem[];
}

export class FilterModelWrapper {
    constructor(
        private filterModel: FilterModel
    ) { }

    get depthTitle(): string {
        return this.filterModel.depthOptions.filter(option => option.value === this.filterModel.depth)[0].text;
    }

    get userNameTitle(): string {
        const userName = this.filterModel.userName;
        if (!_.isNil(userName) && userName !== '') {
            return userName;
        }

        return 'All';
    }

    get listCombinationId(): string {
        const values = this.filterModel.selectedBetTypeTreeviewItems.map(betTypeItem => betTypeItem.item.value);
        return values.join(',');
    }

    get fromDateQueryString(): string {
        return DateHelper.convertDateStructToString(this.filterModel.fromDate);
    }

    get toDateQueryString(): string {
        return DateHelper.convertDateStructToString(this.filterModel.toDate);
    }

    get selectedSportTypes(): string {
        const sportTypes: string[] = [];
        this.filterModel.selectedBetTypeTreeviewItems.forEach(betTypeItem => {
            const sportType = betTypeItem.parent.item.text;
            if (sportTypes.indexOf(sportType) === -1) {
                sportTypes.push(sportType);
            }
        });
        return sportTypes.join(', ');
    }

    get orderByTitle(): string {
        return this.filterModel.orderByOptions.filter(option => option.value === this.filterModel.orderBy)[0].text;
    }

    get sortByTitle(): string {
        return this.filterModel.sortByOptions.filter(option => option.value === this.filterModel.sortBy)[0].text;
    }

    get periodTitle(): string {
        switch (this.filterModel.periodType) {
            case PeriodType.Daily:
                return 'Daily';
            case PeriodType.Weekly:
                return 'Weekly';
            case PeriodType.Monthly:
            case PeriodType.MonthRange:
                return 'Monthly';
            case PeriodType.Annually:
                return 'Annually';
        }
    }

    get dateFromToTitle(): string {
        const dateFromToDateString = this.getDateFromToString();
        return `${dateFromToDateString} (${this.periodTitle})`;
    }

    get dateFromToFileName(): string {
        let dateFromToDateString = this.getDateFromToString();
        dateFromToDateString = dateFromToDateString.replace(/ /g, '_').replace(/,/g, '');
        return dateFromToDateString;
    }

    get searchByTitle(): string {
        return this.filterModel.searchByOptions.filter(option => option.value === this.filterModel.searchBy)[0].text;
    }

    get searchByFileName(): string {
        return `Search_by_${this.searchByTitle}`;
    }

    private getDateFromToString(): string {
        const momentFromDate = DateHelper.convertDateStructToMoment(this.filterModel.fromDate);
        const momentToDate = DateHelper.convertDateStructToMoment(this.filterModel.toDate);
        switch (this.filterModel.periodType) {
            case PeriodType.Daily:
            case PeriodType.Weekly:
                const dateFormat = 'MMM DD, YYYY';
                const fromDateString = momentFromDate.format(dateFormat);
                const toDateString = momentToDate.format(dateFormat);
                return `from ${fromDateString} to ${toDateString}`;
            case PeriodType.Monthly:
                const monthDateString = momentFromDate.format('MMM YYYY');
                return `in ${monthDateString}`;
            case PeriodType.MonthRange:
                const monthFormat = 'MMM YYYY';
                const fromMonthDateString = momentFromDate.format(monthFormat);
                const toMonthDateString = momentToDate.format(monthFormat);
                return `from ${fromMonthDateString} to ${toMonthDateString}`;
            case PeriodType.Annually:
                const yearDateString = momentFromDate.format('YYYY');
                return `in ${yearDateString}`;
        }
    }
}
