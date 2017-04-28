import { Component, Input } from '@angular/core';
import * as _ from 'lodash';
import { DateHelper } from 'nap-components/src/date';
import { FilterModel } from '../../filter/filter.model';
import { FilterModelWrapper, PeriodType } from '../../filter/filter.model.main';
import { Performance, PerformanceType } from '../performance.model';
import { PerformanceService } from '../performance.service';
import { SummaryPerformanceService } from './summary-performance.service';
import { PerformanceStatistic } from './summary-performance.model';

@Component({
    selector: 'nap-summary-performance',
    templateUrl: './summary-performance.component.html',
    styleUrls: [
        '../../../../node_modules/nap-components/src/style/table.scss',
        '../shared/performance-container.scss'
    ]
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
            }
        };
        this.betCountOptions = {
            title: {
                display: true,
                text: 'BET COUNT BY MONTH'
            }
        };
        this.winLossTurnoverOptions = {
            title: {
                display: true,
                text: 'WINLOSS/TURNOVER'
            },
            scales: {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false
                    },
                    labels: {
                        show: true
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
                    labels: {
                        show: true
                    }
                }, {
                    type: 'linear',
                    display: true,
                    position: 'right',
                    id: 'y-axis-2',
                    gridLines: {
                        display: false
                    },
                    labels: {
                        show: true
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
        this.service.query().subscribe(statistic => {
            this.statistic = statistic;
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
                backgroundColor: '#71B37C',
                borderColor: '#71B37C',
                hoverBackgroundColor: '#71B37C',
                hoverBorderColor: '#71B37C',
                yAxisID: 'y-axis-1'
            }, {
                type: 'line',
                label: 'Win loss',
                data: monthStatistics.map(item => item.WinLoss),
                fill: false,
                borderColor: '#EC932F',
                backgroundColor: '#EC932F',
                pointBorderColor: '#EC932F',
                pointBackgroundColor: '#EC932F',
                pointHoverBackgroundColor: '#EC932F',
                pointHoverBorderColor: '#EC932F',
                yAxisID: 'y-axis-2'
            }];

            const productTurnoverStatistics = this.statistic.ProductTurnoverStatistics;
            this.productLabels = productTurnoverStatistics.map(item => item.ProductName);
            this.productData = productTurnoverStatistics.map(item => item.Turnover);
        });
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
