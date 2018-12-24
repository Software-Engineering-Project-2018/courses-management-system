import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { ParentObject } from 'src/app/object/parent-object';

@Component({
  selector: 'app-parent-list',
  templateUrl: './parent-list.component.html',
  styleUrls: ['./parent-list.component.css']
})
export class ParentListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  // parentService: parentService;
  public parentList: ParentObject[];
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
  userInfoOnClick(parentId) {
    this.router.navigate(['/dashboard/user-info']);
  }
  childInfoOnClick(parentId) {
    this.router.navigate(['/dashboard/user-info']);
  }
}
