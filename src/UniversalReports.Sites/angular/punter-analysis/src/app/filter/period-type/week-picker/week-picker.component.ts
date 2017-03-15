import { Component, Renderer, Input } from '@angular/core';
import { NgbDateStruct,NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { WeekDateParserFormatter } from './week-date-parser-formatter';

@Component({
    selector: 'nap-week-picker',
    templateUrl: './week-picker.component.html',
    styleUrls: ['./week-picker.component.scss'],
    providers: [
        {
            provide: NgbDateParserFormatter,
            useFactory: () => new WeekDateParserFormatter('longDate')
        }
    ]
})
export class WeekPickerComponent {
    @Input() minDate: NgbDateStruct;
    @Input() maxDate: NgbDateStruct;
    @Input() date: NgbDateStruct;
    private currentWeekElement: HTMLElement;

    constructor(
        private renderer: Renderer
    )
    { }

    onMouseEnter(event: MouseEvent) {
        const weekElement = this.getWeekElement(event.target);
        if (weekElement !== this.currentWeekElement) {
            if (this.currentWeekElement) {
                this.renderer.setElementClass(this.currentWeekElement, 'week-hover', false);
            }
            this.currentWeekElement = weekElement;
            this.renderer.setElementClass(this.currentWeekElement, 'week-hover', true);
        }
    }

    onMouseLeave(event: MouseEvent) {
        if (this.currentWeekElement) {
            const weekElement = this.getWeekElement(event.toElement);
            if (!this.isWeekElement(weekElement)) {
                this.renderer.setElementClass(this.currentWeekElement, 'week-hover', false);
            }
        }
    }

    private getWeekElement(eventTarget: EventTarget): HTMLElement {
        const element = eventTarget as HTMLElement;
        const dayElement = element.parentElement;
        return dayElement.parentElement;
    }

    private isWeekElement(element: HTMLElement): boolean {
        return element.classList.contains('ngb-dp-week');
    }
}
