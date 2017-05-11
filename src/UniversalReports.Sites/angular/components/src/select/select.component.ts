import {
    Component, Input, OnChanges, OnInit, Output, EventEmitter,
    ExistingProvider, ViewChild, ViewEncapsulation, forwardRef
} from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { SelectDropdownComponent } from './select-dropdown.component';
import { IOption } from './option.interface';
import { Option } from './option';
import { OptionList } from './option-list';

const KEYS = {
    BACKSPACE: 8,
    TAB: 9,
    ENTER: 13,
    ESC: 27,
    SPACE: 32,
    UP: 38,
    DOWN: 40
};

export const SELECT_VALUE_ACCESSOR: ExistingProvider = {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => SelectComponent),
    multi: true
};

@Component({
    selector: 'nap-select',
    templateUrl: './select.component.html',
    styleUrls: ['./select.component.scss'],
    providers: [SELECT_VALUE_ACCESSOR]
})
export class SelectComponent implements ControlValueAccessor, OnChanges, OnInit {
    @Input() noDataMsg = 'There is no information available';
    @Input() options: Array<IOption>;
    @Input() allowClear = false;
    @Input() disabled = false;
    @Input() highlightColor: string;
    @Input() highlightTextColor: string;
    @Input() multiple = false;
    @Input() noFilter = 0;
    @Input() notFoundMsg = 'No results found';
    @Input() placeholder = '';
    @Input() filterPlaceholder = '';
    @Input() label = '';

    @Output() opened = new EventEmitter<null>();
    @Output() closed = new EventEmitter<null>();
    @Output() selected = new EventEmitter<IOption>();
    @Output() deselected = new EventEmitter<IOption | IOption[]>();
    @Output() noOptionsFound = new EventEmitter<string>();

    @ViewChild('selection') selectionSpan: any;
    @ViewChild('dropdown') dropdown: SelectDropdownComponent;
    @ViewChild('filterInput') filterInput: any;

    private _value: Array<any> = [];
    private optionList: OptionList;

    // Selection state variables.
    hasSelected = false;

    // View state variables.
    hasFocus = false;
    isOpen = false;
    isBelow = true;
    private filterEnabled = true;
    private filterInputWidth = 1;
    private isDisabled = false;
    private placeholderView = '';

    private clearClicked = false;
    private selectContainerClicked = false;

    // Width and position for the dropdown container.
    private width: number;
    private top: number;
    private left: number;

    private onChange = (_: any) => { };
    private onTouched = () => { };

    /** Event handlers. **/

    // Angular lifecycle hooks.

    get hasData() {
        return this.options !== undefined && this.options.length > 0;
    }

    ngOnInit() {
        this.placeholderView = this.placeholder;
    }

    ngOnChanges(changes: any) {
        if (changes.hasOwnProperty('options')) {
            this.updateOptionsList(changes['options'].isFirstChange());
        }
        if (changes.hasOwnProperty('noFilter')) {
            const numOptions = this.optionList.options.length;
            const minNumOptions = changes['noFilter'].currentValue;
            this.filterEnabled = numOptions >= minNumOptions;
        }
    }

    // Window.

    onWindowClick() {
        if (!this.selectContainerClicked) {
            this.closeDropdown();
        }
        this.clearClicked = false;
        this.selectContainerClicked = false;
    }

    onWindowResize() {
        this.updateWidth();
    }

    // Select container.

    onSelectContainerClick(event: any) {
        if (!this.hasData) {
            return;
        }

        this.selectContainerClicked = true;
        if (!this.clearClicked) {
            this.toggleDropdown();
        }
    }

    onSelectContainerFocus() {
        this.onTouched();
    }

    onSelectContainerKeydown(event: any) {
        this.handleSelectContainerKeydown(event);
    }

    // Dropdown container.

    onDropdownOptionClicked(option: Option) {
        this.multiple ?
            this.toggleSelectOption(option) : this.selectOption(option);
    }

    onDropdownClose(focus: any) {
        this.closeDropdown(focus);
    }

    // Single filter input.

    onSingleFilterClick() {
        this.selectContainerClicked = true;
    }

