import { Component, OnInit } from '@angular/core';
import { HocSinhObject } from 'src/app/object/hoc-sinh-object';
import { HocSinhService } from 'src/app/services/data-services/hoc-sinh.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css'],
  providers: [HocSinhService]
})
export class StudentListComponent implements OnInit {

  public hocSinhSelected: HocSinhObject[];
  constructor(private hocSinhService: HocSinhService) {
    this.hocSinhService.getAllHocSinh().subscribe(
      response => {
        this.hocSinhSelected = response;
      });
  }
  ngOnInit() {
  }

  deleteHocSinh(hocSinhId) {
    this.hocSinhService.deleteHocSinh(hocSinhId).subscribe(
      response => {
        if (response > 0) {
          alert('Xóa thành công!');
          this.hocSinhSelected = this.hocSinhSelected.filter(item => item.HocSinhId !== hocSinhId);
        } else {
          alert('Lỗi!');
        }
      }
    );
  }

}
