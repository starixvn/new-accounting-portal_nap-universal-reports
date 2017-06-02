import { Component, Input } from '@angular/core';
import { DateHelper } from 'nap-components/src/date';
import { NumberFormat, NumberHelper } from 'nap-components/src/number';
import { FilterModel } from '../../filter/filter.model';
import { FilterModelWrapper, PeriodType } from '../../filter/filter.model.main';
import { Performance } from '../performance.model';
import { PerformanceService } from '../performance.service';
import { ProductPerformanceService } from './product-performance.service';
import { SportsbookStatistic } from './product-performance.model';
import { SummaryPerformanceComponent } from '../summary-performance/summary-performance.component';
import { RomanFormatter } from '../common/roman-formatter';

const sportsLimit = 5;

@Component({
    selector: 'nap-product-performance',
    templateUrl: './product-performance.component.html'
})
export class ProductPerformanceComponent implements Performance {
    statistic: SportsbookStatistic;
    sportLabels: string[];
    betCountBySportLabels: string[];
    betCountBySportData: number[];
    betCountBySportOptions: any;
    eventTypeLabels: string[];
    betCountByEventTypeData: number[];
    betCountByEventTypeOptions: any;
    winLossDatasets: any[];
    winLossOptions: any;
    turnoverLabels: string[];
    turnoverData: number[];
    turnoverOptions: any;
    private winLossRomanFormatter: RomanFormatter;

    constructor(
        private service: ProductPerformanceService,
        private performanceService: PerformanceService
    ) {
        this.betCountBySportOptions = {
            title: {
                display: true,
                text: 'BET COUNT BY SPORT'
            },
            tooltips: {
                callbacks: {
                    label: function (tooltipItem, data) {
                        const value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                        return NumberHelper.format(value, NumberFormat.Integer);
                    }
                }
            }
        };
        this.betCountByEventTypeOptions = {
            title: {
                display: true,
                text: 'BET COUNT BY EVENT TYPE'
            },
            tooltips: {
                callbacks: {
                    label: function (tooltipItem, data) {
                        const value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                        return NumberHelper.format(value, NumberFormat.Integer);
                    }
                }
            }
        };
        this.winLossOptions = {
            title: {
                display: true,
                text: 'WINLOSS BY SPORT'
            },
            legend: {
                display: false
            },
            tooltips: {
                callbacks: {
                    label: function (tooltipItem) {
                        return NumberHelper.format(tooltipItem.yLabel, NumberFormat.Decimal);
                    }
                }
            },
            scales: {
                xAxes: [{
                    barPercentage: 0.5
                }],
                yAxes: [{
                    afterBuildTicks: (scale) => {
                        this.winLossRomanFormatter = new RomanFormatter(scale.ticks);
                    },
                    ticks: {
                        suggestedMin: 0,
                        suggestedMax: 0,
                        callback: (value) => {
                            return this.winLossRomanFormatter.format(value);
                        }
                    }
                }]
            }
        };
        this.turnoverOptions = {
            title: {
                display: true,
                text: 'TURNOVER BY SPORT'
            },
            tooltips: {
                callbacks: {
                    label: function (tooltipItem, data) {
                        const value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                        return NumberHelper.format(value, NumberFormat.Decimal);
                    }
                }
            }
        };
    }

    get title(): string {
        const filterModel = this.performanceService.filterModel;
        const userName = filterModel.performance.userName;
        const dateString = FilterModelWrapper.getDateFromToString(PeriodType.MonthRange, filterModel.fromDate, filterModel.toDate);
        return `Punter ${userName}'s Performance ${dateString} - Detail from Sportsbook`;
    }

    query() {
        this.service.query().subscribe(statistic => {
            this.statistic = statistic;
            const sportStatistics = this.statistic.SportStatistics;
            this.sportLabels = sportStatistics.map(item => item.SportName);
            this.generateBetCountBySports();
            const summaryPerformanceStatistic = this.performanceService.summaryPerformanceStatistic;
            this.eventTypeLabels = summaryPerformanceStatistic.EventStatistics.map(item => item.EventType);
            this.betCountByEventTypeData = summaryPerformanceStatistic.EventStatistics.map(item => item.BetCount);
            this.winLossDatasets = [{
                data: sportStatistics.map(item => item.WinLoss),
                label: 'Winloss'
            }];
            this.generateTurnoverBySports();
        });
    }

    private generateBetCountBySports() {
        const sportStatistics = this.statistic.SportStatistics;
        const orderList = sportStatistics.sort((a, b) => {
            if (a.BetCount > b.BetCount) {
                return -1;
            } else if (a.BetCount === b.BetCount) {
                return 0;
            }
            return 1;
        });
        const trimList = orderList.slice(0, sportsLimit);
        this.betCountBySportLabels = trimList.map(item => item.SportName);
        this.betCountBySportData = trimList.map(item => item.BetCount);
        if (orderList.length > sportsLimit) {
            this.betCountBySportLabels.push('Others');
            let betCount = 0;
            for (let i = sportsLimit; i < orderList.length; i++) {
                betCount += orderList[i].BetCount;
            }
            this.betCountBySportData.push(betCount);
        }
    }

    private generateTurnoverBySports() {
        const sportStatistics = this.statistic.SportStatistics;
        const orderList = sportStatistics.sort((a, b) => {
            if (a.Turnover > b.Turnover) {
                return -1;
            } else if (a.Turnover === b.Turnover) {
                return 0;
            }
            return 1;
        });
        const trimList = orderList.slice(0, sportsLimit);
        this.turnoverLabels = trimList.map(item => item.SportName);
        this.turnoverData = trimList.map(item => item.Turnover);
        if (orderList.length > sportsLimit) {
            this.turnoverLabels.push('Others');
            let turnover = 0;
            for (let i = sportsLimit; i < orderList.length; i++) {
                turnover += orderList[i].Turnover;
            }
            this.turnoverData.push(turnover);
        }
    }
}
