import { Component, OnInit } from '@angular/core';
import { HocSinhService } from 'src/app/services/hoc-sinh.service';
import { HocSinhObject } from 'src/app/object/hoc-sinh-object';
import { error } from 'util';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [HocSinhService]
})
export class ProfileComponent implements OnInit {

  private hocSinhService: HocSinhService;
  public hocSinhSelected: HocSinhObject;
  constructor() {
    this.hocSinhService = new HocSinhService();
    this.hocSinhSelected = new HocSinhObject();

    this.hocSinhService.getOneHocSinh(1).subscribe(
      response => {
        this.hocSinhSelected = response;
      }
    );
  }

  ngOnInit() {
  }


}
