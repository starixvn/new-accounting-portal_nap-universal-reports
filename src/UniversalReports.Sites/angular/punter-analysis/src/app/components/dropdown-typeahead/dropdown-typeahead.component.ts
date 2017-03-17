import { Component, Input, Output, EventEmitter, HostListener } from '@angular/core';
import { TypeaheadQuery } from './dropdown-typeahead.model';

@Component({
    selector: 'nap-dropdown-typeahead',
    templateUrl: './dropdown-typeahead.component.html'
})
export class DropdownTypeaheadComponent {
    @Input() query: TypeaheadQuery;
    @Input() placeholder: string;
    @Input() text: string;
    @Input() minLengthHasSuggestion = 2;
    @Output() textChange = new EventEmitter<string>();
    index = -1;
    items: string[] = [];

    @HostListener('document:click') onDocumentClick() {
        this.hide();
    }

    get isOpen(): boolean {
        return this.items.length > 0;
    }

    onKeydown(event: KeyboardEvent) {
        switch (event.code) {
            case 'Escape':
                this.hide();
                event.preventDefault();
                return;
            case 'ArrowDown':
                if (this.isOpen) {
                    this.index = Math.min(this.items.length - 1, this.index + 1);
                    event.preventDefault();
                }
                return;
            case 'ArrowUp':
                if (this.isOpen) {
                    this.index = Math.max(0, this.index - 1);
                    event.preventDefault();
                }
                return;
            case 'Enter':
            case 'NumpadEnter':
                if (this.index !== -1) {
                    this.onItemClick(this.items[this.index]);
                    event.preventDefault();
                }
                return;
        }
    }

    onModelChange() {
        this.index = -1;
        this.textChange.emit(this.text);
        let term = this.text;
        if (term.length >= this.minLengthHasSuggestion) {
            this.search(term);
        } else {
            this.hide();
        }
    }

    onItemClick(item: string) {
        this.text = item;
        this.textChange.emit(this.text);
        this.hide();
    }

    private search(term: string) {
        this.index = -1;
        this.items = ['Searching ...'];
        this.query.search(term).subscribe(items => {
            if (this.text === term) {
                this.items = items;
            }
        });
    }

    private hide() {
        this.items = [];
    }
}
