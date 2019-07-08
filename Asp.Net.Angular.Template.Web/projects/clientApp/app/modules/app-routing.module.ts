import { Routes, RouterModule } from "@angular/router";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutComponent } from '../components/about/about.component';
import { HomeComponent } from '../components/home/home.component';
import { ContactusComponent } from '../components/contactus/contactus.component';
import { CustomComponentModule } from "../components/custom-component.module";

import { PageNotFoundComponent } from "../components/page-not-found/page-not-found.component";
import { LoginComponent } from '../components/login/login.component';




const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'about', component: AboutComponent },
  { path: 'contactus', component: ContactusComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'page-not-found', component: PageNotFoundComponent },
  { path: '**', redirectTo: '/page-not-found' }
];

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    CustomComponentModule,
    RouterModule.forRoot(appRoutes, {
      enableTracing: false,
    })
  ],
  exports: [RouterModule, CustomComponentModule]
})
export class AppRoutingModule { }
