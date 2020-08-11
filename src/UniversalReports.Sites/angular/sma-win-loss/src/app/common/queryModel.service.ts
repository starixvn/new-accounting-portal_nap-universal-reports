import { FilterModel } from "../filter/filter.model";
import { QueryModel } from "./model";
import { Injectable } from "@angular/core";

@Injectable()
export class QueryModelService {
  createQueryModel(filterModel: FilterModel ): QueryModel {
    const queryModel: QueryModel = {
      year: filterModel.year,
      custLevel: filterModel.custLevel,
      username: filterModel.username,
      isDownline: filterModel.isDownline,
      currencies: filterModel.currencies,
      isAppliedVR: filterModel.isAppliedVR === 1,
      sports: filterModel.sports,
      leagueIds: filterModel.leagueIds,
      divisions: filterModel.divisions,
      pageIndex: filterModel.pageIndex,
      pageSize: filterModel.pageSize,
      isGenerated: filterModel.isGenerated
    };

    return queryModel;
  }
}
