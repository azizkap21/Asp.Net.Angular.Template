import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthenticationService } from '../../services';
import { AuthenticationResponse } from '../../models';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit, OnDestroy {
   
  loggedin = false;
  currentUser: AuthenticationResponse;
  userName: string;
  userSubscription: Subscription;

  constructor(private authenticationService: AuthenticationService) {
    this.userSubscription = this.authenticationService.currentUser.subscribe(user => {
      this.currentUser = user;
      if (this.authenticationService.isTokenValid()) {
        this.loggedin = true;
        this.userName = user.userName;
      }
      else {
        this.userName = "Guest User";
      }
    });
  }

  ngOnInit() {
  }
  
  ngOnDestroy() {
    if (this.userSubscription) {
      this.userSubscription.unsubscribe();
    }
  }
}
