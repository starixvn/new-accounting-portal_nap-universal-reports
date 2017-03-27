import { Component, Input } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import * as _ from 'lodash';
import { LegendService } from './legend.service';
import { LegendModalComponent } from './legend-modal.component';

@Component({
    selector: 'nap-legend',
    templateUrl: './legend.component.html',
    styleUrls: ['./legend.component.scss'],
    providers: [
        LegendService
    ]
})
export class LegendComponent {
    private body: SafeHtml;
    @Input() menuName: string;
    @Input() menuTitle: string;

    constructor(
        private sanitized: DomSanitizer,
        private modalService: NgbModal,
        private legendService: LegendService
    ) {
    }

    show() {
        const modalRef = this.modalService.open(LegendModalComponent);
        const instance = modalRef.componentInstance as LegendModalComponent;
        instance.title = this.menuTitle;
        if (!_.isNil(this.body)) {
            instance.body = this.body;
        } else {
            this.legendService.query(this.menuName).subscribe(body => {
                this.body = this.sanitized.bypassSecurityTrustHtml(body);
                instance.body = this.body;
            });
        }
    }
}
