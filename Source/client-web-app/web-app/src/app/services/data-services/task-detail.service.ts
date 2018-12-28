
import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/module/base/base.service';
import { TaskDetailObject } from 'src/app/object/task-detail-object';

@Injectable({ providedIn: 'root' })
export class TaskDetailService extends BaseService {
    // private http: Http;
    constructor(public injector: Injector, private http: HttpClient) {
        super(injector);
    }

    getOneTaskDetail(taskDetailId: number): Observable<TaskDetailObject> {
        const params = new HttpParams()
            .set('taskDetailId', taskDetailId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.get<TaskDetailObject>(this.prefixRestUrl + 'rest/task-detail/get', httpOptions).pipe();
    }

    insertTaskDetail(taskDetail: TaskDetailObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/task-detail/insert', taskDetail);
    }

    updateTaskDetail(taskDetail: TaskDetailObject): Observable<any> {
        const httpOptions = {
            headers: this.httpHeader
        };
        return this.http.post(this.prefixRestUrl + 'rest/task-detail/update', taskDetail, httpOptions);
    }

    deleteOneTaskDetail(taskDetailId: number): Observable<any> {
        const params = new HttpParams()
            .set('taskDetailId', taskDetailId.toString());

        const httpOptions = {
            headers: this.httpHeader,
            params: params
        };
        return this.http.delete(this.prefixRestUrl + 'rest/task-detail/delete', httpOptions).pipe();
    }
}

