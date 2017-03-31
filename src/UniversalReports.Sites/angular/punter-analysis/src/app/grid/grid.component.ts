import {
    Component, Input, OnInit, OnChanges, ComponentFactoryResolver, Injector, ViewContainerRef,
    ComponentRef, ElementRef, ViewChild, SimpleChanges, OnDestroy, ApplicationRef, ComponentFactory
} from '@angular/core';
import { Subscription } from 'rxjs';
import * as _ from 'lodash';
import { FilterModel } from '../filter/filter.model';
import { GridService } from './grid.service';
import { Grid, GridType } from './grid.model';
import { SummaryGridComponent } from './summary-grid/summary-grid.component';
import { BetCountGridComponent } from './bet-count-grid/bet-count-grid.component';
import { AssociatedAccountGridComponent } from './associated-account-grid/associated-account-grid.component';
import { SportTypeGridComponent } from './sport-type-grid/sport-type-grid.component';
import { BetTypeGridComponent } from './bet-type-grid/bet-type-grid.component';
import { LeagueGridComponent } from './league-grid/league-grid.component';

@Component({
    selector: 'nap-grid',
    templateUrl: './grid.component.html',
    styleUrls: ['./grid.component.scss'],
    entryComponents: [
        SummaryGridComponent,
        BetCountGridComponent,
        AssociatedAccountGridComponent,
        SportTypeGridComponent,
        BetTypeGridComponent,
        LeagueGridComponent
    ]
})
export class GridComponent implements OnInit, OnChanges, OnDestroy {
    static subcription: Subscription = null;
    @Input() filterModel: FilterModel;
    @ViewChild('container', { read: ViewContainerRef }) container: ViewContainerRef;
    GridType = GridType;
    gridType = GridType.UserName;
    breadcrumbItems: string[] = ['Main', 'Library'];
    private component: ComponentRef<Grid>;

    constructor(
        private applicationRef: ApplicationRef,
        private componentFactoryResolver: ComponentFactoryResolver,
        private injector: Injector,
        private service: GridService
    ) { }

    ngOnInit() {
        if (GridComponent.subcription) {
            GridComponent.subcription.unsubscribe();
            GridComponent.subcription = null;
        }

        GridComponent.subcription = this.service.show.subscribe(gridType => {
            this.gridType = gridType;
            this.createGrid();
        });
    }

    ngOnChanges(changes: SimpleChanges) {
        this.gridType = GridType.UserName;
        this.service.filterModel = this.filterModel;
        this.createGrid();
    }

    ngOnDestroy() {
        this.removeGrid();
    }

    private removeGrid() {
        if (!_.isNil(this.component)) {
            this.container.clear();
            this.component.destroy();
            this.component = null;
        }
    }

    private createGrid() {
        this.removeGrid();

        let factory: ComponentFactory<Grid>;
        switch (this.gridType) {
            case GridType.UserName:
                factory = this.componentFactoryResolver.resolveComponentFactory(SummaryGridComponent);
                break;
            case GridType.BetCount:
                factory = this.componentFactoryResolver.resolveComponentFactory(BetCountGridComponent);
                break;
            case GridType.AssociatedAccount:
                factory = this.componentFactoryResolver.resolveComponentFactory(AssociatedAccountGridComponent);
                break;
            case GridType.SportType:
                factory = this.componentFactoryResolver.resolveComponentFactory(SportTypeGridComponent);
                break;
            case GridType.BetType:
                factory = this.componentFactoryResolver.resolveComponentFactory(BetTypeGridComponent);
                break;
            case GridType.League:
                factory = this.componentFactoryResolver.resolveComponentFactory(LeagueGridComponent);
                break;
        }

        if (factory) {
            this.component = this.container.createComponent(factory);
            const grid = this.component.instance;
            grid.query();
            this.service.activeGrid = grid;
        }
    }
}
