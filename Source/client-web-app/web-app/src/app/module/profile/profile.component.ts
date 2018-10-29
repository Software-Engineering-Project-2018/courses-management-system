import { Component, OnInit, Injector } from '@angular/core';
import { HocSinhService } from '../../services/hoc-sinh.service';
import { HocSinhObject } from '../../object/hoc-sinh-object';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [HocSinhService]
})
export class ProfileComponent implements OnInit {

  // private hocSinhService: HocSinhService;
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
