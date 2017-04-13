import { Component, Input, OnChanges } from '@angular/core';
import { TreeviewItem } from 'ng2-dropdown-treeview';
import { BreadcrumbFilter } from '../breadcrumb/breadcrumb.model';
import { GridService } from '../grid.service';
import { Grid } from '../grid.model';

function hasFilter(grid: any): grid is BreadcrumbFilter {
    return (grid as BreadcrumbFilter).getColumnFilter !== undefined;
}

@Component({
    selector: 'nap-breadcrumb',
    templateUrl: './breadcrumb.component.html',
    styleUrls: ['./breadcrumb.component.scss']
})
export class BreadcrumbComponent implements OnChanges {
    @Input() items: string[];
    filterItems: TreeviewItem[];
    isShowFilter = false;

    constructor(
        private gridService: GridService
    ) { }

    ngOnChanges() {
        this.isShowFilter = false;
        this.filterItems = undefined;
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

    get hasFilter(): boolean {
        const activeGrid = this.gridService.activeGrid;
        return hasFilter(activeGrid);
    }

    toggleFilter() {
        this.isShowFilter = !this.isShowFilter;
        const activeGrid = this.gridService.activeGrid;
        if (hasFilter(activeGrid)) {
            if (!this.filterItems) {
                this.filterItems = activeGrid.getColumnFilter();
            }
        }
    }

    onFilterSelectedChange(groupNames: string[]) {
        const activeGrid = this.gridService.activeGrid;
        if (hasFilter(activeGrid)) {
            activeGrid.filterColumns(groupNames);
        }
    }
}
