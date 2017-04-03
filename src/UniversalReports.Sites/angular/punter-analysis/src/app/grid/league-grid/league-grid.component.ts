import { Component } from '@angular/core';
import * as _ from 'lodash';
import { Grid } from '../grid.model';
import { LeagueItem, PeriodGroupItem, LeagueData } from './league-grid.model';
import { LeagueGridService } from './league-grid.service';

@Component({
    selector: 'nap-league-grid',
    templateUrl: './league-grid.component.html'
})
export class LeagueGridComponent implements Grid {
    private data: LeagueData;

    constructor(
        private service: LeagueGridService
    ) {
        this.data = this.createFakeData();
    }

    query() {
    }

    exportExcel() {

    }

    get hasExcel(): boolean {
        return !_.isNil(this.data) && this.data.Entities.length > 0;
    }

    get title(): string {
        return 'Main - Punter Analysis';
    }

    private createFakeData(): LeagueData {

        var leagues: LeagueItem[] = [];
        for (var i = 0; i < 100; i++) {
            var league = this.createLeagueItem();
            leagues.push(league);
        }

        return {
            Entities: leagues,
            Total: this.createLeagueItem(),
            GroupNames: ["A", "B", "C", "D"]
        };
    }

    private createLeagueItem(): LeagueItem {

        let groups: PeriodGroupItem[] = this.createPeriods();
        let league: LeagueItem = {
            LeagueName: "League 1",
            PeriodGroups: groups
        };

        return league;
    }

    private createPeriods(): PeriodGroupItem[] {
        let periodGroups: PeriodGroupItem[] = [];
        for (var i = 0; i < 4; i++) {
            let periodGroup: PeriodGroupItem = {
                WinLoss: 100,
                Turnover: 200,
                Margin: 0.5,
                BetCount: 2
            }

            periodGroups.push(periodGroup);
        }

        return periodGroups;
    }
}
