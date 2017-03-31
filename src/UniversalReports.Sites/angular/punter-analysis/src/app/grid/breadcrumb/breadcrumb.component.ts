import { Component, Input } from '@angular/core';
import { GridService } from '../grid.service';

@Component({
    selector: 'nap-breadcrumb',
    templateUrl: './breadcrumb.component.html',
    styleUrls: ['./breadcrumb.component.scss']
})
export class BreadcrumbComponent {
    @Input() items: string[];

    constructor(
        private gridService: GridService
    ) { }

    onExportExcel(index: number) {
        this.gridService.activeGrid.excel();
    }
}
