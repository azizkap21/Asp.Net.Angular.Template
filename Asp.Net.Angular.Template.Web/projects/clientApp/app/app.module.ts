import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { HttpService, AuthenticationService, ApplicationSettingsService } from './services';

import { AppRoutingModule } from './modules/app-routing.module';
import { AppComponent } from './app.component';
import { CustomComponentModule } from './components/custom-component.module';
import { AlertService } from './components/alert';
import { LoadingIndicatorService } from './components/loading-indicator/loading-indicator.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CustomComponentModule,
    HttpClientModule
  ],
  providers: [HttpService, AlertService, HttpClientModule, LoadingIndicatorService, AuthenticationService, ApplicationSettingsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
