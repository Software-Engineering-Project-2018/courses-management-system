import { Component, OnInit, Injector } from '@angular/core';
import { StudentObject } from 'src/app/object/student-object';
import { StudentService } from 'src/app/services/data-services/student.service';
import { BaseComponent } from '../../base/base.component';
import { CourseStudentObject } from 'src/app/object/course-student-detail-object';
import { CourseStudentService } from 'src/app/services/data-services/course-student.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-student-list',
  templateUrl: './course-student-list.component.html',
  styleUrls: ['./course-student-list.component.css'],
  providers: [StudentService]
})
export class CourseStudentListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  courseId: number;
  public courseStudentList: CourseStudentObject[];
  constructor(injector: Injector,
    private route: ActivatedRoute,
    private courseStudentService: CourseStudentService) {
    super(injector);
    this.getData();
  }
  ngOnInit() {
    this.routerSubscribe = this.route.params.subscribe(params => {
      const courseId = params['courseId'];
      if (courseId) {
        this.courseId = courseId;
        this.getData();
      }
    });
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      if (this.courseId) {
        this.courseStudentService.getAllByCourse(this.searchKeyword, this.courseId).subscribe(
          response => {
            this.courseStudentList = response;
            this.stopLoadingUi();
          },
          error => {
            console.error(error);
            this.stopLoadingUi();
          });
      }
      this.stopLoadingUi();
    }, 500);
  }

  searchOnclick() {
    this.getData();
  }

  userInfoOnClick(studentId) {
    this.router.navigate(['/dashboard/user-info',
      {
        userType: [3],
        userId: [studentId]
      }]);
  }
}
