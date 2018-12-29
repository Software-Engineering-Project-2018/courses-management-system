import { OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { NotificationService } from 'src/app/services/data-services/notification.service';
import { NotificationObject } from 'src/app/object/notification-object';

export abstract class NotificationListComponent extends BaseComponent implements OnInit {

  public title = 'Thông báo';

  searchKeyword = '';
  notificationService: NotificationService;
  public notificationList: NotificationObject[];
  constructor(injector: Injector) {
    super(injector);
    this.notificationService = injector.get(NotificationService);
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
  }

  searchOnclick() {
    this.getData();
  }

  notificationInfoOnClick(parentId) {
    this.router.navigate(['/dashboard/notification-info']);
  }
}
