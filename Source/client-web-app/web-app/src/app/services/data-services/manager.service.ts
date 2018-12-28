import { ManagerObject } from '../../object/manager-object';
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';

@Injectable({ providedIn: 'root' })
export class ManagerService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getAllManager(searchKeyword): Observable<ManagerObject[]> {
        const params = new HttpParams()
            .set('searchKeyword', searchKeyword.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<ManagerObject[]>(this.prefixRestUrl + 'rest/manager/get-all', httpOptions).pipe();
    }

    getOneManager(hocSinhId: number): Observable<ManagerObject> {
        const params = new HttpParams()
            .set('managerId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<ManagerObject>(this.prefixRestUrl + 'rest/manager/get', httpOptions).pipe();
    }

    insertManager(manager: ManagerObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/manager/insert', manager, { headers: this.httpHeader });
    }

    updateManager(manager: ManagerObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/manager/update', manager, { headers: this.httpHeader });
    }


    deleteOneManager(hocSinhId: number): Observable<any> {
        const params = new HttpParams()
            .set('managerId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/manager/delete', httpOptions).pipe();
    }
}

