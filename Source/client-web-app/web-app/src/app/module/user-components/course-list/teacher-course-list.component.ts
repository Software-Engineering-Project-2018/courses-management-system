import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { CourseObject } from 'src/app/object/course-object';
import { CourseService } from 'src/app/services/data-services/course.service';
import { CourseListComponent } from './course-list.component';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-teacher-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class TeacherCourseListComponent extends CourseListComponent {

  constructor(injector: Injector, fb: FormBuilder) {
    super(injector, fb);
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.courseService.getCourseByTeacher(this.UserLogin.UserId, this.searchKeyword).subscribe(
        response => {
          this.courseJoinedList = response;
          this.stopLoadingUi();
        },
        error => {
          console.error(error);
          this.stopLoadingUi();
        });
    }, 500);
  }

}
