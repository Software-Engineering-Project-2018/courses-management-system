import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { ActivatedRoute } from '@angular/router';
import { UserObject } from 'src/app/object/user-object';
import { StudentService } from 'src/app/services/data-services/student.service';
import { TeacherService } from 'src/app/services/data-services/teacher.service';
import { ParentService } from 'src/app/services/data-services/parent.service';
import { ManagerService } from 'src/app/services/data-services/manager.service';
import { CourseService } from 'src/app/services/data-services/course.service';
import { CourseObject } from 'src/app/object/course-object';
import { ParentObject } from 'src/app/object/parent-object';
import { StudentObject } from 'src/app/object/student-object';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent extends BaseComponent implements OnInit {

  userInfo: any;
  courseList: CourseObject[];
  parentList: ParentObject[];
  childrenList: StudentObject[];
  studentService: StudentService;
  teacherService: TeacherService;
  parentService: ParentService;
  managerService: ManagerService;
  courseService: CourseService;
  constructor(injector: Injector,
    private route: ActivatedRoute) {
    super(injector);
    this.teacherService = injector.get(TeacherService);
    this.studentService = injector.get(StudentService);
    this.parentService = injector.get(ParentService);
    this.managerService = injector.get(ManagerService);
    this.courseService = injector.get(CourseService);
    this.courseList = [];
    this.parentList = [];
    this.childrenList = [];
  }

  ngOnInit() {
    this.userInfo = new UserObject();
    this.routerSubscribe = this.route.params.subscribe(params => {
      const userType = params['userType'];
      if (userType) {
        this.userInfo.UserType = userType;
      }
      const userId = params['userId'];
      if (userId) {
        this.userInfo.UserId = userId;
      }

      this.getData();
    });
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      switch (+this.userInfo.UserType) {
        case 1:
          this.managerService.getOneManager(this.userInfo.UserId).subscribe(
            result => {
              this.userInfo = result;
              this.stopLoadingUi();
            }
          );
          break;
        case 2:
          this.teacherService.getOneTeacher(this.userInfo.UserId).subscribe(
            result => {
              this.userInfo = result;
              this.courseService.getCourseByTeacher(this.userInfo.UserId, '').subscribe(
                result2 => {
                  this.courseList = result2;
                  this.stopLoadingUi();
                });
              this.stopLoadingUi();
            }
          );
          break;
        case 3:
          this.studentService.getOneStudent(this.userInfo.UserId).subscribe(
            result => {
              this.userInfo = result;
              this.courseService.getAllCourseJoined('', this.userInfo.UserId).subscribe(
                result2 => {
                  this.courseList = result2;
                  this.parentService.getAllParentByStudent(this.userInfo.UserId).subscribe(
                    result3 => {
                      this.parentList = result3;
                      this.stopLoadingUi();
                    });
                });
              this.stopLoadingUi();
            }
          );
          break;
        case 4:
          this.parentService.getOneParent(this.userInfo.UserId).subscribe(
            result => {
              this.userInfo = result;
              this.studentService.getAllStudentByParent(this.userInfo.UserId).subscribe(
                result2 => {
                  this.childrenList = result2;
                  this.stopLoadingUi();
                });
              this.stopLoadingUi();
            }
          );
          break;
      }
    }, 500);
  }

  studentInfoOnClick(studentId) {
    this.router.navigate(['/dashboard/user-info',
      {
        userType: [3],
        userId: [studentId]
      }]);
  }

  parentInfoOnClick(parentId) {
    this.router.navigate(['/dashboard/user-info',
      {
        userType: [4],
        userId: [parentId]
      }]);
  }

  courseInfoOnClick(courseId) {
    this.router.navigate(['/dashboard/course-info',
      {
        courseId: [courseId]
      }]);
  }
}
