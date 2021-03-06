import { Component, OnInit, Injector } from '@angular/core';
import { StudentObject } from 'src/app/object/student-object';
import { StudentService } from 'src/app/services/data-services/student.service';
import { BaseComponent } from '../../base/base.component';

@Component({
  selector: 'app-income',
  templateUrl: './income.component.html',
  styleUrls: ['./income.component.css']
})
export class IncomeComponent extends BaseComponent implements OnInit {

  searchKeyword = '';
  totalInDebt = 0;
  private studentService: StudentService;
  public studentList: StudentObject[];
  constructor(injector: Injector) {
    super(injector);
    this.studentService = injector.get(StudentService);
    this.getData();
  }
  ngOnInit() {
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.totalInDebt = 0;
      this.studentService.getAllStudent(this.searchKeyword).subscribe(
        response => {
          this.studentList = response;
          this.studentList.forEach(item => {
            this.totalInDebt += item.TotalinDebt;
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
    this.getData();
  }
  userInfoOnClick(studentId) {
    this.router.navigate(['/dashboard/user-info',
      {
        userType: [3],
        userId: [studentId]
      }]);
  }
  listCourseOnClick(studentId) {
    this.router.navigate(['/dashboard/courses']);
  }

}
