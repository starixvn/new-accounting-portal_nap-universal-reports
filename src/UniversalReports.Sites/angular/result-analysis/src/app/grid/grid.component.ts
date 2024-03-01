import { Component, Input, OnInit } from '@angular/core';
import { FilterModel } from '../filter/filter.model';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit {
  @Input() filterModel!: FilterModel;

  constructor() { }

  ngOnInit(): void {
  }

  exportExcel(): void {
    
  }

}
