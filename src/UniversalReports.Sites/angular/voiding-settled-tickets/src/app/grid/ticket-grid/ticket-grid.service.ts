import { Injectable } from '@angular/core';
import { VoidTicketModel } from './ticket-grid.model';
import { HttpService } from 'nap-components/http';
import { GridService } from '../grid.service';

@Injectable()
export class TicketGridService {
  private url = 'api/voiding-settled-tickets/tickets-by-product';
  constructor(
      private readonly httpService: HttpService,
      private readonly gridService: GridService) { }

  public query() {
    const queryModel = this.createQueryModel();
    return this.httpService.post<VoidTicketModel>(this.url, queryModel);
  }

  private createQueryModel() {
    const filterModel = this.gridService.filterModel;
    const keyId = this.gridService.keyId;
    filterModel.productGroupID = keyId;
    return filterModel;
  }
}
