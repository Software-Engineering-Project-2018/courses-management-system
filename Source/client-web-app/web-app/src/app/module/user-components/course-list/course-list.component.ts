import { Component, OnInit, Injector, EventEmitter, Output, ElementRef, ViewChild } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { CourseObject } from 'src/app/object/course-object';
import { CourseService } from 'src/app/services/data-services/course.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TeacherService } from 'src/app/services/data-services/teacher.service';
import { StudentObject } from 'src/app/object/student-object';
import { TeacherObject } from 'src/app/object/teacher-object';
import { StudentService } from 'src/app/services/data-services/student.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent extends BaseComponent implements OnInit {
  @ViewChild('btnCloseInsert') btnCloseInsert: ElementRef;
  @ViewChild('btnCloseUpdate') btnCloseUpdate: ElementRef;

  searchKeyword = '';
  searchKeywordTeacherList = '';
  searchKeywordStudentList = '';
  // screenName = 'course-list';
  courseService: CourseService;
  teacherService: TeacherService;
  studentService: StudentService;


  // Form data
  public courseInfo = new CourseObject();
  public currSelectedCourse = new CourseObject();
  public studentJoinedList: StudentObject[] = [];
  public teacherJoinedList: TeacherObject[] = [];
  courseInfoForm: FormGroup;

  public courseJoinedList: CourseObject[] = [];
  public courseNotJoinedList: CourseObject[] = [];
  constructor(injector: Injector, fb: FormBuilder) {
    super(injector);
    this.courseService = injector.get(CourseService);
    this.teacherService = injector.get(TeacherService);
    this.studentService = injector.get(StudentService);
    this.getData();

    this.courseInfoForm = fb.group({
      'courseName': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(100)])],
      'dateStart': [null, Validators.required],
      'dateEnd': [null, Validators.required],
      'tutition': [null, Validators.required],
      'courseIntro': [null],
      'courseLinkRef': [null]
    });

    this.courseInfo = new CourseObject();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      if (this.UserLogin.UserType === 3) {
        this.getDataForStudent();
      } else {
        this.courseService.getAllCourse(this.searchKeyword).subscribe(
          response1 => {
            this.courseNotJoinedList = response1;
            this.courseNotJoinedList.forEach(item => {
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

  getDataForStudent() {
    this.startLoadingUi();
    setTimeout(() => {
      this.courseService.getAllCourseJoined(this.searchKeyword, this.UserLogin.UserId).subscribe(
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
        },
        error => {
          console.error(error);
          this.stopLoadingUi();
        });
      this.courseService.getAllCourseNotJoined(this.searchKeyword, this.UserLogin.UserId).subscribe(
        response1 => {
          this.courseNotJoinedList = response1;
          this.courseNotJoinedList.forEach(item => {
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
  selectCourseOnClick(course) {
    this.currSelectedCourse = course;
  }

  searchOnclick() {
    this.getData();
  }

  getDataStudentList() {
    if (this.currSelectedCourse.CourseId) {
      this.studentService.getAllStudentByCourse(this.currSelectedCourse.CourseId, this.searchKeywordStudentList).subscribe(
        result => {
          this.studentJoinedList = result;
          this.stopLoadingUi();
        });
    }
  }

  studentListOnClick(course) {
    this.currSelectedCourse = course;
    this.getDataStudentList();
  }

  searchStudentListOnclick() {
    this.startLoadingUi();
    this.getDataStudentList();
  }

  getDataTeacherList() {
    if (this.currSelectedCourse.CourseId) {
      this.teacherService.getAllTeacherByCourse(this.currSelectedCourse.CourseId, this.searchKeywordTeacherList).subscribe(
        result => {
          this.teacherJoinedList = result;
          this.stopLoadingUi();
        });
    }
  }

  searchTeacherListOnClick() {
    this.startLoadingUi();
    this.getDataTeacherList();
  }

  teacherListOnclick(course) {
    this.currSelectedCourse = course;
    this.getDataTeacherList();
  }

  insertCourseOnClick() {
    this.courseService.insertCourse(this.courseInfo).subscribe(
      result => {
        alert('Thêm khóa học thành công!');
        this.courseNotJoinedList.unshift(result);
        this.btnCloseInsert.nativeElement.click();
        this.courseInfo = new CourseObject();
      },
      error => {
        console.log(error);
      });
  }

  updateCourseOnClick() {
    this.courseService.updateCourse(this.currSelectedCourse).subscribe(
      result => {
        alert('Lưu khóa học thành công!');
        const i = this.courseJoinedList.findIndex(item => item.CourseId === this.currSelectedCourse.CourseId);
        if (i > 0) {
          this.courseJoinedList[i] = result;
        } else {
          const i1 = this.courseJoinedList.findIndex(item => item.CourseId === this.currSelectedCourse.CourseId);
          if (i1 > 0) {
            this.courseNotJoinedList[i1] = result;
          }
        }
        this.stopLoadingUi();
        this.currSelectedCourse = new CourseObject();
        this.btnCloseUpdate.nativeElement.click();
      },
      error => {
        console.log(error);
      });
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
        userId: [teacherId]
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
