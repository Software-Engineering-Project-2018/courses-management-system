import { Component, OnInit, Injector } from '@angular/core';
import { NotificationListComponent } from './notification-list.component';

@Component({
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.css']
})
export class CourseNotificationListComponent extends NotificationListComponent {

  public title = 'Thông báo khóa học';
  constructor(injector: Injector) {
    super(injector);
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.notificationService.getAllCourseNotification(this.searchKeyword).subscribe(
        response => {
          this.notificationList = response;
          this.stopLoadingUi();
        },
        error => {
          console.error(error);
          this.stopLoadingUi();
        });
    }, 500);
  }
}
