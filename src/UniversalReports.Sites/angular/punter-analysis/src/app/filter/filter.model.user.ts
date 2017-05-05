import * as _ from 'lodash';
import { DownlineTreeviewItem } from 'ngx-treeview';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { RoleId, SortBy } from 'nap-components/src/model';
import { NgbDateStruct, DateFormat, DateHelper } from 'nap-components/src/date';
import { CommonUserLeagueFilterModel } from './filter.model.common-user-league';
import { PerformanceFilterModel } from './filter.model.performance';

export interface UserFilterModel extends CommonUserLeagueFilterModel, PerformanceFilterModel { }
