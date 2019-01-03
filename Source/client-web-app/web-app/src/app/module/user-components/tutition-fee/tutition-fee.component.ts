import { Component, OnInit, Injector } from '@angular/core';
import { StudentObject } from 'src/app/object/student-object';
import { StudentService } from 'src/app/services/data-services/student.service';
import { BaseComponent } from '../../base/base.component';
import { CourseService } from 'src/app/services/data-services/course.service';
import { CourseObject } from 'src/app/object/course-object';

@Component({
  selector: 'app-tutition-fee',
  templateUrl: './tutition-fee.component.html',
  styleUrls: ['./tutition-fee.component.css']
})
export class TutitionFeeComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  totalTutition = 0;
  studenInfo = new StudentObject();
  private courseService: CourseService;
  private studentService: StudentService;
  public courseList: CourseObject[];
  constructor(injector: Injector) {
    super(injector);
    this.courseService = injector.get(CourseService);
    this.studentService = injector.get(StudentService);
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.studentService.getOneStudent(this.UserLogin.UserId).subscribe(
        result => {
          this.studenInfo = result;
        });
      this.courseService.getAllCourseJoined(this.searchKeyword, this.UserLogin.UserId).subscribe(
        response => {
          this.courseList = response;
          this.courseList.forEach(item => {
            this.totalTutition += item.Tutition;
          });
          this.stopLoadingUi();
        },
        error => {
          console.error(error);
          this.stopLoadingUi();
        });
    }, 500);
  }

  searchOnclick() {
    this.totalTutition = 0;
    this.getData();
  }

  courseInfoOnClick(courseId) {
    this.router.navigate(['/dashboard/course-info']);
  }

}
