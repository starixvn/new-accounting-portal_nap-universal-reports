import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DropdownTypeaheadComponent } from './dropdown-typeahead.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule
    ],
    declarations: [
        DropdownTypeaheadComponent
    ],
    exports: [
        DropdownTypeaheadComponent
    ]
})
export class DropdownTypeaheadModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: DropdownTypeaheadModule
        };
    }
}
