import { DocumentObject } from '../../object/document-detail-object';
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';

@Injectable({ providedIn: 'root' })
export class DocumentDetailService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getAllDocumentDetail(courseId): Observable<DocumentObject[]> {
        const params = new HttpParams()
            .set('courseId', courseId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<DocumentObject[]>(this.prefixRestUrl + 'rest/documentdetail/get-all', httpOptions).pipe();
    }

    getOneDocumentDetail(documentDetailId: number): Observable<DocumentObject> {
        const params = new HttpParams()
            .set('documentDetailId', documentDetailId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<DocumentObject>(this.prefixRestUrl + 'documentdetail/get', httpOptions).pipe();
    }

    insertDocumentDetail(documentDetail: DocumentObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/documentDetail/insert', documentDetail);
    }

    updateDocumentDetail(documentDetail: DocumentObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/documentDetail/update', documentDetail, httpOptions);
    }

    deleteOneDocumentDetail(documentDetailId: number): Observable<any> {
        const params = new HttpParams()
            .set('documentDetailId', documentDetailId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/documentDetail/delete', httpOptions).pipe();
    }
}

