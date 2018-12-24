import { Injector } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { StorageService } from 'src/app/services/storage.service';


export class BaseService {
  // public prefixRestUrl = 'http://localhost:50734';
  public prefixRestUrl = 'http://quanlylophoc.tk';
  protected readonly httpHeader;
  public storageService: StorageService;
  constructor(public injector: Injector) {
    this.storageService = this.injector.get(StorageService);
    let token: string;
    token = this.storageService.getUserToken();
    // this.httpHeader = new HttpHeaders()
    //   .append('Content-Type', 'application/json')
    //   .append('Authentication', 'Bearer ' + token);
    this.httpHeader = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authentication': 'Bearer ' + token
    });
  }
}
