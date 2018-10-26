import { Component, OnInit, Injector } from '@angular/core';
import { HocSinhService } from 'src/app/services/hoc-sinh.service';
import { HocSinhObject } from 'src/app/object/hoc-sinh-object';
// import { toPromise } from 'rxjs/operator';
import { HttpClientModule } from '@angular/common/http';
import { Http } from '@angular/http';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  private hocSinhService: HocSinhService;
  public hocSinhSelected: HocSinhObject[] = [];
  constructor(private http: Http) {
    this.http.get('localhost:56697/rest/hoc-sinh/get-all').subscribe(
      response => {
        // this.hocSinhSelected = response;
      });
    // .toPromise()
    // .then(res => res.json())
    // .then(resJson => alert(resJson));
  }

  // constructor(injector: Injector) {
  //   this.hocSinhService = injector.get(HocSinhService);
  // }

  ngOnInit() {

    // this.hocSinhService.getAllHocSinh().subscribe(
    //   response => {
    //     this.hocSinhSelected = response;
    //   }
    // );
  }


}
