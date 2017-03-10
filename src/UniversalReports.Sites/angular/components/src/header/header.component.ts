import { Component, OnInit } from '@angular/core';
import { HeaderService } from './header.service';
import { Menu } from './header.model';

@Component({
    selector: 'nap-header',
    templateUrl: './header.component.html',
    styleUrls: [
        './header.component.scss'
    ],
    providers: [
        HeaderService
    ]
})
export class HeaderComponent implements OnInit {
    menus: Menu[];
    username: string;

    constructor(
        private headerService: HeaderService
    ) {
    }

    ngOnInit() {
        this.headerService.query().subscribe(header => {
            this.menus = this.headerService.compileMenus(header.Menus);
            this.username = header.Username || 'sa';
        });
    }
}
