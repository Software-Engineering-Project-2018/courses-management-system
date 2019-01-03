import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { CourseObject } from 'src/app/object/course-object';
import { CourseService } from 'src/app/services/data-services/course.service';
import { CourseListComponent } from './course-list.component';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-my-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class MyCourseListComponent extends CourseListComponent {

  // screenName = 'my-course-list';
  constructor(injector: Injector, fb: FormBuilder) {
    super(injector, fb);
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      if (this.UserLogin.UserType === 3) {
        this.courseService.getAllCourseJoined(this.searchKeyword, this.UserLogin.UserId).subscribe(
          response => {
            this.courseJoinedList = response;
            this.courseJoinedList.forEach(item => {
              this.teacherService.getAllTeacherByCourse(item.CourseId, '').subscribe(
                result => {
                  item.TeacherList = result;
                  this.stopLoadingUi();
                }
              );
            });
          },
          error => {
            console.error(error);
            this.stopLoadingUi();
          });
      } else if (this.UserLogin.UserType === 2) {
        this.courseService.getCourseByTeacher(this.searchKeyword, this.UserLogin.UserId).subscribe(
          response => {
            this.courseJoinedList = response;
            this.courseJoinedList.forEach(item => {
              this.teacherService.getAllTeacherByCourse(item.CourseId, '').subscribe(
                result => {
                  item.TeacherList = result;
                  this.stopLoadingUi();
                }
              );
            });
          },
          error => {
            console.error(error);
            this.stopLoadingUi();
          });
      }
    }, 500);
  }

}
