import { Component } from '@angular/core';
import { LeagueItem, PeriodGroupItem, ViewModelItem } from './league-grid.model'

@Component({
    selector: 'nap-league-grid',
    templateUrl: './league-grid.component.html'
})
export class LeagueGridComponent {
    private viewModelItem: ViewModelItem;

    constructor() {
        this.viewModelItem = this.createFakeData();
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