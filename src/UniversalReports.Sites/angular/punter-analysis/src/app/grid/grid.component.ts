import { Component, Input, OnChanges } from '@angular/core';
import { FilterModel } from '../filter/filter.model';
import { GridService } from './grid.service';
import { SummaryData } from './summary-grid/summary-grid.model';

@Component({
    selector: 'nap-grid',
    templateUrl: './grid.component.html',
    styleUrls: ['./grid.component.scss'],
    providers: [
        GridService
    ]
})
export class GridComponent implements OnChanges {
    @Input() filterModel: FilterModel;
    summaryData: SummaryData;
    breadcrumbItems: string[] = ['Main', 'Library'];

    constructor(private service: GridService) { }

    ngOnChanges() {
        if (this.filterModel) {
            this.service.querySummary(this.filterModel).subscribe(data => this.summaryData = data);
        }
    }

    onExportExcel() {
        alert('Export excel');
    }
}
