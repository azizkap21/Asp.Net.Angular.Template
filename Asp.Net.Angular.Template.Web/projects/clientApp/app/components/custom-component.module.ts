import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatIconModule } from "@angular/material/icon";
import { RouterModule } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { ContactusComponent } from './contactus/contactus.component';
import { CustomMaterialModule } from '../modules/custom-material.module';
import { HomeComponent } from './home/home.component';
import { AlertComponent } from './alert/alert.component';
import { MAT_DATE_LOCALE } from '@angular/material';
import { LoadingIndicatorComponent } from './loading-indicator/loading-indicator.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthenticationService } from '../services';


@NgModule({
  declarations: [
    AboutComponent,
    MainNavComponent,
    ContactusComponent,
    HomeComponent,
    AlertComponent,
    LoadingIndicatorComponent,
    PageNotFoundComponent,
    AccountComponent,
    LoginComponent,
    RegisterComponent,

  ],
  imports: [
    CommonModule,
    CustomMaterialModule,
    MatIconModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    
  ],

  exports: [
    AboutComponent,
    MainNavComponent,
    ContactusComponent,
    HomeComponent,
    CustomMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    
  ],
  providers: [
    // The locale would typically be provided on the root module of your application. We do it at
    // the component level here, due to limitations of our example generation script.
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' },

  ],
})
export class CustomComponentModule { }
