import { Component } from '@angular/core';
import { SportTypeItem } from './sport-type-grid.model'

@Component({
    selector: 'nap-sport-type-grid',
    templateUrl: './sport-type-grid.component.html',
    styleUrls: [
        './sport-type-grid.component.scss',
        '../grid.scss'
    ]
})
export class SportTypeGridComponent {
    private sportTypeItems: SportTypeItem[];
    private rowCount: number;

    constructor() {
        this.sportTypeItems = [];
        this.rowCount = 5;
        
        for (var i = 0; i < this.rowCount; i++) {
            let sportTypeItem: SportTypeItem = {
                SportId:  i,
                SportName: "Sport "+ i,
                WinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                Turnover: i % 5 == 0 ? 0 : 10321324.235323 + i,
                Margin: (i % 2 == 0) ? 0.0341232 : 0.1341554,
                BetCount: 1321310 + i,
            };
            this.sportTypeItems.push(sportTypeItem);
        }
    }

    private onShowBetType(sportId: number) {
        alert(sportId);
    }

    private onShowBetCount(sportId: number): void {
        alert(sportId);
    }
}