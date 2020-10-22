export enum GridType {
    Product,
    Ticket
}

export interface Grid {
    hasExcel: boolean;
    title: string;
    query(): void;
    exportExcel(): void;
}
