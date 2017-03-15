import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastComponent } from './toast.component';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        ToastComponent
    ],
    exports: [
        ToastComponent
    ]
})
export class ToastModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: ToastModule
        };
    }
}
