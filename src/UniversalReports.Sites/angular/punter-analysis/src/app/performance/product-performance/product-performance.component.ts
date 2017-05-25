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

@Component({
    selector: 'nap-product-performance',
    templateUrl: './product-performance.component.html'
})
export class ProductPerformanceComponent implements Performance {
    statistic: SportsbookStatistic;
    sportLabels: string[];
    betCountBySportData: number[];
    betCountBySportOptions: any;
    eventTypeLabels: string[];
    betCountByEventTypeData: number[];
    betCountByEventTypeOptions: any;
    winLossDatasets: any[];
    winLossOptions: any;
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
            this.betCountBySportData = sportStatistics.map(item => item.BetCount);
            const summaryPerformanceStatistic = this.performanceService.summaryPerformanceStatistic;
            this.eventTypeLabels = summaryPerformanceStatistic.EventStatistics.map(item => item.EventType);
            this.betCountByEventTypeData = summaryPerformanceStatistic.EventStatistics.map(item => item.BetCount);
            this.winLossDatasets = [{
                data: sportStatistics.map(item => item.WinLoss),
                label: 'Winloss'
            }];
            this.turnoverData = sportStatistics.map(item => item.Turnover);
        });
    }
}
