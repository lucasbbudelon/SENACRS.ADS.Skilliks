import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map, catchError, tap } from 'rxjs/operators';
import { Observable, empty, of } from 'rxjs';
import { pipe } from '@angular/core/src/render3';
import { User } from '../user/user.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private LOCAL_STOREGE_KEY = 'user-logged-in';

  constructor(
    private router: Router,
    private httpClient: HttpClient
  ) { }


  login(email: string) {

    localStorage.removeItem(this.LOCAL_STOREGE_KEY);

    const url = `${environment.api}/authentication/${email}`;
    return this.httpClient.get<User>(url)
      .pipe(
        tap((user) => {
          localStorage.setItem(this.LOCAL_STOREGE_KEY, JSON.stringify(user));
          return of(true);
        }),
        catchError(() => of(false))
      );
  }

  logout() {
    localStorage.removeItem(this.LOCAL_STOREGE_KEY);
    this.router.navigate(['/login']);
  }

  check() {
    const hasUserLoggedIn = this.getUserLoggedIn() !== null;

    if (!hasUserLoggedIn) {
      this.router.navigate(['/login']);
    }

    return hasUserLoggedIn;
  }

  getUserLoggedIn(): User {
    const user = localStorage.getItem(this.LOCAL_STOREGE_KEY);
    if (!user) { return null; }
    return JSON.parse(user);
  }

  getLocalStorageKey() {
    return this.LOCAL_STOREGE_KEY;
  }
}
