import { Component, OnInit } from '@angular/core';
import { Grid } from '../grid.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-game-time-grid',
  templateUrl: './game-time-grid.component.html',
  styleUrls: ['./game-time-grid.component.scss']
})
export class GameTimeGridComponent implements Grid {

  constructor() { }

  title: string;

  query(): Observable<any> {
    throw new Error('Method not implemented.');
  }

  exportExcel(): void {
    throw new Error('Method not implemented.');
  }
}
