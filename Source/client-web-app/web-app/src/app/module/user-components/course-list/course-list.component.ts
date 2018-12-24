import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { CourseObject } from 'src/app/object/course-object';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  public courseList: CourseObject[];
  constructor(injector: Injector) {
    super(injector);
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    // this.studentService.getAllStudent(this.searchKeyword).subscribe(
    //   response => {
    //     this.studentList = response;
    this.stopLoadingUi();
    // });
  }

  searchOnclick() {
    this.getData();
  }
  courseInfoOnClick(courseId) {
    this.router.navigate(['/dashboard/course-info']);
  }
  enrollCourseOnClick(courseId) {
    this.router.navigate(['/dashboard/enroll-course']);
  }
}
