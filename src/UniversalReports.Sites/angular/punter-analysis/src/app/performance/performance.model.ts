interface BetCountStatistic {
    BetCount: number;
    Turnover: number;
    WinLoss: number;
}

interface BetTypeStatistic extends BetCountStatistic {
    BetTypeName: string;
}

interface EventStatistic {
    EventType: string;
}

interface MonthStatistic extends BetCountStatistic {
    Date: string;
}

interface ProductTurnoverStatistic {
    ProductName: string;
    Turnover: number;
}

interface SportStatistic extends BetCountStatistic {
    SportName: string;
}

export interface PerformanceStatistic {
    BetTypeStatistics: BetTypeStatistic[];
    EventStatistics: EventStatistic[];
    MonthStatistics: MonthStatistic[];
    ProductTurnoverStatistics: ProductTurnoverStatistic[];
    SportStatistics: SportStatistic[];
    SummaryStatistic: BetCountStatistic;
}
