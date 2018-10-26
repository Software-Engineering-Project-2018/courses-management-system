// Import thư viện
import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';

// Import lớp cha
import { BaseService } from './base.service';

// Import đối tượng học sinh
import { HocSinhObject } from '../object/hoc-sinh-object';


@Injectable()
export class HocSinhService extends BaseService {
    // private headerOptions: any;
    private http: Http;
    constructor() {
        super();
        // this.headerOptions = {
        //     headers: new Headers({
        //         'Content-Type': 'application/json'
        //     })
        // };
    }

    getAllHocSinh() {

    }

    getOneHocSinh(id: number): any {
        return this.http.get('localhost:51284/api/HocSinhs/' + id.toString());
    }

}
