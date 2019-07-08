import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, FormGroupDirective } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, Observable } from 'rxjs';
import { AuthenticationService } from '../../services/authentication.service';
import { GlobalSettings } from '../../models/global-settings';
import { ApplicationSettingsService } from '../../services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
   
  loginForm: FormGroup;

  loading = false;
  submitted = false;
  returnUrl: string;
  loginSub: Subscription;
  globalSettings$: Observable<GlobalSettings | undefined>;

  ngOnInit(): void {

    this.globalSettings$ = this.applicationSettingService.globalSettings$;
    this.loginForm = new FormGroup({
      userName: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    });
  }

  constructor(private router: Router,
    private authenticationService: AuthenticationService,
    private applicationSettingService: ApplicationSettingsService) {
    if (this.authenticationService.isTokenValid()) {
      this.router.navigate(['/']);
    }
  }

  ngOnDestroy() {
    if (this.loginSub) {
      this.loginSub.unsubscribe();
    }

  }
}
