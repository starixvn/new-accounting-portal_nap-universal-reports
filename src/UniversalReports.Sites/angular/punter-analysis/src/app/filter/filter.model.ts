import * as _ from 'lodash';
import { DownlineTreeviewItem } from 'ngx-treeview';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { RoleId, SortBy } from 'nap-components/src/model';
import { NgbDateStruct, DateFormat, DateHelper } from 'nap-components/src/date';

export interface SportsbookSportTypeBetType {
    SportType: number;
    SportName: string;
    BetTypeName: string;
    CombinationId: number;
}

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

interface UserFilterModel {
    depth: RoleId;
    depthOptions: SelectItem[];
    userName: string;
}

interface LeagueFilterModel {
    leagueId: number;
    leagueOptions: SelectItem[];
    sportType: number;
    sportOptions: SelectItem[];
}

export interface FilterModel extends UserFilterModel, LeagueFilterModel {
    searchBy: SearchBy;
    searchByOptions: SelectItem[];
    topRow: number;
    orderBy: OrderBy;
    orderByOptions: SelectItem[];
    sortBy: SortBy;
    sortByOptions: SelectItem[];
    periodType: PeriodType;
    fromDate: NgbDateStruct;
    toDate: NgbDateStruct;
    selectedBetTypeTreeviewItems: DownlineTreeviewItem[];
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
        switch (this.filterModel.searchBy) {
            case SearchBy.User:
                const sportTypes: string[] = [];
                this.filterModel.selectedBetTypeTreeviewItems.forEach(betTypeItem => {
                    const sportType = betTypeItem.parent.item.text;
                    if (sportTypes.indexOf(sportType) === -1) {
                        sportTypes.push(sportType);
                    }
                });
                return sportTypes.join(', ');
            case SearchBy.League:
                return this.filterModel.sportOptions.filter(item => item.value === this.filterModel.sportType)[0].text;
        }
    }

    get leagueTitle(): string {
        return this.filterModel.leagueOptions.filter(option => option.value === this.filterModel.leagueId)[0].text;
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
        switch (this.filterModel.periodType) {
            case PeriodType.Daily:
            case PeriodType.Weekly:
                const fromDateString = DateHelper.formatDateStruct(this.filterModel.fromDate, DateFormat.Date);
                const toDateString = DateHelper.formatDateStruct(this.filterModel.toDate, DateFormat.Date);
                return `from ${fromDateString} to ${toDateString}`;
            case PeriodType.Monthly:
                const monthDateString = DateHelper.formatDateStruct(this.filterModel.fromDate, DateFormat.Month);
                return `in ${monthDateString}`;
            case PeriodType.MonthRange:
                const fromMonthDateString = DateHelper.formatDateStruct(this.filterModel.fromDate, DateFormat.Month);
                const toMonthDateString = DateHelper.formatDateStruct(this.filterModel.toDate, DateFormat.Month);
                return `from ${fromMonthDateString} to ${toMonthDateString}`;
            case PeriodType.Annually:
                const yearDateString = DateHelper.formatDateStruct(this.filterModel.fromDate, DateFormat.Year);
                return `in ${yearDateString}`;
        }

        return '';
    }
}
