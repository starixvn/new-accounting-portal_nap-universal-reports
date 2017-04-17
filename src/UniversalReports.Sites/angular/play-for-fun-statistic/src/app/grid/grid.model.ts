export enum GridType {
    Summary,
    Detail
}

export interface Grid {
    hasData: boolean;
    title: string;
    query(): void;
    exportExcel(): void;
}
