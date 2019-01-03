import { Component, OnInit, Injector } from '@angular/core';
import { TaskService } from 'src/app/services/data-services/task.service';
import { BaseComponent } from '../../base/base.component';
import { TaskDetailService } from 'src/app/services/data-services/task-detail.service';
import { ActivatedRoute } from '@angular/router';
import { TaskDetailObject } from 'src/app/object/task-detail-object';
import { FileService } from 'src/app/services/file-manager.service';
import * as $ from 'jquery';
import { TaskObject } from 'src/app/object/task-object';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css'],
  providers: [FileService]
})
export class TaskComponent extends BaseComponent implements OnInit {

  filesToUpload: File;

  taskDetailInfo: TaskDetailObject;
  taskService: TaskService;
  taskDetailService: TaskDetailService;
  fileService: FileService;

  constructor(injector: Injector,
    private route: ActivatedRoute) {
    super(injector);
    this.taskService = injector.get(TaskService);
    this.taskDetailService = injector.get(TaskDetailService);
    this.fileService = injector.get(FileService);
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

  findTaskDetail() {
    this.taskDetailService.getTaskDetailByStudentAndCourse(this.UserLogin.UserId, this.taskDetailInfo.Task.TaskId).subscribe(
      result => {
        if (result[0].TaskDetailId) {
          this.taskDetailInfo.TaskDetailId = result[0].TaskDetailId;
          this.taskDetailInfo.TaskFileUpload = result[0].TaskFileUpload;
          this.taskDetailInfo.TaskSubmissionState = result[0].TaskSubmissionState;
          this.taskDetailInfo.TaskScore = result[0].TaskScore;
          this.stopLoadingUi();
        }
      },
      error => {
        console.log(error);
        this.stopLoadingUi();
      }
    );
  }

  getData() {
    this.startLoadingUi();
    setTimeout(() => {
      this.taskService.getOneTask(this.taskDetailInfo.Task.TaskId).subscribe(
        result => {
          this.taskDetailInfo.Task = result;
          this.findTaskDetail();
          this.stopLoadingUi();
        },
        error => {
          console.log(error);
          this.stopLoadingUi();
        }
      );

    }, 500);
  }

  changedFile($event: any) {
    this.filesToUpload = $event.target.files.item(0);
    this.taskDetailInfo.TaskFileUpload = this.filesToUpload.name;
  }

  cancelFileOnClick() {
    this.taskDetailInfo.TaskFileUpload = '';
    this.filesToUpload = null;
    $('#fileUpload').val('');
  }

  submitUploadOnClick() {
    this.startLoadingUi();
    const formData: FormData = new FormData();
    if (!this.taskDetailInfo.TaskFileUpload || this.taskDetailInfo.TaskFileUpload === '') {
      alert('Chưa chọn file!');
      this.stopLoadingUi();
    } else if (this.filesToUpload) {
      formData.append('Image', this.filesToUpload, this.filesToUpload.name);
      formData.append('ImageCaption', '');
      this.fileService.uploadFile(formData).subscribe(
        data => {
          if (data[0]) {
            this.taskDetailInfo.TaskFileUpload = data[0];
          }
          if (this.taskDetailInfo.TaskDetailId) {
            this.taskDetailService.updateTaskDetail(this.taskDetailInfo).subscribe(
              result => {
                this.taskDetailInfo = result;
                alert('Nộp bài thành công!');
                this.stopLoadingUi();
              },
              error => {
                console.log(error);
                this.stopLoadingUi();
              });
          } else {
            this.taskDetailService.insertTaskDetail(this.taskDetailInfo).subscribe(
              result => {
                this.taskDetailInfo = result;
                alert('Nộp bài thành công!');
                this.stopLoadingUi();
              },
              error => {
                console.log(error);
                this.stopLoadingUi();
              });
          }
        });
    } else {
      alert('Lưu thành công!');
      this.stopLoadingUi();
    }
  }

}
