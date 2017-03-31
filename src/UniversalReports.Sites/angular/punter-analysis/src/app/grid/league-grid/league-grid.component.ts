import { Component } from '@angular/core';
import { Grid } from '../grid.model';
import { LeagueItem, PeriodGroupItem, ViewModelItem } from './league-grid.model';
import { LeagueGridService } from './league-grid.service';

@Component({
    selector: 'nap-league-grid',
    templateUrl: './league-grid.component.html'
})
export class LeagueGridComponent implements Grid {
    private viewModelItem: ViewModelItem;

    constructor(
        private service: LeagueGridService
    ) {
        this.viewModelItem = this.createFakeData();
    }

    query() {
    }

    excel() {

    }

    get hasExcel(): boolean {
        return true;
    }

    get title(): string {
        return 'Main - Punter Analysis';
    }

    private createFakeData(): ViewModelItem {

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
