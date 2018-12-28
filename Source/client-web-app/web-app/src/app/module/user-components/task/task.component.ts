import { Component, OnInit, Injector } from '@angular/core';
import { TaskObject } from 'src/app/object/task-object';
import { TaskService } from 'src/app/services/data-services/task.service';
import { BaseComponent } from '../../base/base.component';
import { TaskDetailService } from 'src/app/services/data-services/task-detail.service';
import { ActivatedRoute } from '@angular/router';
import { TaskDetailObject } from 'src/app/object/task-detail-object';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent extends BaseComponent implements OnInit {

  taskDetailInfo: TaskDetailObject;
  taskService: TaskService;
  taskDetailService: TaskDetailService;
  constructor(injector: Injector,
    private route: ActivatedRoute) {
    super(injector);
    this.taskService = injector.get(TaskService);
    this.taskDetailService = injector.get(TaskDetailService);
  }

  ngOnInit() {
    this.taskDetailInfo = new TaskDetailObject();
    this.taskDetailInfo.Student.UserId = this.UserLogin.UserId;
    this.routerSubscribe = this.route.params.subscribe(params => {
      const taskId = params['taskId'];
      if (taskId) {
        this.taskDetailInfo.Task.TaskId = taskId;
        this.getData();
      }
    });
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.taskService.getOneTask(this.taskDetailInfo.Task.TaskId).subscribe(
        result => {
          this.taskDetailInfo.Task = result;
          this.stopLoadingUi();
        },
        error => {
          console.log(error);
          this.stopLoadingUi();
        }
      );

    }, 500);
  }

  submitExOnClick() {
    this.startLoadingUi();
    setTimeout(() => {
      this.taskDetailService.insertTaskDetail(this.taskDetailInfo).subscribe(
        result => {
          this.taskDetailInfo = result;
          alert('Nộp bài thành công!');
          this.stopLoadingUi();
        },
        error => {
          console.log(error);
          this.stopLoadingUi();
        }
      );
    }, 500);
  }

  cancelExOnClick() {

  }

}
