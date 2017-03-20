import { Component } from '@angular/core';
import { LeagueItem, PeriodGroupItem, ReportItem } from './league-grid.model'

@Component({
    selector: 'nap-league-grid',
    templateUrl: './league-grid.component.html',
    styleUrls: [
        './league-grid.component.scss',
        '../grid.scss'
    ]
})
export class LeagueGridComponent {
    private reportItem: ReportItem;
    private rowCount: number;
    private groupCount: number;

    constructor() {
        this.rowCount = 100;
        this.groupCount = 4;
        this.reportItem = this.createReportItem();
        console.log(this.reportItem.Total.PeriodGroups);
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

    private createLeagueItem(): LeagueItem {

        let groups: PeriodGroupItem[] = this.createPeriods();
        let league: LeagueItem = {
            LeagueName: "League 1",
            PeriodGroups: groups
        };

        return league;
    }

    private createReportItem(): ReportItem {

        var leagues: LeagueItem[] = [];
        for (var i = 0; i < this.rowCount; i++) {
            var league = this.createLeagueItem();
            leagues.push(league);
        }

        return {
            Entities: leagues,
            Total: this.createLeagueItem(),
            GroupNames: ["A", "B", "C", "D"]
        };
    }
}