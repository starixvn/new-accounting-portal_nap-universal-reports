export interface Menu {
    Id: number;
    Name: string;
    Link: string;
    HasChildren: boolean;
    Children: Menu[];
}

export interface Navbar {
    LegacyPath: string;
    Username: string;
    Menus: Menu[];
}
