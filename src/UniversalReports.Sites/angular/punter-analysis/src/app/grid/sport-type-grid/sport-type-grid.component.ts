import { Component } from '@angular/core';
import { ViewModelItem, SportTypeItem } from './sport-type-grid.model'

@Component({
    selector: 'nap-sport-type-grid',
    templateUrl: './sport-type-grid.component.html'
})
export class SportTypeGridComponent {
    private viewModelItem: ViewModelItem;

    constructor() {
        this.viewModelItem = this.createFakeData();
    }

    private onShowBetType(sportId: number) {
        alert(sportId);
    }

    private onShowBetCount(sportId: number): void {
        alert(sportId);
    }

    private createFakeData():ViewModelItem{
        let entities :SportTypeItem[]=[];
        
        for (var i = 0; i < 5; i++) {
            let sportTypeItem: SportTypeItem = {
                SportId:  i,
                SportName: "Sport "+ i,
                WinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                Turnover: i % 5 == 0 ? 0 : 10321324.235323 + i,
                Margin: (i % 2 == 0) ? 0.0341232 : 0.1341554,
                BetCount: 1321310 + i
            };
            
            entities.push(sportTypeItem);
        }

        return {
            Entities: entities,
            Total: {
                SportId:  0,
                SportName: "",
                WinLoss: i % 5 == 0 ? -13281.321356 + i : 13281.321356 + i,
                Turnover: i % 5 == 0 ? 0 : 10321324.235323 + i,
                Margin: (i % 2 == 0) ? 0.0341232 : 0.1341554,
                BetCount: 1321310 + i
            }
        };
    }
}
