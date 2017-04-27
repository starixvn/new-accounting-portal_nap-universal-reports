import { FilterModel } from './filter.model';
import { Status } from './filter.model.status';

export const fakeFilterModel: FilterModel = {
    fromDate: { year: 2017, month: 4, day: 1 },
    toDate: { year: 2017, month: 4, day: 19 },
    product: 1,
    productOptions: [
        { text: 'Product 1', value: 1 },
        { text: 'Product 2', value: 2 },
    ],
    status: Status.All,
    userName: 'ABC',
    isExcludeTest: true
};
