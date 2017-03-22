import { Component } from '@angular/core';
import { ViewModelItem, BetTypeItem, ProductHasLeague } from './bet-type-grid.model'

@Component({
    selector: 'nap-bet-type-grid',
    templateUrl: './bet-type-grid.component.html',
    styleUrls: [
        './bet-type-grid.component.scss',
        '../grid.scss'
    ]
})
export class BetTypeGridComponent {
    private viewModelItem: ViewModelItem;
    private productId: number;

    constructor() {
        this.viewModelItem = this.createFakeData();
        this.productId = 1;
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

    private createFakeData(): ViewModelItem {

        let entities: BetTypeItem[] = [];
        for (var i = 0; i < 100; i++) {
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

            entities.push(betTypeItem);
        }

        return {
            Entities: entities,
            Total: {
                BetTypeId: 0,
                BetTypeName: "",

                NonLiveWinLoss: -13281.321356,
                NonLiveTurnover: 10321324.235323,
                NonLiveMargin: 0.0341232,
                NonLiveBetCount: 1321310,

                LiveWinLoss: -13281.321356,
                LiveTurnover: 10321324.235323,
                LiveMargin: 0.0341232,
                LiveBetCount: 1321310,

                WinLoss: -13281.321356,
                Turnover: 10321324.235323,
                Margin: 0.0341232,
                BetCount: 1321310 + i,
            }
        };
    }
}