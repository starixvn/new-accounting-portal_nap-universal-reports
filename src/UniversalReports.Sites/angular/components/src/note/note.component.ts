import { Component } from '@angular/core';

@Component({
    selector: 'nap-note',
    templateUrl: './note.component.html',
    styleUrls: ['./note.component.scss']
})
export class NoteComponent {
    isCollapsed = false;
}
