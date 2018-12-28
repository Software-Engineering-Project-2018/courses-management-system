import { TeacherObject } from '../../object/teacher-object';
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';

@Injectable({ providedIn: 'root' })
export class TeacherService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getAllTeacher(searchKeyword): Observable<TeacherObject[]> {
        const params = new HttpParams()
            .set('searchKeyword', searchKeyword.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<TeacherObject[]>(this.prefixRestUrl + 'rest/teacher/get-all', httpOptions).pipe();
    }

    getOneTeacher(hocSinhId: number): Observable<TeacherObject> {
        const params = new HttpParams()
            .set('TeacherId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<TeacherObject>(this.prefixRestUrl + 'rest/teacher/get', httpOptions).pipe();
    }

    insertTeacher(teacher: TeacherObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/teacher/insert', teacher, { headers: this.httpHeader });
    }

    updateTeacher(teacher: TeacherObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/teacher/update', teacher, { headers: this.httpHeader });
    }

    deleteOneTeacher(hocSinhId: number): Observable<any> {
        const params = new HttpParams()
            .set('teacherId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/teacher/delete', httpOptions).pipe();
    }
}

