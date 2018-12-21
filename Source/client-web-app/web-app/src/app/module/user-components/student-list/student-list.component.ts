import { Component, OnInit } from '@angular/core';
import { StudentObject } from 'src/app/object/student-object';
import { StudentService } from 'src/app/services/data-services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css'],
  providers: [StudentService]
})
export class StudentListComponent implements OnInit {

  searchKeyword = '';
  public studentSelected: StudentObject[];
  constructor(private studentService: StudentService) {
    this.studentService.getAllStudent(this.searchKeyword).subscribe(
      response => {
        this.studentSelected = response;
      });
  }
  ngOnInit() {
  }

  deleteStudent(studentId) {
    this.studentService.deleteOneStudent(studentId).subscribe(
      response => {
        if (response > 0) {
          alert('Xóa thành công!');
          this.studentSelected = this.studentSelected.filter(item => item.UserId !== studentId);
        } else {
          alert('Lỗi!');
        }
      }
    );
  }

}
