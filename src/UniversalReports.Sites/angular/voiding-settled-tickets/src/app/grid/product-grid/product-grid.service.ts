import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { ProductData } from './product-grid.model';
import { HttpService } from 'nap-components/http';
import { GridService } from '../grid.service';
import { Observable } from 'rxjs/Observable';
import { Helper } from 'nap-components/helper';

@Injectable()
export class ProductGridService {
    constructor(
        private httpService: HttpService,
        private gridService: GridService
    ) { }

    query(): Observable<ProductData> {
        const queryModel = this.gridService.filterModel;
        return this.httpService.post<ProductData>('api/voiding-settled-tickets/products', queryModel);
    }

    exportExcel() {
        const queryModel = this.gridService.filterModel;
        const winlostDate = moment(queryModel.winlostDate).format('YYYY_MM_DD');
        this.httpService.download('api/voiding-settled-tickets/products-excel', queryModel).subscribe(response => {
            const fileName = `Voiding_Settled_Tickets_Report_For_${winlostDate}.xlsx`;
            Helper.downloadFile(response, fileName);
        });
    }
}
