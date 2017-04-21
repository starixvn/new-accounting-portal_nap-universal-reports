import { DetailData } from './detail-grid.model';

export const fakeData: DetailData = {
    Entities: [
        {
            Date: '2017-04-02T00:00:00',
            GroupHeadline: 'SUPERTESTTE010500',
            Site: 'BEST-ODDS',
            Currency: 'UUS',
            Super: 'Super1',
            Username: 'SUPERTESTTE010500001',
            CustId: 23534245,
            Product: 'RNG Casino',
            Status: 1,
            MemberRequest: true,
            WinLoss: -402.0000,
            Turnover: 500.0000,
            BetCount: 5
        }, {
            Date: '2017-04-02T00:00:00',
            GroupHeadline: 'SUPERTESTTE010502',
            Site: 'BEST-ODDS',
            Currency: 'UUS',
            Super: null,
            Username: 'SUPERTESTTE010501002',
            CustId: 24144943,
            Product: 'RNG Casino',
            Status: 0,
            MemberRequest: false,
            WinLoss: -9549.0000,
            Turnover: 9650.0000,
            BetCount: 1111
        }
    ],
    Total: {
        Date: null,
        GroupHeadline: null,
        Site: null,
        Currency: null,
        Super: null,
        Username: null,
        CustId: null,
        Product: null,
        Status: null,
        MemberRequest: false,
        WinLoss: -9753.0000,
        Turnover: 10650.0000,
        BetCount: 1371
    }
};
