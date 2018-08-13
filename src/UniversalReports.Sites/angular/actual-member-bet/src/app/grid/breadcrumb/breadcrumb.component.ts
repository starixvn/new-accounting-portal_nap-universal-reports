import { Component, Input, OnChanges } from '@angular/core';
import { GridService } from '../grid.service';

@Component({
  selector: 'app-breadcrumb',
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

  get hasExcel(): boolean {
      return this.gridService.activeGrid.hasExcel;
  }

  exportExcel() {
      this.gridService.activeGrid.exportExcel();
  }

  goBack(index: number) {
      this.gridService.goBack(index);
  }
}
