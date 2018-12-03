import { HocSinhObject } from '../object/hoc-sinh-object';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({ providedIn: 'root' })
export class HocSinhService extends BaseService {
    private headerOptions: any;
    protected readonly httpHeader;
    // private http: Http;
    constructor(private http: HttpClient) {
        super();
        this.headerOptions = {
            headers: new Headers({
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            })
        };
    }

    getAllHocSinh(): Observable<HocSinhObject[]> {
        return this.http.get<HocSinhObject[]>(this.prefixRestUrl + '/rest/hoc-sinh/get-all').pipe();
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

