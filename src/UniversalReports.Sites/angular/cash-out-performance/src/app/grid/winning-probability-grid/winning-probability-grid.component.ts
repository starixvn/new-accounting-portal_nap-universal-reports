import { Component, OnInit } from '@angular/core';
import { Grid } from '../grid.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-winning-probability-grid',
  templateUrl: './winning-probability-grid.component.html',
  styleUrls: ['./winning-probability-grid.component.scss']
})
export class WinningProbabilityGridComponent implements Grid {

  constructor() { }

  title: string;

  query(): Observable<any> {
    throw new Error('Method not implemented.');
  }
  
  exportExcel(): void {
    throw new Error('Method not implemented.');
  }
}
