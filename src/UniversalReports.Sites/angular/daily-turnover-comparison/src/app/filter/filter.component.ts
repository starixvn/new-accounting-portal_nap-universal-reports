import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  topLicenseeValue: number = 50;

  @Output() exported = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  onExportClick() {
    this.exported.emit(this.topLicenseeValue);
  }
}
