import * as moment from 'moment';

export interface Licensee {
    LicenseeId: number;
    LicenseeName: string;
  }

  export interface Sport {
    SportType: number;
    SportName: string;
  }

  export interface FilterModel {
      fromDate: string;
      toDate: string;
      licenseeId: string;
      sportType: string;
  }

  export enum TimePeriod {
    Today,
    Yesterday,
    CurrentWeek,
    LastWeek,
    CurrentMonth,
    LastMonth,
    SinceLastMonth,
    SpecificDate,
    LastThreeMonths
}

