import { OnInit, Injector, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { UserObject } from 'src/app/object/user-object';
import { StorageService } from 'src/app/services/storage.service';
import { AuthService } from 'src/app/services/auth.service';
import { EventEmiterService } from 'src/app/services/event.emmiter.service';
import { BaseService } from './base.service';

export abstract class BaseComponent implements OnInit {

  dirPath = 'http://localhost:50734/File/Data/';
  // public prefixRestUrl = 'http://quanlylophoc.tk//File//Data//';
  // reCapchaKey release
  reCapchaKey = '6Le5JYMUAAAAAAsRXUGY2wnnEBXcuQV_THAvTxIx';
  // reCapchaKey debugging
  // reCapchaKey = '6LcOuyYTAAAAAHTjFuqhA52fmfJ_j5iFk5PsfXaU';

  defaultAvatar = 'assets/noavatar.png';
  protected router: Router;
  UserLogin: UserObject;
  isLoading = false;
  public routerSubscribe: any;
  protected eventEmiter: EventEmiterService;
  public localStorageService: StorageService;
  public authenticationService: AuthService;
  constructor(injector: Injector) {
    this.router = injector.get(Router);
    this.localStorageService = injector.get(StorageService);
    this.authenticationService = injector.get(AuthService);
    this.eventEmiter = injector.get(EventEmiterService);
    this.UserLogin = this.getUserLogin();
  }

  ngOnInit() {
  }

  getUserLogin(): any {
    return this.localStorageService.getUserInfo();
  }

  isManagerLogin(): boolean {
    return this.UserLogin.UserType === 1;
  }

  isTeacherLogin(): boolean {
    return this.UserLogin.UserType === 2;
  }

  isStudentLogin(): boolean {
    return this.UserLogin.UserType === 3;
  }

  isParentLogin(): boolean {
    return this.UserLogin.UserType === 4;
  }

  startLoadingUi(): void {
    this.isLoading = true;
    this.pickLoadingStatus(this.isLoading);
  }

  stopLoadingUi(): void {
    this.isLoading = false;
    this.pickLoadingStatus(this.isLoading);
  }

  public pickLoadingStatus(isLoading: any): void {
    this.eventEmiter.emitChange(isLoading);
  }

  public logOut() {
    this.localStorageService.removeUserToken();
    this.localStorageService.removeUserInfo();
  }
}
