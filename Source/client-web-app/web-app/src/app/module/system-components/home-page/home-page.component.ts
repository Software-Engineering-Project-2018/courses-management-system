import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent extends BaseComponent implements OnInit {

  isLoginIn = false;
  constructor(injector: Injector) {
    super(injector);
    this.isLoginIn = this.authenticationService.isLoggedIn();
  }

  ngOnInit() {
  }
  logOutOnClick() {
    this.logOut();
    this.isLoginIn = this.authenticationService.isLoggedIn();
    this.router.navigate(['/']);
  }
}
