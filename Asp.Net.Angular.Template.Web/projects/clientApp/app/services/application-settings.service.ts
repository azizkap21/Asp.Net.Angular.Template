import { GlobalSettings } from '../models/global-settings';
import { Injectable } from '@angular/core';
import { Subject, BehaviorSubject, observable, Observable } from 'rxjs';
import { HttpService } from './http.service';

@Injectable()
export class ApplicationSettingsService {

  globalSettings$: Observable<GlobalSettings | undefined>;

  constructor(private httpService: HttpService) {
    this.globalSettings$ = this.httpService.getDataAsync<GlobalSettings>("api/applicationsettings");
  }

}
