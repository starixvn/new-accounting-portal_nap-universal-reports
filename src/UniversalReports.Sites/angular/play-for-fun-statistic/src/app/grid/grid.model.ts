export enum GridType {
    Summary,
    Detail
}

export interface Grid {
    hasExcel: boolean;
    title: string;
    query(): void;
    exportExcel(): void;
}
