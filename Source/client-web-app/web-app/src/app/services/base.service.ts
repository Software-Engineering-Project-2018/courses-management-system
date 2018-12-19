import { StorageService } from './storage.service';
import { Injector } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';


export class BaseService {
  // public prefixRestUrl = 'http://localhost:50734';
  public prefixRestUrl = 'https://quanlylophoc.tk';
  protected readonly httpHeader;
  public storageService: StorageService;
  constructor(public injector: Injector) {
    this.storageService = this.injector.get(StorageService);
    let token: string;
    token = this.storageService.getUserToken();
    this.httpHeader = new HttpHeaders();
    this.httpHeader.append('Content-Type', 'application/json');
    this.httpHeader.append('Authentication', 'Bearer ' + token);
    // this.headerOptions = {
    //   headers: new Headers({
    //     'Content-Type': 'application/json',
    //     'Authentication': 'bearer ' + token
    //     // 'Access-Control-Allow-Origin': '*'
    //   })
    // };
  }
}
