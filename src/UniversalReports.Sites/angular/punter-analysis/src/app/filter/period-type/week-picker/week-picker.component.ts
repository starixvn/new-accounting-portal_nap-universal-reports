import { Component, Renderer, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { NgbDateParserFormatter, NgbInputDatepicker, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
import { NgbDateStruct, NgbDate, WeekRange } from '../period-type.model';
import { WeekDateParserFormatter } from './week-date-parser-formatter';
import { Helper } from '../helper';

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
    @Output() dateChange = new EventEmitter<NgbDateStruct>();
    private currentWeekElement: HTMLElement;
    private weekRange: WeekRange;

    constructor(
        private renderer: Renderer
    ) { }

    ngOnChanges(changes: SimpleChanges) {
        const dateChange = changes['date'];
        if (dateChange && dateChange.isFirstChange()) {
            this.weekRange = Helper.getWeekRangeOfDate(this.date);
            let day = this.weekRange.fromDate.day;
            if (this.minDate) {
                const minNgbDate = NgbDate.fromDateStruct(this.minDate);
                const fromNgbDate = NgbDate.fromDateStruct(this.weekRange.fromDate);
                if (minNgbDate.after(fromNgbDate)) {
                    day = minNgbDate.day;
                }
            }
            this.date.day = day;
        }
    }

    onClick(event: MouseEvent, disabled: boolean) {
        if (disabled) return;

        const weekElement = this.getWeekElement(event.target);
        const firstActiveDayElement = this.getFirstActiveDayElement(weekElement);
        if (firstActiveDayElement && firstActiveDayElement.children[0] !== event.target) {
            event.stopPropagation();
            firstActiveDayElement.click();
        }
    }

    onMouseEnter(event: MouseEvent, disabled: boolean) {
        const weekElement = this.getWeekElement(event.target);
        if (weekElement !== this.currentWeekElement) {
            if (this.currentWeekElement) {
                this.renderer.setElementClass(this.currentWeekElement, 'week-hover', false);
                this.currentWeekElement = undefined;
            }

            if (!disabled) {
                this.currentWeekElement = weekElement;
                this.renderer.setElementClass(this.currentWeekElement, 'week-hover', true);
            }
        }
    }

    onMouseLeave(event: MouseEvent, disabled: boolean) {
        if (this.currentWeekElement) {
            const weekElement = this.getWeekElement(event.toElement);
            if (!this.isWeekElement(weekElement) || !disabled) {
                this.renderer.setElementClass(this.currentWeekElement, 'week-hover', false);
                this.currentWeekElement = undefined;
            }
        }
    }

    onModelChange() {
        this.dateChange.emit(this.date);
    }

    isSelected(dateStruct: NgbDateStruct) {
        const ngbDate = NgbDate.fromDateStruct(dateStruct);
        const lastDayOfWeek = Helper.getLastDayOfWeek(this.date);
        const firstNgbDateOfWeek = NgbDate.fromDateStruct(this.date);
        const lastNgbDateOfWeek = NgbDate.fromDateStruct(lastDayOfWeek);
        return (ngbDate.equals(firstNgbDateOfWeek) || ngbDate.after(firstNgbDateOfWeek)) &&
            (ngbDate.equals(lastNgbDateOfWeek) || ngbDate.before(lastNgbDateOfWeek));
    }

    private getWeekElement(eventTarget: EventTarget): HTMLElement {
        const element = eventTarget as HTMLElement;
        const dayElement = element.parentElement;
        return dayElement.parentElement;
    }

    private isWeekElement(element: HTMLElement): boolean {
        return element.classList.contains('ngb-dp-week');
    }

    private getFirstActiveDayElement(weekElement: HTMLElement): HTMLElement {
        for (let i = 1; i < weekElement.children.length; i++) {
            const dayElement = weekElement.children[i] as HTMLElement;
            if (dayElement.children[0].classList.contains('btn-secondary')) {
                return dayElement;
            }
        }

        return null;
    }
}
