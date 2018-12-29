import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { CourseObject } from 'src/app/object/course-object';
import { CourseService } from 'src/app/services/data-services/course.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  // screenName = 'course-list';
  courseService: CourseService;

  // Form data
  public courseInfo = new CourseObject();
  courseInfoForm: FormGroup;

  public courseJoinedList: CourseObject[] = [];
  public courseNotJoinedList: CourseObject[] = [];
  constructor(injector: Injector, fb: FormBuilder) {
    super(injector);
    this.courseService = injector.get(CourseService);
    this.getData();

    this.courseInfoForm = fb.group({
      'courseName': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(100)])],
      'dateStart': [null, Validators.required],
      'dateEnd': [null, Validators.required],
      'tutition': [null, Validators.required],
      'courseIntro': [null],
      'courseLinkRef': [null]
    });
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

  insertCourseOnClick() {
    this.courseService.insertCourse(this.courseInfo).subscribe(
      result => {
        alert('Thêm khóa học thành công!');
        this.courseNotJoinedList.unshift(result);
      },
      error => {
        console.log(error);
      }
    )
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

  courseStudentListOnClick(courseId) {
    this.router.navigate(['/dashboard/course-students',
      {
        courseId: [courseId]
      }]);
  }
}
