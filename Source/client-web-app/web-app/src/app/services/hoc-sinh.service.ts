import { HocSinhObject } from '../object/hoc-sinh-object';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class HocSinhService {
    private headerOptions: any;
    protected readonly httpHeader;
    // private http: Http;
    constructor(private http: HttpClient) {
        // super();
        this.headerOptions = {
            headers: new Headers({
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            })
        };
    }
    configUrl = 'http://www.stem.somee.com/rest/hoc-sinh/get-all';

    getAllHocSinh(): Observable<HocSinhObject[]> {
        return this.http.get<HocSinhObject[]>(this.configUrl).pipe();
    }
}

