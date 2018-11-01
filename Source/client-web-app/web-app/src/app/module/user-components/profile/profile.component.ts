import { Component, OnInit, Injector } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HocSinhObject } from 'src/app/object/hoc-sinh-object';
import { HocSinhService } from 'src/app/services/hoc-sinh.service';

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
