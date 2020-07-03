import { FilterModel } from "../filter/filter.model";
import { QueryModel } from "./model";
import { Injectable } from "@angular/core";

@Injectable()
export class QueryModelService {
  createQueryModel(
    filterModel: FilterModel,
    isShowSite: boolean,
    isShowSport: boolean,
    isShowLeague: boolean,
    isShowCust: boolean,
  ): QueryModel {
    const margin = (isShowSite || isShowSport) ? filterModel.margin : 0;
    const queryModel: QueryModel = {
      fromDate: filterModel.fromDate,
      toDate: filterModel.toDate,
      timeRange: filterModel.timeRange,
      isShowSite,
      isShowSport,
      isShowLeague,
      isShowCust,
      margin,
      top: filterModel.topRows,
      isShowFullColumn: filterModel.isShowFullColumn
    };

    return queryModel;
  }
}
