import { HttpClient, HttpHeaders, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AlertService, AlertType } from '../components/alert';
import { Result } from '../models';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { LoadingIndicatorService } from '../components/loading-indicator/loading-indicator.service';


@Injectable()
export class HttpService {

    constructor(private http: HttpClient,
        private alertService: AlertService,
        private loadingIndicatorService: LoadingIndicatorService) {

    }


    public getDataAsync = <T>(url: string, headers?: HttpHeaders, callback?: Function): Observable<T> => {

        this.loadingIndicatorService.showLoading();

        return this.http.get<T>(`/${url}`, { headers: headers, observe: 'response' })
            .pipe(
                map(
                    response => {
                        this.loadingIndicatorService.hideLoading();
                        return response.body;
                    }),
                catchError(this.handleError)
            );
    }
    
    public handleError = (error: HttpErrorResponse) => {

        var tmError: Result = Object.assign(new Result(), error.error);

        if (tmError && tmError.message) {
            this.alertService.alert(AlertType.Error, `${tmError.message}; Error Code: ${tmError.errorCode}`, false);

        }
        else {
            this.alertService.alert(AlertType.Error, 'Message: ' + error.message + ' Error: ' + error.statusText + ' Status: ' + error.status, false);
        }

        this.loadingIndicatorService.hideLoading();

        return throwError(error);
    }

    public postDataAsync<T, U>(url: string, postBody: U, headers?: HttpHeaders): Observable<T> {

        let jsonBody = JSON.stringify(postBody);
        console.log(jsonBody);
        let requestHeaders = headers;
        this.loadingIndicatorService.showLoading();

        if (!requestHeaders) {
            requestHeaders = new HttpHeaders({ "Content-Type": "application/json" });
        }
        else {
            requestHeaders = requestHeaders.append("Content-Type", "application/json");
        }

        return this.http.post<T>(`/${url}`, jsonBody, { headers: requestHeaders, observe: 'response' })
            .pipe(map(response => {
                this.loadingIndicatorService.hideLoading();
                return response.body
            }),
                catchError(this.handleError)
            );
    }

}

