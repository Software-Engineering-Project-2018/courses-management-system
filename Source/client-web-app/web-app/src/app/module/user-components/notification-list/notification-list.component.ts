import { OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';

export abstract class NotificationListComponent extends BaseComponent implements OnInit {

  public title = 'Thông báo';
  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInit() {
  }

  onClickSearchIcon() {
  }
}
