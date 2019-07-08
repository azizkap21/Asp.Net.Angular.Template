import { Component, OnInit, OnDestroy } from '@angular/core';

import { Alert, AlertType } from './alert.model';
import { AlertService } from './alert.service';
import { Observable } from 'rxjs';

@Component({
    selector: 'alert',
    templateUrl: 'alert.component.html',
    styleUrls: ['./alert.component.css']
})

export class AlertComponent implements OnInit {
    public alerts$: Observable<Alert[]>;

    constructor(private alertService: AlertService) { }

    ngOnInit() {
       this.alerts$ = this.alertService.alerts$;
    }

    removeAlert(alert: Alert) {
        this.alertService.remove(alert);
    }

    cssClass(alert: Alert) {
        if (!alert) {
            return;
        }

        // return css class based on alert type
        switch (alert.type) {
            case AlertType.Success:
                return 'alert-success';
            case AlertType.Error:
                return 'alert-danger';
            case AlertType.Info:
                return 'alert-info';
            case AlertType.Warning:
                return 'alert-warning';
        }
    }
}
