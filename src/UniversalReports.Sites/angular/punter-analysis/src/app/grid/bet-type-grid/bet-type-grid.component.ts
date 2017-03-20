import { Component } from '@angular/core';
import { BetTypeItem, ProductHasLeague } from './bet-type-grid.model'

@Component({
    selector: 'nap-bet-type-grid',
    templateUrl: './bet-type-grid.component.html',
    styleUrls: [
        './bet-type-grid.component.scss',
        '../grid.scss'
    ]
})
export class BetTypeGridComponent {
    private betTypeItems: BetTypeItem[];
    private rowCount: number;
    private productId: number;

    constructor() {
        this.betTypeItems = [];
        this.rowCount = 5;
        this.productId = 1;

        for (var i = 0; i < this.rowCount; i++) {
            let betTypeItem: BetTypeItem = {
                BetTypeId: i,
                BetTypeName: "Bet " + i,

                NonLiveWinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                NonLiveTurnover: i % 5 == 0 ? 0 : 10321324.235323 + i,
                NonLiveMargin: (i % 2 == 0) ? 0.0341232 : 0.1341554,
                NonLiveBetCount: 1321310 + i,

                LiveWinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                LiveTurnover: i % 5 == 0 ? 0 : 10321324.235323 + i,
                LiveMargin: (i % 2 == 0) ? 0.0341232 : 0.1341554,
                LiveBetCount: 1321310 + i,

                WinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                Turnover: i % 5 == 0 ? 0 : 10321324.235323 + i,
                Margin: (i % 2 == 0) ? 0.0341232 : 0.1341554,
                BetCount: 1321310 + i,
            };
            this.betTypeItems.push(betTypeItem);
        }
    }

    private onShowLeagueNonLive(betTypeId: number) {
        alert(betTypeId);
    }

    private onShowLeagueLive(betTypeId: number) {
        alert(betTypeId);
    }
    
    private onShowLeague(betTypeId: number) {
        alert(betTypeId);
    }

    private onShowBetCount(betTypeId: number): void {
        alert(betTypeId);
    }

    private onShowBetCountNonLive(betTypeId: number): void {
        alert(betTypeId);
    }

    private onShowBetCountLive(betTypeId: number): void {
        alert(betTypeId);
    }

    private isLeagueAvailable(): boolean {
        return this.productId === ProductHasLeague.SPORTSBOOK
            || this.productId === ProductHasLeague.NUMBER_GAME
            || this.productId === ProductHasLeague.RACING
            || this.productId === ProductHasLeague.VIRTUAL_SPORTS
            || this.productId === ProductHasLeague.LIVE_CASINO;
    }
}