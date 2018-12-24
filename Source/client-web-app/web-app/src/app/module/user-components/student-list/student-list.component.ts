import { Component, OnInit, Injector } from '@angular/core';
import { StudentObject } from 'src/app/object/student-object';
import { StudentService } from 'src/app/services/data-services/student.service';
import { BaseComponent } from '../../base/base.component';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css'],
  providers: [StudentService]
})
export class StudentListComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  public studentList: StudentObject[];
  constructor(injector: Injector,
    private studentService: StudentService) {
    super(injector);
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    this.studentService.getAllStudent(this.searchKeyword).subscribe(
      response => {
        this.studentList = response;
        this.stopLoadingUi();
      });
  }

  searchOnclick() {
    this.getData();
  }
  userInfoOnClick(studentId) {
    this.router.navigate(['/dashboard/user-info']);
  }
  listCourseOnClick(studentId) {
    this.router.navigate(['/dashboard/courses']);
  }
}
