
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';
import * as moment from 'moment';
import { StorageService } from './storage.service';

@Injectable({ providedIn: 'root' })
export class AuthService extends BaseService {
    protected readonly httpHeader;
    // private http: Http;
    constructor(private http: HttpClient, private storageService: StorageService) {
        super();
    }

    login(userName, password): Observable<any> {
        // tslint:disable-next-line:prefer-const
        let data = 'UserName=' + userName + '&Password=' + password + '&grant_type=password';
        // tslint:disable-next-line:prefer-const
        let reqHeader = new HttpHeaders({
            'Content-Type': 'application/json', 'No-Auth': 'True',
            'Access-Control-Allow-Origin': '*'
        });
        return this.http.post(this.prefixRestUrl + '/token', data, { headers: reqHeader });
    }

    getUserInfo(): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
            // params: params
        };
        return this.http.get<any>(this.prefixRestUrl + '/rest/systems/get-user-info', httpOptions).pipe();
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

