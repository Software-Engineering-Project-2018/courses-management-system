import { OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { NotificationService } from 'src/app/services/data-services/notification.service';
import { NotificationObject } from 'src/app/object/notification-object';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

export abstract class NotificationListComponent extends BaseComponent implements OnInit {

  public title = 'Thông báo';

  // Form data
  public notificationInfo = new NotificationObject();
  notificationInfoForm: FormGroup;

  searchKeyword = '';
  notificationService: NotificationService;
  public notificationList: NotificationObject[];
  constructor(injector: Injector, fb: FormBuilder) {
    super(injector);
    this.notificationService = injector.get(NotificationService);
    this.getData();

    this.notificationInfoForm = fb.group({
      'notificationName': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(100)])],
      'notificationDateCreate': [null, Validators.required],
      'notificationContent': [null, Validators.required],
      'notificationType': [null, Validators.required]
    });
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
  insertNotificationOnClick() { }
}
