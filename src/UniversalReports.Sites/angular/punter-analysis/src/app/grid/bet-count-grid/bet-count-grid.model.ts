import { NgbDateStruct } from 'nap-components/src/date';
import { PeriodType } from '../../filter/filter.model';

export interface BetCountGridModel {
    custId: number,
    sportId?: number,
    betTypeId?: number,
    liveStatusId?: number
}

export interface BetCountItem {
    Date: Date;
    WinLoss: number;
    BetCount: number;
    WinCount: number;
    DrawCount: number;
}

export interface BetCountData {
    Entities: BetCountItem[];
    Total: BetCountItem;
}