    onSingleFilterInput(term: string) {
        const hasShown: boolean = this.optionList.filter(term);
        if (!hasShown) {
            this.noOptionsFound.emit(term);
        }
    }

    onSingleFilterKeydown(event: any) {
        this.handleSingleFilterKeydown(event);
    }

    // Multiple filter input.

    onMultipleFilterInput(event: any) {
        if (!this.isOpen) {
            this.openDropdown();
        }
        this.updateFilterWidth();
        setTimeout(() => {
            const term: string = event.target.value;
            const hasShown: boolean = this.optionList.filter(term);
            if (!hasShown) {
                this.noOptionsFound.emit(term);
            }
        });
    }

    onMultipleFilterKeydown(event: any) {
        this.handleMultipleFilterKeydown(event);
    }

    // Single clear select.

    onClearSelectionClick(event: any) {
        this.clearClicked = true;
        this.clearSelection();
        this.closeDropdown(true);
    }

    // Multiple deselect option.

    onDeselectOptionClick(option: Option) {
        this.clearClicked = true;
        this.deselectOption(option);
    }

    /** API. **/

    // TODO fix issues with global click/key handler that closes the dropdown.
    open() {
        this.openDropdown();
    }

    close() {
        this.closeDropdown();
    }

    clear() {
        this.clearSelection();
    }

    select(value: string) {
        this.optionList.getOptionsByValue(value).forEach((option) => {
            this.selectOption(option);
        });
    }

    /** ControlValueAccessor interface methods. **/

    writeValue(value: any) {
        this.value = value;
    }

    registerOnChange(fn: (_: any) => void) {
        this.onChange = fn;
    }

    registerOnTouched(fn: () => void) {
        this.onTouched = fn;
    }

    setDisabledState(isDisabled: boolean) {
        this.disabled = isDisabled;
    }

    /** Value. **/

    get value(): any | any[] {
        return this.multiple ? this._value : this._value[0];
    }

    set value(v: any | any[]) {
        if (typeof v === 'undefined' || v === null || v === '') {
            v = [];
        } else {
            v = [v];
        }

        if (!OptionList.equalValues(v, this._value)) {
            this.optionList.value = v;
            this.valueChanged();
        }
    }

    private valueChanged() {
        this._value = this.optionList.value;

        this.hasSelected = this._value.length > 0;
        this.placeholderView = this.hasSelected ? '' : this.placeholder;
        this.updateFilterWidth();

        this.onChange(this.value);
    }

    /** Initialization. **/

    private updateOptionsList(firstTime: boolean) {
        let v: Array<string>;

        if (!firstTime) {
            v = this.optionList.value;
        }

        this.optionList = new OptionList(this.options);

        if (!firstTime) {
            this.optionList.value = v;
            this.valueChanged();
        }
    }

    /** Dropdown. **/

    private toggleDropdown() {
        if (!this.isDisabled) {
            this.isOpen ? this.closeDropdown(true) : this.openDropdown();
        }
    }

    private openDropdown() {
        if (!this.isOpen) {
            this.updateWidth();
            this.updatePosition();
            this.isOpen = true;
            if (this.multiple && this.filterEnabled) {
                this.filterInput.nativeElement.focus();
            }
            this.opened.emit(null);
        }
    }

    private closeDropdown(focus: boolean = false) {
        if (this.isOpen) {
            this.clearFilterInput();
            this.isOpen = false;
            if (focus) {
                this.focus();
            }
            this.closed.emit(null);
        }
    }

    /** Select. **/

    private selectOption(option: Option) {
        if (!option.selected) {
            this.optionList.select(option, this.multiple);
            this.valueChanged();
            this.selected.emit(option.wrappedOption);
        }
    }

    private deselectOption(option: Option) {
        if (option.selected) {
            this.optionList.deselect(option);
            this.valueChanged();
            this.deselected.emit(option.wrappedOption);
            setTimeout(() => {
                if (this.multiple) {
                    this.updatePosition();
                    this.optionList.highlight();
                    if (this.isOpen) {
                        this.dropdown.moveHighlightedIntoView();
                    }
                }
            });
        }
    }

