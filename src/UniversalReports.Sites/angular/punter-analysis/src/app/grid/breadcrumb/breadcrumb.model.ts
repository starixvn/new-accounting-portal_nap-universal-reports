import { TreeviewItem } from 'ngx-treeview';

export interface BreadcrumbFilter {
    getColumnFilter(): TreeviewItem[];
    filterColumns(groupNames: string[]);
}
