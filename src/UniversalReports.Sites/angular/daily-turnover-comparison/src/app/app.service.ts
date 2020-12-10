import { HttpService } from 'nap-components/http';
import { Helper } from 'nap-components/helper';
import { Injectable } from '@angular/core';

@Injectable()
export class AppService {
  constructor(private httpService: HttpService) { }

  exportExcel(topLicensees: number) {
    const url = 'api/daily-turnover-comparison/top-licensees';
    this.httpService.download(url, topLicensees).subscribe(response => {
      const fileName = `Daily_Turnover_Comparision_Report.xlsx`;
      Helper.downloadFile(response, fileName);
    });
  }
}
