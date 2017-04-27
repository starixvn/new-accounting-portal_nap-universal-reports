import * as _ from 'lodash';
import { DownlineTreeviewItem } from 'ngx-treeview';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { RoleId, SortBy } from 'nap-components/src/model';
import { NgbDateStruct, DateFormat, DateHelper } from 'nap-components/src/date';
import { SearchBy } from './filter.model.main'
import { UserFilterModel } from './filter.model.user';
import { LeagueFilterModel } from './filter.model.league';
import { PerformanceFilterModel } from './filter.model.performance';


export interface FilterModel {
    searchBy: SearchBy;
    searchByOptions: SelectItem[];
    fromDate: NgbDateStruct;
    toDate: NgbDateStruct;
    user?: UserFilterModel;
    league?: LeagueFilterModel;
    performance?: PerformanceFilterModel;
}
