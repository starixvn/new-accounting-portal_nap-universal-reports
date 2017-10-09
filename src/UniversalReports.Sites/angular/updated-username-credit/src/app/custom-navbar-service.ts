import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { HttpService } from 'nap-components/http';
import { NavbarService, UserMenu, Navbar } from 'nap-components/navbar';

@Injectable()
export class CustomNavbarService extends NavbarService {
    url = 'state-api/application/header';
    userMenus: UserMenu[] = [];

    constructor(
        private customHttpService: HttpService
    ) {
        super(customHttpService);
    }

    query(): Observable<Navbar> {
        const url = 'state-api/application/header';
        return this.customHttpService.post<Navbar>(url).map(data => {
            const legacyNavbar = data as any;
            this.userMenus = [
                {
                    name: 'Change Password',
                    link: legacyNavbar.legacyPath + '/UserControl/User/ChangePassword'
                },
                {
                    name: 'Sign Out',
                    link: legacyNavbar.legacyPath + '/UserLogin/Login/LogOut'
                }
            ];
            return data;
        });
    }
}
