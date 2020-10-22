import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class FilterService {
  constructor(
    private httpService: HttpService
  ) { }

  getMoveBetsDay(): Observable<string> {
    return this.httpService.post('api/voiding-settled-tickets/move-bet-date');
  }
}
