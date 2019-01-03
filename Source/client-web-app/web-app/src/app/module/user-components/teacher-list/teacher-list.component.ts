import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { TeacherObject } from '../../../object/teacher-object';
import { TeacherService } from '../../../services/data-services/teacher.service';

@Component({
  selector: 'app-teacher-list',
  templateUrl: './teacher-list.component.html',
  styleUrls: ['./teacher-list.component.css']
})
export class TeacherListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  teacherService: TeacherService;
  public teacherList: TeacherObject[];
  constructor(injector: Injector) {
    super(injector);
    this.teacherService = injector.get(TeacherService);
    this.getData();
  }

  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.teacherService.getAllTeacher(this.searchKeyword).subscribe(
        response => {
          this.teacherList = response;
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

  userInfoOnClick(teacherId) {
    this.router.navigate(['/dashboard/user-info',
      {
        userType: [2],
        userId: [teacherId]
      }]);
  }
  listCourseOnClick(studentId) {
    this.router.navigate(['/dashboard/courses']);
  }
}
