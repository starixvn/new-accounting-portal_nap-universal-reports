import { Injectable } from '@angular/core';
import { Http, RequestOptionsArgs, RequestOptions, ResponseContentType, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/finally';
import { SpinnerService } from 'nap-components/src/spinner';
import { ToastService } from 'nap-components/src/toast';
import { ExceptionService } from 'nap-components/src/exception.service';

@Injectable()
export class HttpService {
    constructor(
        private http: Http,
        private exceptionService: ExceptionService,
        private spinnerService: SpinnerService,
        private toastService: ToastService
    ) { }

    get<T>(url: string, options?: RequestOptionsArgs): Observable<T> {
        this.toastService.deactivate();
        this.spinnerService.show();
        return this.http.get(url, options)
            .map(response => response.json())
            .catch(this.exceptionService.catchBadResponse)
            .finally(() => this.spinnerService.hide());
    }

    post<T>(url: string, body = {}): Observable<T> {
        this.toastService.deactivate();
        this.spinnerService.show();
        return this.http.post(url, body)
            .map(response => response.json())
            .catch(this.exceptionService.catchBadResponse)
            .finally(() => this.spinnerService.hide());
    }

    download(url: string, body: any): Observable<Response> {
        this.toastService.deactivate();
        this.spinnerService.show();
        return this.http.post(
            url,
            body,
            new RequestOptions({
                responseType: ResponseContentType.ArrayBuffer
            }))
            .catch(this.exceptionService.catchBadResponse)
            .finally(() => this.spinnerService.hide());
    }
}
