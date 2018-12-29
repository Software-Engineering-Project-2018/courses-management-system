import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';
import { NotificationObject } from 'src/app/object/notification-object';

@Injectable({ providedIn: 'root' })
export class NotificationService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getAllGeneralNotification(searchKeyword): Observable<NotificationObject[]> {
        const params = new HttpParams()
            .set('searchKeyword', searchKeyword.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<NotificationObject[]>(this.prefixRestUrl + 'rest/notification/get-general', httpOptions).pipe();
    }

    getAllCourseNotification(searchKeyword): Observable<NotificationObject[]> {
        const params = new HttpParams()
            .set('searchKeyword', searchKeyword.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<NotificationObject[]>(this.prefixRestUrl + 'rest/notification/get-course', httpOptions).pipe();
    }

    getOneNotification(hocSinhId: number): Observable<NotificationObject> {
        const params = new HttpParams()
            .set('NotificationId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<NotificationObject>(this.prefixRestUrl + 'rest/notification/get', httpOptions).pipe();
    }

    insertNotification(notification: NotificationObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/notification/insert', notification, { headers: this.httpHeader });
    }

    updateNotification(notification: NotificationObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/notification/update', notification, { headers: this.httpHeader });
    }


    deleteOneNotification(notificationId: number): Observable<any> {
        const params = new HttpParams()
            .set('notificationId', notificationId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/notification/delete', httpOptions).pipe();
    }
}

