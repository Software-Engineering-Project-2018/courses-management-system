import { CourseObject } from '../../object/course-object';
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';

@Injectable({ providedIn: 'root' })
export class SystemService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    register(user): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/systems/register', user);
    }
}

