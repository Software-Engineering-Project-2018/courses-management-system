import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { CourseObject } from 'src/app/object/course-object';
import { CourseService } from 'src/app/services/data-services/course.service';
import { ActivatedRoute } from '@angular/router';
import { CourseStudentObject } from 'src/app/object/course-student-detail-object';
import { CourseStudentService } from 'src/app/services/data-services/course-student.service';

@Component({
  selector: 'app-enroll-course',
  templateUrl: './enroll-course.component.html',
  styleUrls: ['./enroll-course.component.css']
})
export class EnrollCourseComponent extends BaseComponent implements OnInit {

  courseInfo: CourseObject;
  courseService: CourseService;
  courseStudentService: CourseStudentService;
  constructor(injector: Injector,
    private route: ActivatedRoute) {
    super(injector);
    this.courseService = injector.get(CourseService);
    this.courseStudentService = injector.get(CourseStudentService);
  }

  ngOnInit() {
    this.courseInfo = new CourseObject();
    this.routerSubscribe = this.route.params.subscribe(params => {
      const courseId = params['courseId'];
      if (courseId) {
        this.courseInfo.CourseId = courseId;
        this.getData();
      }
    });
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.courseService.getOneCourse(this.courseInfo.CourseId).subscribe(
        result => {
          this.courseInfo = result;
          this.stopLoadingUi();
        },
        error => {
          console.error(error);
          this.stopLoadingUi();
        }
      );

    }, 500);
  }

  enrollCourseOnClick() {
    this.startLoadingUi();
    let courseStudent: CourseStudentObject;
    courseStudent = new CourseStudentObject();
    courseStudent.Student.UserId = this.UserLogin.UserId;
    courseStudent.Course.CourseId = this.courseInfo.CourseId;
    this.courseStudentService.insertCourseStudent(courseStudent).subscribe(
      result => {
        alert('Đăng ký khóa học thành công!');
        this.router.navigate(['/dashboard/course-info',
          {
            courseId: [result.Course.CourseId]
          }]);
      },
      error => {
        console.error(error);
        this.stopLoadingUi();
      }
    );
  }
}
