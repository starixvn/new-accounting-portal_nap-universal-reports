import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'nap-legend-content',
    templateUrl: './legend-modal.component.html',
    styleUrls: ['./legend-modal.component.scss']
})
export class LegendModalComponent {
    @Input() title;
    @Input() body;

    constructor(public activeModal: NgbActiveModal) { }
}
