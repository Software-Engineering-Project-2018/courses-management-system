import { Component, OnInit, Injector } from '@angular/core';
import { TeacherObject } from 'src/app/object/Teacher-object';
import { TeacherService } from 'src/app/services/data-services/teacher.service';
import { BaseComponent } from '../../base/base.component';
import { CourseTeacherObject } from 'src/app/object/course-teacher-detail-object';
import { CourseTeacherService } from 'src/app/services/data-services/course-teacher.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-teacher-list',
  templateUrl: './course-teacher-list.component.html',
  styleUrls: ['./course-teacher-list.component.css'],
  providers: [TeacherService]
})
export class CourseTeacherListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  courseId: number;
  public courseTeacherList: CourseTeacherObject[];
  constructor(injector: Injector,
    private route: ActivatedRoute,
    private courseTeacherService: CourseTeacherService) {
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
        this.courseTeacherService.getAllByCourse(this.searchKeyword, this.courseId).subscribe(
          response => {
            this.courseTeacherList = response;
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

  userInfoOnClick(TeacherId) {
    this.router.navigate(['/dashboard/user-info',
      {
        userType: [3],
        userId: [TeacherId]
      }]);
  }
}
