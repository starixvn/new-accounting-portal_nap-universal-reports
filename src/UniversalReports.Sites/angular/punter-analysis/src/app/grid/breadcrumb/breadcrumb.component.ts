import { Component, Input } from '@angular/core';

@Component({
    selector: 'nap-breadcrumb',
    templateUrl: './breadcrumb.component.html',
    styleUrls: ['./breadcrumb.component.scss']
})
export class BreadcrumbComponent {
    @Input() items: string[];

    onClick(index: number) {

    }
}
