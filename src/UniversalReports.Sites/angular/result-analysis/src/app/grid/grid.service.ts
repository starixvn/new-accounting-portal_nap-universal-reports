import { Injectable } from '@angular/core';
import { HttpService } from 'nap-components/http';
import { Observable } from 'rxjs';
import { ResultAnalysisModel } from './grid.model';
import { FilterModel } from '../filter/filter.model';
import { CommonConstants } from '../common/constants';
import { Helper } from 'nap-components/helper';

@Injectable({
  providedIn: 'root'
})
export class GridService {

  constructor(private readonly httpService: HttpService) { }

  getData(filter: FilterModel): Observable<ResultAnalysisModel> {
    return this.httpService.post<ResultAnalysisModel>(`${CommonConstants.API}/result-analysis`, filter);
  }

  exportExcel(filterModel: FilterModel): void {
    this.httpService.download(`${CommonConstants.API}/export-excel`, filterModel).subscribe(response => {
      const fileName = `Result_Analysis_Report_From_${filterModel.fromDate}_To_${filterModel.toDate}.xlsx`;
      Helper.downloadFile(response, fileName);
    });
  }
}
