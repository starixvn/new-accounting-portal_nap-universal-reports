import { Component, Renderer, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { NgbDateParserFormatter, NgbInputDatepicker, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
import { NgbDate } from '../date-model.date';
import { NgbDateStruct } from '../date-model.date-struct';
import { DateRange } from '../date-model.date-range';
import { DateFormat } from '../date-model.date-format';
import { DateHelper } from '../date-helper';
import { WeekDateParserFormatter } from './week-date-parser-formatter';

@Component({
    selector: 'nap-week-picker',
    templateUrl: './week-picker.component.html',
    styleUrls: ['./week-picker.component.scss'],
    providers: [{
        provide: NgbDateParserFormatter,
        useFactory: () => new WeekDateParserFormatter('longDate')
    }]
})
export class WeekPickerComponent implements OnChanges {
    @Input() minDate: NgbDateStruct;
    @Input() maxDate: NgbDateStruct;
    @Input() date: NgbDateStruct;
    @Output() dateChange = new EventEmitter<NgbDateStruct>();
    private currentWeekElement: HTMLElement;
    private weekRange: DateRange;

    constructor(
        private renderer: Renderer
    ) { }

    ngOnChanges(changes: SimpleChanges) {
        const dateChange = changes['date'];
        if (dateChange && dateChange.isFirstChange()) {
            this.weekRange = DateHelper.getWeekRangeOfDate(this.date);
            const day = this.weekRange.fromDate.day;
            if (this.minDate) {
                const minNgbDate = NgbDate.fromDateStruct(this.minDate);
                const fromNgbDate = NgbDate.fromDateStruct(this.weekRange.fromDate);
                if (minNgbDate.after(fromNgbDate)) {
                    this.updateDate(this.minDate);
                } else {
                    this.updateDate(this.weekRange.fromDate);
                }
            } else {
                this.updateDate(this.weekRange.fromDate);
            }
        }
    }

    onClick(event: MouseEvent, disabled: boolean) {
        if (disabled) {
            return;
        }

        const weekElement = this.getWeekElement(event.target);
        if (weekElement) {
            const firstActiveDayElement = this.getFirstActiveDayElement(weekElement);
            if (firstActiveDayElement && firstActiveDayElement.children[0] !== event.target) {
                event.stopPropagation();
                firstActiveDayElement.click();
            }
        }
    }

    onMouseEnter(event: MouseEvent, disabled: boolean) {
        const weekElement = this.getWeekElement(event.target);
        if (weekElement && weekElement !== this.currentWeekElement) {
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
            const weekElement = this.getWeekElement(event.relatedTarget);
            if (!weekElement || !disabled) {
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
        const lastDayOfWeek = DateHelper.getLastDayOfWeek(this.date);
        const firstNgbDateOfWeek = NgbDate.fromDateStruct(this.date);
        const lastNgbDateOfWeek = NgbDate.fromDateStruct(lastDayOfWeek);
        return (ngbDate.equals(firstNgbDateOfWeek) || ngbDate.after(firstNgbDateOfWeek)) &&
            (ngbDate.equals(lastNgbDateOfWeek) || ngbDate.before(lastNgbDateOfWeek));
    }

    private updateDate(date: NgbDateStruct) {
        const ngbDate = NgbDate.fromDateStruct(date);
        const currentNgbDate = NgbDate.fromDateStruct(this.date);
        if (!ngbDate.equals(currentNgbDate)) {
            this.date = date;
            this.dateChange.emit(date);
        }
    }

    private getWeekElement(eventTarget: EventTarget): HTMLElement {
        const element = eventTarget as HTMLElement;
        const dayElement = element.parentElement;
        if (dayElement !== null && dayElement.classList.contains('ngb-dp-day')) {
            return dayElement.parentElement;
        }

        return undefined;
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
