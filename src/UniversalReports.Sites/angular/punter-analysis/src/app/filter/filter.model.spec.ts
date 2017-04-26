import * as _ from 'lodash';
import { FilterModel, UserFilterModel, LeagueFilterModel, SearchBy, OrderBy, PeriodType } from './filter.model';
import { RoleId, SortBy } from 'nap-components/src/model';
import { TreeviewItem } from 'ngx-treeview';

const commonModel = {
    searchByOptions: [
        { text: 'User', value: SearchBy.User },
        { text: 'League', value: SearchBy.League },
        { text: 'Performance', value: SearchBy.Performance }
    ]
};

const commonUserLeagueModel = _.extend(commonModel, {
    topRow: 2,
    orderBy: OrderBy.WinLoss,
    orderByOptions: [
        { text: 'WinLoss', value: OrderBy.WinLoss }
    ],
    sortBy: SortBy.Ascending,
    sortByOptions: [
        { text: 'Ascending', value: SortBy.Ascending }
    ],
    periodType: PeriodType.Daily,
    fromDate: { year: 2016, month: 1, day: 1 },
    toDate: { year: 2016, month: 2, day: 2 },
    selectedBetTypeTreeviewItems: [
        {
            item: new TreeviewItem({ text: 'BetType1', value: 1 }),
            parent: { item: new TreeviewItem({ text: 'SportType1', value: 1 }), parent: null }
        },
        {
            item: new TreeviewItem({ text: 'BetType2', value: 2 }),
            parent: { item: new TreeviewItem({ text: 'SportType2', value: 1 }), parent: null }
        }
    ]
});

const commonUserPerformanceModel = {
    depth: { role: RoleId.Agent, text: 'Agent' },
    userName: 'ABC',
    isUserNameRequired: true
};

export let fakeUserFilterModel: UserFilterModel = _.extend({}, _.extend({}, commonUserLeagueModel, commonUserPerformanceModel), {
    searchBy: SearchBy.User
});

export let fakeLeagueFilterModel: LeagueFilterModel = _.extend(commonUserLeagueModel, {
    searchBy: SearchBy.League,
    leagueId: 1,
    leagueOptions: [
        { text: 'League1', value: 1 }
    ],
    sportType: 1,
    sportOptions: [
        { text: 'SportType1', value: 1 }
    ]
});
