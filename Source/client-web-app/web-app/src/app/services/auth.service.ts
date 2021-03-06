
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as moment from 'moment';
import { StorageService } from './storage.service';
import { BaseService } from '../module/base/base.service';

@Injectable({ providedIn: 'root' })
export class AuthService extends BaseService {
    constructor(public injector: Injector, private http: HttpClient, public storageService: StorageService) {
        super(injector);
    }


    login(userName, password): Observable<any> {
        const data = 'UserName=' + userName + '&Password=' + password + '&grant_type=password';
        const reqHeader = new HttpHeaders({
            'Content-Type': 'application/x-www-urlencoded',
            'No-Auth': 'True'
        });
        return this.http.post(this.prefixRestUrl + '/token', data, { headers: reqHeader });
    }

    getUserInfo(): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
            // params: params
        };
        return this.http.get<any>(this.prefixRestUrl + '/rest/systems/get-user-info', this.httpHeader).pipe();
    }

    // Kiểm tra đã đăng nhập chưa, dựa vào expire date
    public isLoggedIn() {
        // return moment().isBefore(this.getExpiration());
        return this.storageService.getUserToken() != null;
    }

    // lấy expire date của JWT
    getExpiration() {
        const token = this.decodeToken(localStorage.getItem('user_token'));
        if (token === null) {
            return moment().add(-10000, 'd').toDate();
        }

        return moment.unix(token.exp).toDate();
    }

    private decodeToken(token: string) {
        if (!token) {
            return null;
        }
        try {
            const base64Url = token.split('.')[1];
            const base64 = base64Url.replace('-', '+').replace('_', '/');
            return JSON.parse(window.atob(base64));
        } catch (e) {
            return null;
        }
    }
}

