import { HocSinhObject } from '../../object/hoc-sinh-object';
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';

@Injectable({ providedIn: 'root' })
export class HocSinhService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getAllHocSinh(): Observable<HocSinhObject[]> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.get<HocSinhObject[]>(this.prefixRestUrl + '/rest/hoc-sinh/get-all', httpOptions).pipe();
    }

    getOneHocSinh(hocSinhId: number): Observable<HocSinhObject> {
        const params = new HttpParams()
            .set('hocSinhId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<HocSinhObject>(this.prefixRestUrl + '/rest/hoc-sinh/get', httpOptions).pipe();
    }

    deleteHocSinh(hocSinhId: number): Observable<any> {
        const params = new HttpParams()
            .set('hocSinhId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + '/rest/hoc-sinh/delete', httpOptions).pipe();
    }
}

