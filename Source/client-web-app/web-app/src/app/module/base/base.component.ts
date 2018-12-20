import { OnInit, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { UserObject } from 'src/app/object/user-object';
import { StorageService } from 'src/app/services/storage.service';
import { AuthService } from 'src/app/services/auth.service';

export abstract class BaseComponent implements OnInit {

  // reCapchaKey release
  reCapchaKey = '6Le5JYMUAAAAAAsRXUGY2wnnEBXcuQV_THAvTxIx';
  // reCapchaKey debugging
  // reCapchaKey = '6LcOuyYTAAAAAHTjFuqhA52fmfJ_j5iFk5PsfXaU';

  defaultAvatar = 'assets/noavatar.png';
  protected router: Router;
  UserLogin: UserObject;

  public localStorageService: StorageService;
  public authenticationService: AuthService;
  constructor(injector: Injector) {
    this.router = injector.get(Router);
    this.localStorageService = injector.get(StorageService);
    this.authenticationService = injector.get(AuthService);
  }

  ngOnInit() {
  }

  public logOut() {
    this.localStorageService.removeUserToken();
  }
}
