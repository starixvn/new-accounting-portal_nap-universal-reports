import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SelectComponent } from './select.component';
import { SelectDropdownComponent } from './select-dropdown.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule
    ],
    exports: [
        SelectComponent
    ],
    declarations: [
        SelectComponent,
        SelectDropdownComponent
    ]
})
export class SelectModule { }
