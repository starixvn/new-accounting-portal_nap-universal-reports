import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DropdownSelectComponent } from './dropdown-select.component';
import { DropdownSelectPipe } from './dropdown-select.pipe';

@NgModule({
    imports: [
        CommonModule,
        FormsModule
    ],
    declarations: [
        DropdownSelectComponent,
        DropdownSelectPipe
    ],
    exports: [
        DropdownSelectComponent,
        DropdownSelectPipe
    ]
})
export class DropdownSelectModule { }
