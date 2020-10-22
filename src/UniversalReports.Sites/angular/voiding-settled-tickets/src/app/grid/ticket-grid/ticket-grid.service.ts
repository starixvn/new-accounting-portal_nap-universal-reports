import { Injectable } from '@angular/core';
import { VoidTicketModel } from './ticket-grid.model';
import { HttpService } from 'nap-components/http';
import { GridService } from '../grid.service';
import { Helper } from 'nap-components/helper';
import * as moment from 'moment';

@Injectable()
export class TicketGridService {
  constructor(
      private readonly httpService: HttpService,
      private readonly gridService: GridService) { }

  public query() {
    const queryModel = this.createQueryModel();
    return this.httpService.post<VoidTicketModel>('api/voiding-settled-tickets/tickets-by-product', queryModel);
  }

  private createQueryModel() {
    const filterModel = this.gridService.filterModel;
    const keyId = this.gridService.keyId;
    filterModel.productGroupID = keyId;
    filterModel.productName = this.gridService.productName;
    return filterModel;
  }

  exportExcel() {
    const queryModel = this.gridService.filterModel;
    const winlostDate = moment(queryModel.winlostDate).format('YYYY_MM_DD');
    this.httpService.download('api/voiding-settled-tickets/tickets-by-product-excel', queryModel).subscribe(response => {
        const fileName = `Voiding_Settled_Tickets_Report_${this.gridService.productName}_For_${winlostDate}.xlsx`;
        Helper.downloadFile(response, fileName);
    });
}
}
