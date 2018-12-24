import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { TeacherObject } from 'src/app/object/teacher-object';

@Component({
  selector: 'app-teacher-list',
  templateUrl: './teacher-list.component.html',
  styleUrls: ['./teacher-list.component.css']
})
export class TeacherListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  // teacherService: TeacherService;
  public teacherList: TeacherObject[];
  constructor(injector: Injector) {
    super(injector);
    // this.teacherService = injector.get(TeacherService)
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
  userInfoOnClick(studentId) {
    this.router.navigate(['/dashboard/user-info']);
  }
  listCourseOnClick(studentId) {
    this.router.navigate(['/dashboard/courses']);
  }
}
