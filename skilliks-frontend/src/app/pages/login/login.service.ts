import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map, catchError, tap } from 'rxjs/operators';
import { Observable, empty, of } from 'rxjs';
import { pipe } from '@angular/core/src/render3';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private LOCAL_STOREGE_KEY = 'user-logged-in';

  constructor(
    private router: Router,
    private httpClient: HttpClient
  ) { }


  login(username: string, password: string) {

    localStorage.removeItem(this.LOCAL_STOREGE_KEY);

    const url = `${environment.api}/token?username=${username}&password=${password}`;
    return this.httpClient.get<string>(url)
      .pipe(
        catchError((response) => {
          const ok = response.status === 200;
          if (ok) { localStorage.setItem(this.LOCAL_STOREGE_KEY, response); }
          return of(ok);
        })
      );
  }

  logout() {
    localStorage.removeItem(this.LOCAL_STOREGE_KEY);
    this.router.navigate(['/login']);
  }

  hasUserLoggedIn() {
    const hasUserLoggedIn = this.getUserLoggedIn() !== null;

    if (!hasUserLoggedIn) {
      this.router.navigate(['/login']);
    }

    return hasUserLoggedIn;
  }

  getUserLoggedIn() {
    return localStorage.getItem(this.LOCAL_STOREGE_KEY);
  }

  getLocalStorageKey() {
    return this.LOCAL_STOREGE_KEY;
  }
}
