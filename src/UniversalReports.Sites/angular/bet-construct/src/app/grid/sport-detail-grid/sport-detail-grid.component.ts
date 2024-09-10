import { Component } from '@angular/core';
import { Grid } from '../grid.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-sport-detail-grid',
  templateUrl: './sport-detail-grid.component.html',
  styleUrls: ['./sport-detail-grid.component.scss']
})
export class SportDetailGridComponent implements Grid {

  constructor() { }

  title: string = '';
  
  query(): Observable<any> {
    throw new Error('Method not implemented.');
  }
  exportExcel(): void {
    throw new Error('Method not implemented.');
  }
}
