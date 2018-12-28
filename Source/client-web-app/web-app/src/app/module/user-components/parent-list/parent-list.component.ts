import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { ParentObject } from 'src/app/object/parent-object';
import { ParentService } from 'src/app/services/data-services/parent.service';

@Component({
  selector: 'app-parent-list',
  templateUrl: './parent-list.component.html',
  styleUrls: ['./parent-list.component.css']
})
export class ParentListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  parentService: ParentService;
  public parentList: ParentObject[];
  constructor(injector: Injector) {
    super(injector);
    this.parentService = injector.get(ParentService);
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.parentService.getAllParent(this.searchKeyword).subscribe(
        response => {
          this.parentList = response;
          this.stopLoadingUi();
        },
        error => {
          console.error(error);
          this.stopLoadingUi();
        });
    }, 500);
  }

  searchOnclick() {
    this.getData();
  }

  userInfoOnClick(parentId) {
    this.router.navigate(['/dashboard/user-info']);
  }

  childInfoOnClick(parentId) {
    this.router.navigate(['/dashboard/user-info']);
  }
}
