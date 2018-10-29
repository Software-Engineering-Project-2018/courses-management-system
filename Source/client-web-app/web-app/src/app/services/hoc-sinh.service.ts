// // Import thư viện
// import { Injectable } from '@angular/core';
// import { Http, Response, Headers } from '@angular/http';
// import { Observable } from 'rxjs/internal/Observable';
// import { map } from 'rxjs/operators';

// // Import lớp cha
// import { BaseService } from './base.service';

// // Import đối tượng học sinh
import { HocSinhObject } from '../object/hoc-sinh-object';


// @Injectable()
// export class HocSinhService extends BaseService {
//     private headerOptions: any;
//     protected readonly httpHeader;
//     private http: Http;
//     constructor() {
//         super();
//         this.headerOptions = {
//             headers: new Headers({
//                 'Content-Type': 'application/json'
//             })
//         };
//     }

//     getAllHocSinh(): any {
//         return this.http.get('http://localhost:56697/rest/hoc-sinh/get-all/');
//     }

//     getOneHocSinh(id: number): any {
//     }

// }


import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class HocSinhService {
    private headerOptions: any;
    protected readonly httpHeader;
    // private http: Http;
    constructor(private http: HttpClient) {
        // super();
        this.headerOptions = {
            headers: new Headers({
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            })
        };
    }
    configUrl = 'http://www.stem.somee.com/rest/hoc-sinh/get-all';

    getAllHocSinh(): Observable<HocSinhObject[]> {
        return this.http.get<HocSinhObject[]>(this.configUrl).pipe();
    }
}

