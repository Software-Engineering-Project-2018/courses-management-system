import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router, private authService: AuthService) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        req = this.addAuthentication(req);
        const token = localStorage.getItem('user-token');

        if (token) {
            if (!this.authService.isLoggedIn()) {
                // alert('Hết phiên đăng nhập, vui lòng đăng nhập lại');
                location.href = '/login';
            }
            return next.handle(req);
        } else {
            return next.handle(req);
        }
    }

    addAuthentication(req: HttpRequest<any>): HttpRequest<any> {
        const headers: any = {};
        const authToken = this.authService.storageService.getUserToken(); // get the token from a service
        if (authToken) {
            headers['authorization'] = 'Bearer ' + authToken; // add it to the header
            req = req.clone({
                setHeaders: headers
            });
        }
        return req;
    }
    // intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    //     const token = localStorage.getItem('user-token');

    //     if (token) {
    //         if (!this.authService.isLoggedIn()) {
    //             // alert('Hết phiên đăng nhập, vui lòng đăng nhập lại');
    //             location.href = '/login';
    //         }

    //         const cloned = req.clone({
    //             headers: req.headers.set('Authorization', 'Bearer  ' + token)
    //                 .set('Content-Type', 'application/json; charset=utf-8')
    //                 .set('Accept', 'application/json')
    //                 .set('Access-Control-Allow-Origin', '*')
    //                 .set('Access-Control-Allow-Methods', 'POST,GET,PUT,DELETE')
    //         });
    //         return next.handle(cloned);
    //     } else {
    //         return next.handle(req);
    //     }
    // }
}
