import { Directive, HostListener, Input, ElementRef } from '@angular/core';
import { NgbInputDatepicker, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';

@Directive({
    selector: '[napDatePickerToggle]',
    exportAs: 'napDatePickerToggle'
})
export class DatePickerToggleDirective {
    private ngbInputDatepicker: NgbInputDatepicker;
    private mouseEvent: MouseEvent;

    constructor(
        private elementRef: ElementRef
    ) { }

    @HostListener('document:click', ['$event']) onDocumentClick(event: MouseEvent) {
        if (this.mouseEvent !== event) {
            if (this.ngbInputDatepicker) {
                this.ngbInputDatepicker.close();
            }
        }
    }

    @HostListener('click', ['$event']) onclick(event: MouseEvent) {
        this.mouseEvent = event;
    }

    toggle(ngbInputDatepicker: NgbInputDatepicker, event: MouseEvent) {
        this.mouseEvent = event;
        this.ngbInputDatepicker = ngbInputDatepicker;
        this.ngbInputDatepicker.toggle();
    }
}