    private clearSelection() {
        const selection = this.optionList.selection;
        if (selection.length > 0) {
            this.optionList.clearSelection();
            this.valueChanged();

            if (selection.length === 1) {
                this.deselected.emit(selection[0].wrappedOption);
            } else {
                this.deselected.emit(selection.map((option) => {
                    return option.wrappedOption;
                }));
            }
        }
    }

    private toggleSelectOption(option: Option) {
        option.selected ?
            this.deselectOption(option) : this.selectOption(option);
    }

    private selectHighlightedOption() {
        const option = this.optionList.highlightedOption;
        if (option !== null) {
            this.selectOption(option);
            this.closeDropdown(true);
        }
    }

    private deselectLast() {
        const sel: Array<Option> = this.optionList.selection;

        if (sel.length > 0) {
            const option: Option = sel[sel.length - 1];
            this.deselectOption(option);
            this.setMultipleFilterInput(option.label + ' ');
        }
    }

    /** Filter. **/

    private clearFilterInput() {
        if (this.multiple && this.filterEnabled) {
            this.filterInput.nativeElement.value = '';
        } else {
            this.dropdown.clearFilterInput();
        }
    }

    private setMultipleFilterInput(value: string) {
        if (this.filterEnabled) {
            this.filterInput.nativeElement.value = value;
        }
    }

    private handleSelectContainerKeydown(event: any) {
        const key = event.which;

        if (this.isOpen) {
            if (key === KEYS.ESC ||
                (key === KEYS.UP && event.altKey)) {
                this.closeDropdown(true);
            } else if (key === KEYS.TAB) {
                this.closeDropdown();
            } else if (key === KEYS.ENTER) {
                this.selectHighlightedOption();
            } else if (key === KEYS.UP) {
                this.optionList.highlightPreviousOption();
                this.dropdown.moveHighlightedIntoView();
                if (!this.filterEnabled) {
                    event.preventDefault();
                }
            } else if (key === KEYS.DOWN) {
                this.optionList.highlightNextOption();
                this.dropdown.moveHighlightedIntoView();
                if (!this.filterEnabled) {
                    event.preventDefault();
                }
            }
        } else {
            if (key === KEYS.ENTER || key === KEYS.SPACE ||
                (key === KEYS.DOWN && event.altKey)) {

                /* FIREFOX HACK:
                 *
                 * The setTimeout is added to prevent the enter keydown event
                 * to be triggered for the filter input field, which causes
                 * the dropdown to be closed again.
                 */
                setTimeout(() => { this.openDropdown(); });
            }
        }

    }

    private handleMultipleFilterKeydown(event: any) {
        const key = event.which;

        if (key === KEYS.BACKSPACE) {
            if (this.hasSelected && this.filterEnabled &&
                this.filterInput.nativeElement.value === '') {
                this.deselectLast();
            }
        }
    }

    private handleSingleFilterKeydown(event: any) {
        const key = event.which;

        if (key === KEYS.ESC || key === KEYS.TAB
            || key === KEYS.UP || key === KEYS.DOWN
            || key === KEYS.ENTER) {
            this.handleSelectContainerKeydown(event);
        }
    }

    /** View. **/

    focus() {
        this.hasFocus = true;
        if (this.multiple && this.filterEnabled) {
            this.filterInput.nativeElement.focus();
        } else {
            this.selectionSpan.nativeElement.focus();
        }
    }

    blur() {
        this.hasFocus = false;
        this.selectionSpan.nativeElement.blur();
    }

    private updateWidth() {
        this.width = this.selectionSpan.nativeElement.offsetWidth;
    }

    private updatePosition() {
        const e = this.selectionSpan.nativeElement;
        this.left = e.offsetLeft;
        this.top = e.offsetTop + e.offsetHeight;
    }

    private updateFilterWidth() {
        if (typeof this.filterInput !== 'undefined') {
            const value: string = this.filterInput.nativeElement.value;
            this.filterInputWidth = value.length === 0 ?
                1 + this.placeholderView.length * 10 : 1 + value.length * 10;
        }
    }
}
