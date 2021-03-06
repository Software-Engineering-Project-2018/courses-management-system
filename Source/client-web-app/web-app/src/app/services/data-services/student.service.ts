import { StudentObject } from '../../object/student-object';
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';

@Injectable({ providedIn: 'root' })
export class StudentService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getAllStudent(searchKeyword): Observable<StudentObject[]> {
        const params = new HttpParams()
            .set('searchKeyword', searchKeyword.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<StudentObject[]>(this.prefixRestUrl + 'rest/student/get-all', httpOptions).pipe();
    }

    getAllStudentByParent(parentId): Observable<StudentObject[]> {
        const params = new HttpParams()
            .set('parentId', parentId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<StudentObject[]>(this.prefixRestUrl + 'rest/student/get-by-parent', httpOptions).pipe();
    }

    getAllStudentByCourse(courseId, searchKeyword): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        const data = {
            courseId: courseId,
            searchKeyword: searchKeyword
        };
        return this.http.post(this.prefixRestUrl + 'rest/student/get-by-course', data, httpOptions).pipe();
    }

    getOneStudent(hocSinhId: number): Observable<StudentObject> {
        const params = new HttpParams()
            .set('studentId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<StudentObject>(this.prefixRestUrl + 'rest/student/get', httpOptions).pipe();
    }

    insertStudent(student: StudentObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/student/insert', student);
    }

    updateStudent(student: StudentObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/student/update', student, httpOptions);
    }

    deleteOneStudent(hocSinhId: number): Observable<any> {
        const params = new HttpParams()
            .set('studentId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/student/delete', httpOptions).pipe();
    }
}

