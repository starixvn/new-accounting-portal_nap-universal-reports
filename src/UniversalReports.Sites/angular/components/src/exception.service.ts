import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { ToastService } from './toast/toast.service';

@Injectable()
export class ExceptionService {
    constructor(
        private toastService: ToastService
    ) { }

    catchBadResponse: (response: Response) => Observable<any> = (response: Response) => {
        this.handleError(response);
        return Observable.of();
    }

    private handleError(response: Response) {
        const defaultMessage = 'Sorry, an error occurred while processing your request, please notify the administrators.';
        let errorMessage = '';
        const contentType = response.headers.get('content-type');
        if (contentType === 'text/html; charset=utf-8') {
            errorMessage = defaultMessage;
        } else {
            errorMessage = response.statusText;
            if (!errorMessage) {
                const error = response.json();
                errorMessage = error.errorMessage || defaultMessage;
            }
        }

        this.toastService.activate(errorMessage);
    }
}
