import { Component, OnInit, Injector } from '@angular/core';
import { CourseStudentObject } from 'src/app/object/course-student-detail-object';
import { BaseComponent } from '../../base/base.component';

@Component({
  selector: 'app-scoreboard',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.css']
})
export class ScoreboardComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  public courseStudentList: CourseStudentObject[];
  constructor(injector: Injector) {
    super(injector);
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    // this.studentService.getAllStudent(this.searchKeyword).subscribe(
    //   response => {
    //     this.studentList = response;
    this.stopLoadingUi();
    // });
  }
}
