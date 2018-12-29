import { Component, OnInit, Injector } from '@angular/core';
import { CourseStudentObject } from 'src/app/object/course-student-detail-object';
import { BaseComponent } from '../../base/base.component';
import { CourseStudentService } from 'src/app/services/data-services/course-student.service';

@Component({
  selector: 'app-scoreboard',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.css']
})
export class ScoreboardComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  courseStudentService: CourseStudentService;
  public courseStudentList: CourseStudentObject[];
  constructor(injector: Injector) {
    super(injector);
    this.courseStudentService = injector.get(CourseStudentService);
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    this.courseStudentService.getScoreboardByStudent(this.UserLogin.UserId).subscribe(
      response => {
        this.courseStudentList = response;
        this.stopLoadingUi();
      });
  }
}
