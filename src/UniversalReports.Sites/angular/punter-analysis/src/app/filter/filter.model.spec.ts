import { FilterModel, SearchBy, OrderBy, PeriodType } from './filter.model';
import { RoleId, SortBy } from 'nap-components/src/model';
import { TreeviewItem } from 'ng2-dropdown-treeview';

export let fakeFilterModel: FilterModel = {
    searchBy: SearchBy.User,
    topRow: 2,
    orderBy: OrderBy.WinLoss,
    sortBy: SortBy.Ascending,
    periodType: PeriodType.Daily,
    fromDate: { year: 2016, month: 1, day: 1 },
    toDate: { year: 2016, month: 2, day: 2 },
    depth: RoleId.Agent,
    userName: 'ABC',
    selectedBetTypeTreeviewItems: [
        {
            item: new TreeviewItem({ text: 'BetType1', value: 1 }),
            parent: { item: new TreeviewItem({ text: 'SportType1', value: 1 }), parent: null }
        },
        {
            item: new TreeviewItem({ text: 'BetType2', value: 2 }),
            parent: { item: new TreeviewItem({ text: 'SportType2', value: 1 }), parent: null }
        }
    ],
    searchByOptions: [
        { text: 'User', value: SearchBy.User }
    ],
    depthOptions: [
        { text: 'Agent', value: RoleId.Agent }
    ],
    orderByOptions: [
        { text: 'WinLoss', value: OrderBy.WinLoss }
    ],
    sortByOptions: [
        { text: 'Ascending', value: SortBy.Ascending }
    ]
};
