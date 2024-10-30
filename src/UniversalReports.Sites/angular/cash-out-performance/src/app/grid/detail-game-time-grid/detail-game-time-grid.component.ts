import { Component, OnInit } from '@angular/core';
import { Grid } from '../grid.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-detail-game-time-grid',
  templateUrl: './detail-game-time-grid.component.html',
  styleUrls: ['./detail-game-time-grid.component.scss']
})
export class DetailGameTimeGridComponent implements Grid {

  constructor() { }

  title: string;

  query(): Observable<any> {
    throw new Error('Method not implemented.');
  }
  
  exportExcel(): void {
    throw new Error('Method not implemented.');
  }
}
