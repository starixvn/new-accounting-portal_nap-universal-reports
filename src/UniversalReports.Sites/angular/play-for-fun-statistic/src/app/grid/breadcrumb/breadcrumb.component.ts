import { Component, Input, OnChanges } from '@angular/core';
import { GridService } from '../grid.service';
import { Grid } from '../grid.model';

@Component({
    selector: 'nap-breadcrumb',
    templateUrl: './breadcrumb.component.html',
    styleUrls: ['./breadcrumb.component.scss']
})
export class BreadcrumbComponent implements OnChanges {
    @Input() items: string[];
    isShowFilter = false;

    constructor(
        private gridService: GridService
    ) { }

    ngOnChanges() {
        this.isShowFilter = false;
    }

    get hasData(): boolean {
        return this.gridService.activeGrid.hasData;
    }

    exportExcel() {
        this.gridService.activeGrid.exportExcel();
    }

    goBack(index: number) {
        this.gridService.goBack(index);
    }
}
