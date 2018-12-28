import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';

@Component({
  selector: 'app-setting',
  templateUrl: './setting.component.html',
  styleUrls: ['./setting.component.css']
})
export class SettingComponent extends BaseComponent implements OnInit {

  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInit() {
  }


  logOutOnClick() {
    this.logOut();
    this.router.navigate(['/']);
  }
}
