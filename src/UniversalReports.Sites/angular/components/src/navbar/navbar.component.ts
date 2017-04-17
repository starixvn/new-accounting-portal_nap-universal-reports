import { Component, OnInit } from '@angular/core';
import { NavbarService } from './navbar.service';
import { Menu } from './navbar.model';
import { LegacyService } from '../legacy.service';

@Component({
    selector: 'nap-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.scss'],
    providers: [
        NavbarService
    ]
})
export class NavbarComponent implements OnInit {
    menus: Menu[];
    username: string;

    constructor(
        private navbarService: NavbarService,
        private legacyService: LegacyService
    ) { }

    ngOnInit() {
        this.navbarService.query().subscribe(navbar => {
            this.menus = this.navbarService.compileMenus(navbar.Menus);
            this.username = navbar.Username || 'user';
        });
    }

    resolveLegacyUrl(url: string): string {
        return this.legacyService.resolveUrl(url);
    }
}
