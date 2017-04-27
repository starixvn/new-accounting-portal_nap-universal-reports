import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import * as _ from 'lodash';

import { PerformanceService } from './performance.service';
import { BetCount } from './performance.model';

@Component({
    selector: 'nap-performance',
    templateUrl: './performance.component.html',
    styleUrls: ['./performance.component.scss'],
})
export class PerformanceComponent implements OnInit, OnChanges {
    @Input() filterModel: FilterModel;
    pieChartLabels: string[];
    pieChartData: number[];

    constructor(
        private service: PerformanceService
    ) { }

    ngOnInit() {

    }

    ngOnChanges(changes: SimpleChanges) {
        this.service.query(this.filterModel).subscribe(betCounts => {
            this.pieChartLabels = betCounts.map(b => b.Month.toDateString());
            this.pieChartData = betCounts.map(b => b.BetCount);
            console.log('okkkkkkkkkkkkkk');
        });
    }

    public chartClicked(e: any): void {
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }
}
