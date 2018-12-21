import { OnInit, Injector, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { UserObject } from 'src/app/object/user-object';
import { StorageService } from 'src/app/services/storage.service';
import { AuthService } from 'src/app/services/auth.service';
import { EventEmiterService } from 'src/app/services/event.emmiter.service';

export abstract class BaseComponent implements OnInit {

  // reCapchaKey release
  reCapchaKey = '6Le5JYMUAAAAAAsRXUGY2wnnEBXcuQV_THAvTxIx';
  // reCapchaKey debugging
  // reCapchaKey = '6LcOuyYTAAAAAHTjFuqhA52fmfJ_j5iFk5PsfXaU';

  defaultAvatar = 'assets/noavatar.png';
  protected router: Router;
  UserLogin: UserObject;
  isLoading = false;
  protected eventEmiter: EventEmiterService;
  public localStorageService: StorageService;
  public authenticationService: AuthService;
  constructor(injector: Injector) {
    this.router = injector.get(Router);
    this.localStorageService = injector.get(StorageService);
    this.authenticationService = injector.get(AuthService);
    this.eventEmiter = injector.get(EventEmiterService);
  }

  ngOnInit() {
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
  }
}
