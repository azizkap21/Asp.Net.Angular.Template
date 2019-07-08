import { Injectable } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Observable, Subject, BehaviorSubject } from 'rxjs';

import { Alert, AlertType } from './alert.model';


@Injectable()

export class AlertService {

  private subject = new Subject<Alert>();
  private keepAfterRouteChange = false;
  private alertCollection: Alert[] = [];
  private alerts: Subject<Alert[] | undefined> = new BehaviorSubject(this.alertCollection);

  alerts$ = this.alerts.asObservable();

  constructor(private router: Router) {
    // clear alert messages on route change unless 'keepAfterRouteChange' flag is true
    router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        if (this.keepAfterRouteChange) {
          // only keep for a single route change
          this.keepAfterRouteChange = false;
        } else {
          // clear alert messages
          this.clear();
        }
      }
    });
  }

  getAlert(): Observable<Alert[]> {
    return this.alerts$;
  }

  success(message: string, keepAfterRouteChange = false) {
    this.alert(AlertType.Success, message, keepAfterRouteChange);
  }

  error(message: string, keepAfterRouteChange = false) {
    this.alert(AlertType.Error, message, keepAfterRouteChange);
  }

  info(message: string, keepAfterRouteChange = false) {
    this.alert(AlertType.Info, message, keepAfterRouteChange);
  }

  warn(message: string, keepAfterRouteChange = false) {
    this.alert(AlertType.Warning, message, keepAfterRouteChange);
  }

  alert(type: AlertType, message: string, keepAfterRouteChange = false) {
    this.keepAfterRouteChange = keepAfterRouteChange;
    let alert = new Alert();
    alert.type = type;
    alert.message = message;

    this.alertCollection.push(alert);

    //this.alerts.push(alert);
    this.alerts.next(this.alertCollection);
  }

  remove(alert: Alert) {
    this.alertCollection = this.alertCollection.filter(x => x !== alert);
    this.alerts.next(this.alertCollection);
  }

  clear() {
    // clear alerts
    this.alertCollection = [];
    this.alerts.next(this.alertCollection);
  }
}
