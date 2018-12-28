import { ParentObject } from '../../object/parent-object';
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';

@Injectable({ providedIn: 'root' })
export class ParentService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getAllParent(searchKeyword): Observable<ParentObject[]> {
        const params = new HttpParams()
            .set('searchKeyword', searchKeyword.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<ParentObject[]>(this.prefixRestUrl + 'rest/parent/get-all', httpOptions).pipe();
    }

    getAllParentByStudent(studentId): Observable<ParentObject[]> {
        const params = new HttpParams()
            .set('studentId', studentId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<ParentObject[]>(this.prefixRestUrl + 'rest/parent/get-all-by-student', httpOptions).pipe();
    }

    getOneParent(hocSinhId: number): Observable<ParentObject> {
        const params = new HttpParams()
            .set('parentId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<ParentObject>(this.prefixRestUrl + 'rest/parent/get', httpOptions).pipe();
    }

    insertParent(parent: ParentObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/parent/insert', parent, { headers: this.httpHeader });
    }

    updateParent(parent: ParentObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/parent/update', parent, { headers: this.httpHeader });
    }

    deleteOneParent(hocSinhId: number): Observable<any> {
        const params = new HttpParams()
            .set('parentId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/parent/delete', httpOptions).pipe();
    }
}

