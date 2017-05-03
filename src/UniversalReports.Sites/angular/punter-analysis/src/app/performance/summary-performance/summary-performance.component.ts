import { Component, Input } from '@angular/core';
import * as _ from 'lodash';
import { DateHelper } from 'nap-components/src/date';
import { NumberFormat, NumberHelper } from 'nap-components/src/number';
import { FilterModel } from '../../filter/filter.model';
import { FilterModelWrapper, PeriodType } from '../../filter/filter.model.main';
import { Performance, PerformanceType } from '../performance.model';
import { PerformanceService } from '../performance.service';
import { SummaryPerformanceService } from './summary-performance.service';
import { PerformanceStatistic } from './summary-performance.model';

@Component({
    selector: 'nap-summary-performance',
    templateUrl: './summary-performance.component.html'
})
export class SummaryPerformanceComponent implements Performance {
    statistic: PerformanceStatistic;
    hasData = false;
    monthLabels: string[];
    marginData: any[];
    marginOptions: any;
    betCountData: number[];
    betCountOptions: any;
    winLossTurnoverData: any[];
    winLossTurnoverOptions: any;
    productLabels: string[];
    productData: number[];
    productOptions: any;

    constructor(
        private service: SummaryPerformanceService,
        private performanceService: PerformanceService
    ) {
        this.marginOptions = {
            title: {
                display: true,
                text: 'MARGIN (%) BY MONTH'
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
            }
        };
        this.betCountOptions = {
            title: {
                display: true,
                text: 'BET COUNT BY MONTH'
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
        this.winLossTurnoverOptions = {
            title: {
                display: true,
                text: 'WINLOSS/TURNOVER'
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
                    display: true,
                    gridLines: {
                        display: false
                    }
                }],
                yAxes: [{
                    type: 'linear',
                    display: true,
                    position: 'left',
                    id: 'y-axis-1',
                    gridLines: {
                        display: false
                    },
                    ticks: {
                        fontColor: '#F28F43',
                        beginAtZero: true,
                        callback: function (value) {
                            return NumberHelper.format(value, NumberFormat.Decimal);
                        }
                    },
                    scaleLabel: {
                        display: true,
                        labelString: 'TURNOVER',
                        fontColor: '#F28F43'
                    }
                }, {
                    type: 'linear',
                    display: true,
                    position: 'right',
                    id: 'y-axis-2',
                    gridLines: {
                        display: false
                    },
                    ticks: {
                        fontColor: '#00A3C8',
                        beginAtZero: true,
                        callback: function (value) {
                            return NumberHelper.format(value, NumberFormat.Decimal);
                        }
                    },
                    scaleLabel: {
                        display: true,
                        labelString: 'WINLOSS',
                        fontColor: '#00A3C8'
                    }
                }]
            }, elements: {
                line: {
                    fill: false
                }
            }
        };
        this.productOptions = {
            title: {
                display: true,
                text: 'TURNOVER BY PRODUCT (Click on Sportsbook to view details)'
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
        if (this.performanceService.activePerformance === this) {
            const filterModel = this.performanceService.filterModel;
            const userName = filterModel.performance.userName;
            const dateString = FilterModelWrapper.getDateFromToString(PeriodType.MonthRange, filterModel.fromDate, filterModel.toDate);
            return `Punter ${userName} Performance ${dateString}`;
        } else {
            return 'Main';
        }
    }

    query() {
        this.statistic = this.performanceService.summaryPerformanceStatistic;
        this.hasData = this.statistic.MonthStatistics.length !== 0;

        const monthStatistics = this.statistic.MonthStatistics;
        this.monthLabels = monthStatistics.map(item => {
            const date = DateHelper.convertStringToDate(item.Date);
            const dateStruct = DateHelper.convertDateToDateStruct(date);
            return `${dateStruct.month}/${dateStruct.year}`;
        });
        this.marginData = [{
            data: monthStatistics.map(item => _.round(item.WinLoss * 100 / item.Turnover, 2)),
            label: 'Margin'
        }];
        this.betCountData = monthStatistics.map(item => item.BetCount);
        this.winLossTurnoverData = [{
            type: 'bar',
            label: 'Turnover',
            data: monthStatistics.map(item => item.Turnover),
            fill: false,
            yAxisID: 'y-axis-1'
        }, {
            type: 'line',
            label: 'Win loss',
            data: monthStatistics.map(item => item.WinLoss),
            fill: false,
            yAxisID: 'y-axis-2'
        }];
        const productTurnoverStatistics = this.statistic.ProductTurnoverStatistics;
        this.productLabels = productTurnoverStatistics.map(item => item.ProductName);
        this.productData = productTurnoverStatistics.map(item => item.Turnover);
    }

    public chartClicked(e: any): void {
        if (e.active.length > 0) {
            const chartElement = e.active[0];
            const activeIndex = chartElement._index;
            const productTurnoverStatistic = this.statistic.ProductTurnoverStatistics[activeIndex];
            if (productTurnoverStatistic.ProductName === 'Sportsbook') {
                this.performanceService.generate(PerformanceType.Product);
            }
        }
    }
}
