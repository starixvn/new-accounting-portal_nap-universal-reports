import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { DateHelper } from 'nap-components/src/date';
import { FilterModel } from '../filter/filter.model';
import * as _ from 'lodash';
import { PerformanceService } from './performance.service';
import { PerformanceStatistic } from './performance.model';

@Component({
    selector: 'nap-performance',
    templateUrl: './performance.component.html',
    styleUrls: [
        '../../../node_modules/nap-components/src/style/table.scss',
        './performance.component.scss'
    ]
})
export class PerformanceComponent implements OnChanges {
    @Input() filterModel: FilterModel;
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
        private service: PerformanceService
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
                text: 'TURNOVER BY PRODUCT'
            }
        };
    }

    ngOnChanges(changes: SimpleChanges) {
        this.statistic = undefined;
        this.service.query(this.filterModel).subscribe(statistic => {
            this.statistic = statistic;
            this.hasData = this.statistic.MonthStatistics.length !== 0;

            const monthStatistics = this.statistic.MonthStatistics;
            this.monthLabels = monthStatistics.map(item => {
                const date = DateHelper.convertStringToDate(item.Date);
                const dateStruct = DateHelper.convertDateToDateStruct(date);
                return `${dateStruct.month}/${dateStruct.year}`;
            });
            this.marginData = [{
                data: monthStatistics.map(item => item.WinLoss * 100 / item.Turnover),
                label: 'Margin (%)'
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
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }
}
