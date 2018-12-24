import { OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';

export abstract class NotificationListComponent extends BaseComponent implements OnInit {

  public title = 'Thông báo';

  searchKeyword = '';
  // parentService: parentService;
  public notificationList: Notification[];
  constructor(injector: Injector) {
    super(injector);
    // this.parentService = injector.get(parentService)
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    // this.studentService.getAllStudent(this.searchKeyword).subscribe(
    //   response => {
    //     this.studentSelected = response;
    this.stopLoadingUi();
    //   });
  }

  searchOnclick() {
    this.getData();
  }
  notificationInfoOnClick(parentId) {
    this.router.navigate(['/dashboard/notification-info']);
  }
}
