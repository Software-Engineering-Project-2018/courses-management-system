import { CourseObject } from '../../object/course-object';
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';

@Injectable({ providedIn: 'root' })
export class CourseService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getAllCourseJoined(searchKeyword, studentId): Observable<any> {

        const httpOptions = {
            headers: this.httpHeader
        };
        const params = {
            searchKeyword: searchKeyword,
            studentId: studentId
        };
        return this.http.post(this.prefixRestUrl + 'rest/course/get-all-joined', params, httpOptions).pipe();
    }

    getAllCourseNotJoined(searchKeyword, studentId): Observable<any> {

        const httpOptions = {
            headers: this.httpHeader
        };
        const params = {
            searchKeyword: searchKeyword,
            studentId: studentId
        };
        return this.http.post(this.prefixRestUrl + 'rest/course/get-all-not-joined', params, httpOptions).pipe();
    }


    getOneCourse(hocSinhId: number): Observable<CourseObject> {
        const params = new HttpParams()
            .set('courseId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<CourseObject>(this.prefixRestUrl + 'rest/course/get', httpOptions).pipe();
    }

    insertCourse(course: CourseObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/course/insert', course);
    }

    updateCourse(course: CourseObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/course/update', course, httpOptions);
    }

    deleteOneCourse(hocSinhId: number): Observable<any> {
        const params = new HttpParams()
            .set('CourseId', hocSinhId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/course/delete', httpOptions).pipe();
    }

    getCourseByStudent(studentId): Observable<CourseObject[]> {
        const params = new HttpParams()
            .set('studentId', studentId);

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<CourseObject[]>(this.prefixRestUrl + 'rest/course/get-by-student-id', httpOptions).pipe();
    }

    getCourseByTeacher(teacherId, searchKeyword): Observable<any> {
        const data = {
            teacherId: teacherId,
            searchKeyword: searchKeyword
        };

        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/course/get-by-teacher-id', data, httpOptions).pipe();
    }
}

