import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { NotificationObject } from 'src/app/object/notification-object';
import { NotificationService } from 'src/app/services/data-services/notification.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-notification-info',
  templateUrl: './notification-info.component.html',
  styleUrls: ['./notification-info.component.css']
})
export class NotificationInfoComponent extends BaseComponent implements OnInit {

  notificationInfo: NotificationObject;
  notificationService: NotificationService;

  constructor(injector: Injector,
    private route: ActivatedRoute) {
    super(injector);
    this.notificationService = injector.get(NotificationService);
  }

  ngOnInit() {
    this.notificationInfo = new NotificationObject();
    this.routerSubscribe = this.route.params.subscribe(params => {
      const notificationId = params['notificationId'];
      if (notificationId) {
        this.notificationInfo.NotificationId = notificationId;
        this.getData();
      }
    });
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.notificationService.getOneNotification(this.notificationInfo.NotificationId).subscribe(
        result1 => {
          this.notificationInfo = result1;
          this.stopLoadingUi();
        },
        error1 => {
          console.log(error1);
          this.stopLoadingUi();
        }
      );

    }, 500);
  }

}
