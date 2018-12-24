import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private authService: AuthService) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const token = localStorage.getItem('user-token');

        if (token) {
            if (!this.authService.isLoggedIn()) {
                // alert('Hết phiên đăng nhập, vui lòng đăng nhập lại');
                location.href = '/login';
            }

            const cloned = req.clone({
                headers: req.headers.set('Authorization', 'Basic  ' + token)
                .set('Content-Type', 'application/json; charset=utf-8')
                .set('Accept', 'application/json' )
                .set('Access-Control-Allow-Origin', '*')
                .set('Access-Control-Allow-Methods', 'POST,GET,PUT,DELETE')
            });
            return next.handle(cloned);
        } else {
            return next.handle(req);
        }
    }
}
