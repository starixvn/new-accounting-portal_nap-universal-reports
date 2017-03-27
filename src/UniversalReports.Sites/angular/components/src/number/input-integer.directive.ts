import { Directive, Input, HostListener, ElementRef } from '@angular/core';
import { NgModel } from '@angular/forms';

@Directive({
    selector: 'input[ngModel][napInputInteger]',
    providers: [NgModel]
})
export class InputIntegerDirective {
    private readonly inputElement: HTMLInputElement;
    @Input('napInputInteger') hasNegative = false;
    @HostListener('keydown', ['$event']) keyDown(event: KeyboardEvent) {
        const key = event.charCode || event.keyCode || 0;
        const isAccept =
            (
                (event.ctrlKey && event.keyCode === 67) || // accept ctrl + c(copy)
                (event.ctrlKey && event.keyCode === 86) || // accept ctrl + v(paste)
                (event.ctrlKey && event.keyCode === 65) || // accept ctrl + a(select all)
                (event.ctrlKey && event.keyCode === 88) || // accept ctrl + x(cut)
                key === 16 || // shift
                key === 17 || // ctrl
                key === 8 || // backspace
                key === 36 || // home
                key === 35 || // end
                key === 9 || // tab
                key === 46 || // delete
                (this.hasNegative && (key === 109 || key === 189)) || // -
                (key >= 37 && key <= 40) || // left , right , up , down (arrow)
                (key >= 48 && key <= 57) || // 0-9
                (key >= 96 && key <= 105)); // numpad 0-9
        return isAccept;
    }

    @HostListener('input', ['$event.target.value']) input(value: string) {
        if (value === '-') {
            this.model.viewToModelUpdate('');
            return;
        }

        const parsedValue = this.parse(value);
        const currentCaretPosition = this.inputElement.selectionStart;
        const formattedValue = this.format(parsedValue);
        this.model.valueAccessor.writeValue(formattedValue);
        this.model.viewToModelUpdate(parsedValue);
        const newCaretPosition = Math.max(0, currentCaretPosition + formattedValue.length - value.length);
        this.inputElement.selectionStart = newCaretPosition;
        this.inputElement.selectionEnd = newCaretPosition;
    }

    constructor(
        private model: NgModel,
        private elementRef: ElementRef
    ) {
        this.inputElement = this.elementRef.nativeElement;
    }

    private format(text: string) {
        return text.replace(/\B(?=(\d{3})+(?!\d))/g, ',');
    }

    private parse(text: string): string {
        text = text.replace(/,/g, '');
        const value = parseInt(text, 10);
        return isNaN(value) ? '' : value.toString();
    }
}
