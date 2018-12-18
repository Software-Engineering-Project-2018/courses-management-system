import { Component, OnInit, Injector } from '@angular/core';
import { NotificationListComponent } from './notification-list.component';

@Component({
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.css']
})
export class GeneralNotificationListComponent extends NotificationListComponent {

  public title = 'Thông báo chung';
  constructor(injector: Injector) {
    super(injector);
  }

}
