import { Component, OnInit } from '@angular/core';
import { HocSinhObject } from 'src/app/object/hoc-sinh-object';
import { HocSinhService } from 'src/app/services/hoc-sinh.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css'],
  providers: [HocSinhService]
})
export class StudentsComponent implements OnInit {

  public hocSinhSelected: HocSinhObject[];
  constructor(private hocSinhService: HocSinhService) {
    this.hocSinhService.getAllHocSinh().subscribe(
      response => {
        this.hocSinhSelected = response;
      });
  }
  ngOnInit() {
  }

}
