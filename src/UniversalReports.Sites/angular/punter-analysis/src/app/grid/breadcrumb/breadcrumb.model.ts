import { TreeviewItem } from 'ng2-dropdown-treeview';

export interface BreadcrumbFilter {
    getColumnFilter(): TreeviewItem[];
    filterColumns(groupNames: string[]);
}
