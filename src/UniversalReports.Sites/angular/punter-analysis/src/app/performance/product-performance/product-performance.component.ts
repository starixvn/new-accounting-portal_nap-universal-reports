import { Component, Input } from '@angular/core';
import { DateHelper } from 'nap-components/src/date';
import { FilterModel } from '../../filter/filter.model';
import { FilterModelWrapper, PeriodType } from '../../filter/filter.model.main';
import { Performance } from '../performance.model';
import { PerformanceService } from '../performance.service';
import { ProductPerformanceService } from './product-performance.service';
import { SportsbookStatistic } from './product-performance.model';
import { SummaryPerformanceComponent } from '../summary-performance/summary-performance.component';

@Component({
    selector: 'nap-product-performance',
    templateUrl: './product-performance.component.html',
    styleUrls: [
        '../../../../node_modules/nap-components/src/style/table.scss',
        '../shared/performance-container.scss'
    ]
})
export class ProductPerformanceComponent implements Performance {
    statistic: SportsbookStatistic;
    hasData = false;
    sportLabels: string[];
    betCountBySportData: number[];
    betCountBySportOptions: any;
    eventTypeLabels: string[];
    betCountByEventTypeData: number[];
    betCountByEventTypeOptions: any;
    winLossData: any[];
    winLossOptions: any;
    turnoverData: number[];
    turnoverOptions: any;

    constructor(
        private service: ProductPerformanceService,
        private performanceService: PerformanceService
    ) {
        this.betCountBySportOptions = {
            title: {
                display: true,
                text: 'BET COUNT BY SPORT'
            }
        };
        this.betCountByEventTypeOptions = {
            title: {
                display: true,
                text: 'BET COUNT BY EVENT TYPE'
            }
        };
        this.winLossOptions = {
            title: {
                display: true,
                text: 'WINLOSS BY SPORT'
            }
        };
        this.turnoverOptions = {
            title: {
                display: true,
                text: 'TURNOVER BY SPORT'
            }
        };
    }

    get title(): string {
        const filterModel = this.performanceService.filterModel;
        const userName = filterModel.performance.userName;
        const dateString = FilterModelWrapper.getDateFromToString(PeriodType.MonthRange, filterModel.fromDate, filterModel.toDate);
        return `Punter ${userName} Performance ${dateString} - Detail from Sportsbook`;
    }

    query() {
        this.service.query().subscribe(statistic => {
            this.hasData = statistic.SportStatistics.length !== 0;
            const summaryPerformanceComponent = this.performanceService.performances[0] as SummaryPerformanceComponent;
            statistic.BetTypeStatistics = summaryPerformanceComponent.statistic.BetTypeStatistics;
            statistic.EventStatistics = summaryPerformanceComponent.statistic.EventStatistics;

            this.statistic = statistic;
            const sportStatistics = this.statistic.SportStatistics;
            this.sportLabels = sportStatistics.map(item => item.SportName);
            this.betCountBySportData = sportStatistics.map(item => item.BetCount);
            this.eventTypeLabels = this.statistic.EventStatistics.map(item => item.EventType);
            this.betCountByEventTypeData = this.statistic.EventStatistics.map(item => item.BetCount);
            this.winLossData = [{
                data: sportStatistics.map(item => item.WinLoss),
                label: 'Winloss'
            }];
            this.turnoverData = sportStatistics.map(item => item.Turnover);
        });
    }
}
