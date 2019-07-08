import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginService } from '../pages/login/login.service';

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

    constructor(
        private loginService: LoginService
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        const name = this.loginService.getLocalStorageKey();
        const user = this.loginService.getUserLoggedIn();
        return next.handle(
            req.clone({
                headers: req.headers.append(name, user.email)
            })
        );
    }
}
