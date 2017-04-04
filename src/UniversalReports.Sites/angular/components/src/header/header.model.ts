export interface Menu {
    Id: number;
    Name: string;
    Link: string;
    HasChildren: boolean;
    Children: Menu[];
}

export interface Header {
    Username: string;
    Menus: Menu[];
}
