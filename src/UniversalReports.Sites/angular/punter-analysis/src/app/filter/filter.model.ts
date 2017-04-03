import * as _ from 'lodash';
import { DownlineTreeviewItem } from 'ng2-dropdown-treeview';
import { RoleId, SortBy } from 'nap-components/src/model';
import { NgbDateStruct, DateHelper } from 'nap-components/src/date';

export enum SearchBy {
    User,
    League,
    Performance
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
}

export class FilterModelWrapper {
    constructor(
        private filterModel: FilterModel
    ) { }

    get depthTitle(): string {
        switch (this.filterModel.depth) {
            case RoleId.Member:
                return 'Member';
            case RoleId.Agent:
                return 'Agent';
        }
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
        switch (this.filterModel.orderBy) {
            case OrderBy.Margin:
                return 'Margin';
            case OrderBy.Turnover:
                return 'Turnover';
            case OrderBy.WinLoss:
                return 'Win Loss';
        }
    }

    get sortByTitle(): string {
        switch (this.filterModel.sortBy) {
            case SortBy.Ascending:
                return 'Ascending';
            case SortBy.Descending:
                return 'Descending';
        }
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

    get dateTitle(): string {
        const momentFromDate = DateHelper.convertDateStructToMoment(this.filterModel.fromDate);
        const momentToDate = DateHelper.convertDateStructToMoment(this.filterModel.toDate);
        const dateFormat = 'MMM DD, YYYY';
        const fromDateString = momentFromDate.format(dateFormat);
        const toDateString = momentToDate.format(dateFormat);
        return `from ${fromDateString} to ${toDateString} ${this.periodTitle}`;
    }

    get dateFileName(): string {
        const momentFromDate = DateHelper.convertDateStructToMoment(this.filterModel.fromDate);
        const momentToDate = DateHelper.convertDateStructToMoment(this.filterModel.toDate);
        const dateFormat = 'MMM_DD_YYYY';
        const fromDateString = momentFromDate.format(dateFormat);
        const toDateString = momentToDate.format(dateFormat);
        return `From_${fromDateString}_To_${toDateString}`;
    }

    get searchByTitle(): string {
        switch (this.filterModel.searchBy) {
            case SearchBy.League:
                return 'League';
            case SearchBy.Performance:
                return 'Performance';
            case SearchBy.User:
                return 'User';
        }
    }

    get searchByFileName(): string {
        return `Search_by_${this.searchByTitle}`;
    }
}
