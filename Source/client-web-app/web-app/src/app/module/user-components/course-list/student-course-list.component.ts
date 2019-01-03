import { Component, OnInit, Injector } from '@angular/core';
import { CourseListComponent } from './course-list.component';
import { FormBuilder } from '@angular/forms';
import { StudentObject } from 'src/app/object/student-object';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-teacher-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class StudentCourseListComponent extends CourseListComponent implements OnInit {

  constructor(injector: Injector, fb: FormBuilder,
    private route: ActivatedRoute) {
    super(injector, fb);
  }
  studentId: number;

  ngOnInit() {
    this.routerSubscribe = this.route.params.subscribe(params => {
      const studentId = params['studentId'];
      if (studentId) {
        this.studentId = studentId;
        this.getData();
      }
    });
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      if (this.studentId) {
        this.courseService.getAllCourseJoined(this.searchKeyword, this.studentId).subscribe(
          response1 => {
            this.courseJoinedList = response1;
            this.courseJoinedList.forEach(item => {
              this.teacherService.getAllTeacherByCourse(item.CourseId, '').subscribe(
                result => {
                  item.TeacherList = result;
                  this.stopLoadingUi();
                }
              );
            });
            this.stopLoadingUi();
          },
          error => {
            console.error(error);
            this.stopLoadingUi();
          });
      }
      this.startLoadingUi();
    }, 500);
  }


}
