import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';

export class AuthInterceptor implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        const dupReq = req.clone({
            headers: req.headers.set('key', 'DCtbqRXC8L'),
        });
        return next.handle(dupReq);
    }
}
