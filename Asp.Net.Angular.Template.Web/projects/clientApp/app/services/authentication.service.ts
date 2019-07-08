import { BehaviorSubject, Observable } from 'rxjs';
import { HttpService } from './http.service';
import { AuthenticationResponse, Credential } from '../models';
import * as jwt_decode from 'jwt-decode';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private userStorageKey = 'currentUser';

  private currentUserSubject: BehaviorSubject<AuthenticationResponse>;
  public currentUser: Observable<AuthenticationResponse>;


  constructor(private http: HttpService) {
    this.currentUserSubject = new BehaviorSubject<AuthenticationResponse>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): AuthenticationResponse {
    return this.currentUserSubject.value;
  }

  isTokenValid(): boolean {
    var token: string;

    if (this.currentUserSubject.value)
      token = this.currentUserSubject.value.accessToken;
    else
      return false;

    try {
      var decodedToken = jwt_decode(token)
      return true;
    }
    catch{
      this.logout();
      return false;
    }

  }

  login(username: string, password: string) {
    var credentials = new Credential();
    credentials.email = username;
    credentials.password = password;

    return this.http.postDataAsync<AuthenticationResponse, Credential>('useraccount/login', credentials)
      .pipe(map(user => {
        // login successful if there's a jwt token in the response
        if (user && user.accessToken) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem(this.userStorageKey, JSON.stringify(user));
          this.currentUserSubject.next(user);
          return true;
        }

        return false;
      }
      ))
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
