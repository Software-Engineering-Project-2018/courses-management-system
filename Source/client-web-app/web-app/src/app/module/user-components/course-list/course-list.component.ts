import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { CourseObject } from 'src/app/object/course-object';
import { CourseService } from 'src/app/services/data-services/course.service';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  // screenName = 'course-list';
  courseService: CourseService;
  public courseJoinedList: CourseObject[] = [];
  public courseNotJoinedList: CourseObject[] = [];
  constructor(injector: Injector) {
    super(injector);
    this.courseService = injector.get(CourseService);
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.courseService.getAllCourseJoined(this.searchKeyword, this.UserLogin.UserId).subscribe(
        response1 => {
          this.courseJoinedList = response1;
          this.courseService.getAllCourseNotJoined(this.searchKeyword, this.UserLogin.UserId).subscribe(
            response2 => {
              this.courseNotJoinedList = response2;
              this.stopLoadingUi();
            },
            error => {
              console.error(error);
              this.stopLoadingUi();
            });
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

  courseInfoOnClick(courseId) {
    this.router.navigate(['/dashboard/course-info',
      {
        courseId: [courseId]
      }]);
  }

  teacherInfoOnClick(teacherId) {
    this.router.navigate(['/dashboard/user-info',
      {
        userType: [2],
        userId: [1]
      }]);
  }

  enrollCourseOnClick(courseId) {
    this.router.navigate(['/dashboard/enroll-course',
      {
        courseId: [courseId]
      }]);
  }
}
