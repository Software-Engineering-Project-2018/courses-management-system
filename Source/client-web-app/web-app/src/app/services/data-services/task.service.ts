
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';
import { TaskObject } from 'src/app/object/task-object';

@Injectable({ providedIn: 'root' })
export class TaskService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getAllTask(courseId): Observable<TaskObject[]> {
        const params = new HttpParams()
            .set('courseId', courseId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<TaskObject[]>(this.prefixRestUrl + 'rest/task/get-all', httpOptions).pipe();
    }

    getOneTask(taskId: number): Observable<TaskObject> {
        const params = new HttpParams()
            .set('taskId', taskId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<TaskObject>(this.prefixRestUrl + 'rest/task/get', httpOptions).pipe();
    }

    insertTask(task: TaskObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/task/insert', task);
    }

    updateTask(task: TaskObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/task/update', task, httpOptions);
    }

    deleteOneTask(taskId: number): Observable<any> {
        const params = new HttpParams()
            .set('taskId', taskId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/task/delete', httpOptions).pipe();
    }
}

