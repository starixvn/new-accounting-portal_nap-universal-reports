import { IOption } from 'nap-components/src/select';
import { SelectItem } from 'nap-components/src/dropdown-select';
import { CommonUserLeagueFilterModel } from './filter.model.common-user-league';

export interface LeagueFilterModel extends CommonUserLeagueFilterModel {
    leagueId: number;
    leagueOptions: IOption[];
    sportType: number;
    sportOptions: IOption[];
}
