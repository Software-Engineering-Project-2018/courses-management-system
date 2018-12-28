import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocalStorageService } from 'angular-web-storage';

@Injectable({
    providedIn: 'root',
})
export class StorageService {
    constructor(private http: HttpClient,
        private localStorageService: LocalStorageService) {
    }

    public getUserInfo() {
        return this.getLocalStorage('user-info');
    }

    public setUserInfo(value, expired) {
        this.setLocalStorage('user-info', value, expired);
        // set timeout token
        // remove nhan-vien-info timeout
        setTimeout(function () {
            localStorage.removeItem('user-info');
        }, expired * 1000);
    }

    public getUserToken() {
        return this.getLocalStorage('user-token');
    }

    public setUserToken(token, expired) {
        this.setLocalStorage('user-token', token, expired);
        // set timeout token
        // remove user-token timeout
        setTimeout(function () {
            localStorage.removeItem('user-token');
        }, expired * 1000);
    }

    public removeUserToken() {
        localStorage.removeItem('user-token');
    }

    public removeUserInfo() {
        localStorage.removeItem('user-info');
    }

    // public setExpiredToken(expired)
    // {
    //     var currentDate = new Date();
    //     currentDate.setTime(currentDate.getTime() + expired*1000);
    //     this.setLocalStorage("user-token-expired-time", currentDate, undefined);
    // }

    public setLocalStorage(key, value, expired) {
        // 8h
        let timeExpired = 28800;
        if (!expired) {
            timeExpired = expired;
        }

        this.localStorageService.set(key, value, timeExpired, 's');
    }

    public removeLocalStorage(key) {
        this.localStorageService.remove(key);
    }

    public getLocalStorage(key): any {
        return this.localStorageService.get(key);
    }

    public clearLocalStorage() {
        this.localStorageService.clear();
    }
}
