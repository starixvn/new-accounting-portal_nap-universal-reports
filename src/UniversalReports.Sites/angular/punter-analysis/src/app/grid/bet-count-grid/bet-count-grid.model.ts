import { NgbDateStruct } from 'nap-components/src/date';
import { PeriodType } from '../../filter/filter.model.main';
import { LiveStatus, GridType } from '../grid.model';

export interface BetCountGridModel {
    custId: number;
    custName: string;
    fromGridType: GridType;
    sportId?: number;
    sportName?: string;
    betTypeId?: number;
    betTypeName?: string;
    liveStatusId?: LiveStatus;
}

export interface BetCountItem {
    Date: string;
    WinLoss: number;
    BetCount: number;
    WinCount: number;
    DrawCount: number;
}

export interface BetCountData {
    Entities: BetCountItem[];
    Total: BetCountItem;
}
