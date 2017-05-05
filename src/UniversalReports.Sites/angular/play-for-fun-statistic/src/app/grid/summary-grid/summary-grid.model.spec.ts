import { SummaryData } from './summary-grid.model';

export const fakeData: SummaryData = {
    Entities: [{
        Date: '2017-04-01T00:00:00',
        PlayerCount: 1,
        WinLoss: 0.0000,
        Turnover: 300.0000,
        BetCount: 3
    }, {
        Date: '2017-04-02T00:00:00',
        PlayerCount: 4,
        WinLoss: -9753.0000,
        Turnover: 10650.0000,
        BetCount: 1371
    }],
    Total: {
        Date: undefined,
        PlayerCount: 70,
        WinLoss: 2229.0000,
        Turnover: 25450.0000,
        BetCount: 4751
    }
};
