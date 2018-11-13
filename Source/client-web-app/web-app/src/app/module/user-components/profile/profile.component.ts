import { Component, OnInit, Injector } from '@angular/core';
import { HocSinhService } from 'src/app/services/hoc-sinh.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [HocSinhService]
})
export class ProfileComponent implements OnInit {

  constructor() {
  }

  ngOnInit() {
  }


}
