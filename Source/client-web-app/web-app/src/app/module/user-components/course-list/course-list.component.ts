import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {
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
