import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { BaseService } from '../module/base/base.service';
import { Observable } from 'rxjs';


@Injectable()

export class FileService extends BaseService {

    constructor(private http: HttpClient,
        injector: Injector) {
        super(injector);
    }

    downloadFile(file: String) {
        const body = { filename: file };

        return this.http.post(this.prefixRestUrl + 'rest/file/download', body, {
            responseType: 'blob',
            headers: new HttpHeaders().append('Content-Type', 'application/json')
        });
    }

    public uploadFile(formData): Observable<any> {
        // let httpHeader = new HttpHeaders({
        //     'Content-Type': 'multipart/form-data'
        // });
        // let httpOptions = {
        //     headers: httpHeader
        // };
        return this.http.post(this.prefixRestUrl + 'rest/file/upload', formData).pipe();
    }
}
