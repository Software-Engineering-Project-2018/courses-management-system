import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { ActivatedRoute } from '@angular/router';
import { CourseObject } from 'src/app/object/course-object';
import { CourseService } from 'src/app/services/data-services/course.service';
import { DocumentDetailService } from 'src/app/services/data-services/document-detail.service';
import { TaskService } from 'src/app/services/data-services/task.service';
import { TeacherService } from 'src/app/services/data-services/teacher.service';

@Component({
  selector: 'app-course-info',
  templateUrl: './course-info.component.html',
  styleUrls: ['./course-info.component.css']
})
export class CourseInfoComponent extends BaseComponent implements OnInit {

  courseInfo: CourseObject;
  courseService: CourseService;
  teacherService: TeacherService;
  documentDetailService: DocumentDetailService;
  taskService: TaskService;
  constructor(injector: Injector,
    private route: ActivatedRoute) {
    super(injector);
    this.courseService = injector.get(CourseService);
    this.teacherService = injector.get(TeacherService);
    this.documentDetailService = injector.get(DocumentDetailService);
    this.taskService = injector.get(TaskService);
  }

  ngOnInit() {
    this.courseInfo = new CourseObject();
    this.routerSubscribe = this.route.params.subscribe(params => {
      const courseId = params['courseId'];
      if (courseId) {
        this.courseInfo.CourseId = courseId;
        this.getData();
      }
    });
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.courseService.getOneCourse(this.courseInfo.CourseId).subscribe(
        result1 => {
          this.courseInfo = result1;
          this.teacherService.getAllTeacherByCourse(this.courseInfo.CourseId, '').subscribe(
            result4 => {
              this.courseInfo.TeacherList = result4;
              this.stopLoadingUi();
            },
            error4 => {
              console.log(error4);
              this.stopLoadingUi();
            }
          );
          this.documentDetailService.getAllDocumentDetail(this.courseInfo.CourseId).subscribe(
            result2 => {
              this.courseInfo.DocumentDetailList = result2;
              this.stopLoadingUi();
            },
            error2 => {
              console.log(error2);
              this.stopLoadingUi();
            }
          );
          this.taskService.getAllTask(this.courseInfo.CourseId).subscribe(
            result3 => {
              this.courseInfo.TaskList = result3;
              this.stopLoadingUi();
            },
            error3 => {
              console.log(error3);
              this.stopLoadingUi();
            }
          );
        },
        error1 => {
          console.log(error1);
          this.stopLoadingUi();
        }
      );

    }, 500);
  }

  taskInfoOnClick(taskId) {
    this.router.navigate(['/dashboard/task',
      {
        taskId: [taskId]
      }]);
  }

  teacherInfoOnClick(teacherId) {
    this.router.navigate(['/dashboard/user-info',
      {
        userType: [2],
        userId: [teacherId]
      }]);
  }

}
