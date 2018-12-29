import { ParentObject } from '../../object/parent-object';
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';
import { CourseStudentObject } from 'src/app/object/course-student-detail-object';

@Injectable({ providedIn: 'root' })
export class CourseStudentService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getScoreboardByStudent(studentId): Observable<any> {
        const params = new HttpParams()
            .set('studentId', studentId.toString());
        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<any>(this.prefixRestUrl + 'rest/course-student-detail/get-all-by-student', httpOptions).pipe();
    }

    getAllByCourse(searchKeyword, courseId): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        const data = {
            searchKeyword: searchKeyword,
            courseId: courseId
        };
        return this.http.post(this.prefixRestUrl + 'rest/course-student-detail/get-all-by-course', data, httpOptions).pipe();
    }

    insertCourseStudent(courseStudent: CourseStudentObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/course-student-detail/insert', courseStudent, { headers: this.httpHeader });
    }
    updateCourseStudent(courseStudent: CourseStudentObject): Observable<any> {
        return this.http.post(this.prefixRestUrl + 'rest/course-student-detail/update', courseStudent, { headers: this.httpHeader });
    }

    deleteCourseStudent(courseStudentId: number): Observable<any> {
        const params = new HttpParams()
            .set('courseStudentId', courseStudentId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/course-student-detail/delete', httpOptions).pipe();
    }
}

