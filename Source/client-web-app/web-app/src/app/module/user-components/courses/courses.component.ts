import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {
  isSearching = false;
  constructor() { }

  ngOnInit() {
  }
  onClickSearchIcon() {
    if (this.isSearching === false) {
      this.isSearching = true;
    } else {
      this.getData();
    }
  }

  getData(): void {

  }
}
