import { Directive, HostListener, Input, ElementRef } from '@angular/core';
import { NgbInputDatepicker, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';

@Directive({
    selector: '[napDatePickerToggle]'
})
export class DatePickerToggleDirective {
    @Input() ngbInputDatepicker: NgbInputDatepicker;

    constructor(
        private elementRef: ElementRef
    ) { }

    @HostListener('click', ['$event']) onClick(event: MouseEvent) {
        const targetElement = event.target as HTMLElement;
        if (this.isDayElement(targetElement)) {
            return;
        }

        if (!this.ngbInputDatepicker.isOpen()) {
            this.ngbInputDatepicker.open();
            event.stopPropagation();
        } else {
            const element = this.elementRef.nativeElement as HTMLElement;
            const ngbDatePickerElement = element.children[1];
            if (ngbDatePickerElement.contains(targetElement)) {
                event.stopPropagation();
            }
        }
        /*const element = event.target as HTMLElement;
        const dayElement = element.parentElement;
        if (!dayElement.classList.contains('ngb-dp-day')) {
            this.ngbInputDatepicker.toggle();
            //this.ngbInputDatepicker.
        }*/
    }

    @HostListener('document:click', ['$event']) onDocumentClick(event: MouseEvent) {
        this.ngbInputDatepicker.close();
    }

    private isDayElement(targetElement: HTMLElement): boolean {
        const dayElement = targetElement.parentElement;
        return dayElement.classList.contains('ngb-dp-day');
    }
}
