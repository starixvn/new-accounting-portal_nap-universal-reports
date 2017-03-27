import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Ng2PaginationModule } from 'ng2-pagination';
import { PaginationComponent } from './pagination.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        Ng2PaginationModule
    ],
    declarations: [
        PaginationComponent
    ],
    exports: [
        Ng2PaginationModule,
        PaginationComponent
    ]
})
export class PaginationModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: PaginationModule
        };
    }
}
