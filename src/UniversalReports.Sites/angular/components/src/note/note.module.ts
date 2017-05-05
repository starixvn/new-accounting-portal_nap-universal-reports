import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoteComponent } from './note.component';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        NoteComponent
    ],
    exports: [
        NoteComponent
    ]
})
export class NoteModule { }
