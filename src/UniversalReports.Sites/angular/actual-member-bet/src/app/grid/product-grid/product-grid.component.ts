import { Component, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { Grid, GridType } from '../grid.model';
import { ProductData } from './product-grid.model';
import { GridService } from '../grid.service';
import { ProductGridService } from './product-grid.service';

@Component({
  selector: 'app-product-grid',
  templateUrl: './product-grid.component.html',
  styleUrls: ['./product-grid.component.scss']
})
export class ProductGridComponent implements Grid {

  productData: ProductData;

  constructor(
        private gridService: GridService,
        private productGridService: ProductGridService,
    ) { }

    query() {
        this.productGridService.query().subscribe(data => this.productData = data);
    }

    exportExcel() {
        this.productGridService.exportExcel();
    }

    get hasExcel(): boolean {
        return this.hasData;
    }

    get hasData(): boolean {
        return !_.isNil(this.productData) && this.productData.Entities.length > 0;
    }

    get title(): string {
        const filterModel = this.gridService.filterModel;
        return `Main`;
    }

    showBettype(keyId: string, productName: string) {
        this.gridService.keyId = keyId;
        this.gridService.productName = productName;
        this.gridService.generate(GridType.Bettype);
    }

}
