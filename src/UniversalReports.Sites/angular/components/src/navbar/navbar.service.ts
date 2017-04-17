import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { HttpService } from '../http.service';
import { LegacyService } from '../legacy.service';
import { Navbar, Menu } from './navbar.model';

@Injectable()
export class NavbarService {
    constructor(
        private httpService: HttpService,
        private legacyService: LegacyService
    ) { }

    query() {
        const url = 'api/application/header';
        return this.httpService.post<Navbar>(url, {});
    }

    compileMenus(menus: Menu[]): Menu[] {
        menus.forEach(menu => {
            menu.HasChildren = menu.Children !== null && menu.Children.length > 0;
            menu.Link = this.legacyService.resolveUrl(menu.Link);
            if (menu.HasChildren) {
                menu.Children.forEach(childMenu => {
                    childMenu.HasChildren = false;
                    childMenu.Link = this.legacyService.resolveUrl(childMenu.Link);
                });
            }
        });

        return menus;
    }
}
