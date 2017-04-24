import {
    Component, Input, OnInit, OnChanges, ComponentFactoryResolver, Injector, ViewContainerRef,
    ComponentRef, ViewChild, SimpleChanges, OnDestroy, ComponentFactory, Renderer
} from '@angular/core';
import * as _ from 'lodash';

import { PerformanceService } from './performance.service';
import { BetCount } from './performance.model';

@Component({
    selector: 'nap-performance',
    templateUrl: './performance.component.html',
    styleUrls: ['./performance.component.scss'],
})
export class PerformanceComponent implements OnInit, OnChanges, OnDestroy {

    constructor(
        private service: PerformanceService
    ) { }

    public pieChartLabels: string[];
    public pieChartData: number[];

    ngOnInit() {
        this.service.query().subscribe(betCounts => {
            this.pieChartLabels = betCounts.map(b => b.Month.toDateString());
            this.pieChartData = betCounts.map(b => b.BetCount);
            console.log("okkkkkkkkkkkkkk");
        });
    }

    ngOnChanges(changes: SimpleChanges) {
    }

    ngOnDestroy() {
    }

    private generate() {

    }

}
