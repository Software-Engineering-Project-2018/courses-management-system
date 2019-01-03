import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { CourseObject } from 'src/app/object/course-object';
import { CourseService } from 'src/app/services/data-services/course.service';
import { CourseListComponent } from './course-list.component';
import { FormBuilder } from '@angular/forms';
import { TeacherObject } from 'src/app/object/teacher-object';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-teacher-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class TeacherCourseListComponent extends CourseListComponent implements OnInit {

  constructor(injector: Injector, fb: FormBuilder,
    private route: ActivatedRoute) {
    super(injector, fb);
  }
  teacherId: number;

  ngOnInit() {
    this.routerSubscribe = this.route.params.subscribe(params => {
      const teacherId = params['teacherId'];
      if (teacherId) {
        this.teacherId = teacherId;
        this.getData();
      }
    });
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.courseService.getCourseByTeacher(this.teacherId, this.searchKeyword).subscribe(
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
    }, 500);
  }

}
