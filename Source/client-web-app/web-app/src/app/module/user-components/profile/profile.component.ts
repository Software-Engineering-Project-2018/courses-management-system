import { Component, OnInit, Injector } from '@angular/core';
import { StudentService } from 'src/app/services/data-services/student.service';
import { CropperSettings } from 'ng2-img-cropper';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { BaseComponent } from '../../base/base.component';
import { TeacherService } from 'src/app/services/data-services/teacher.service';
import { ParentService } from 'src/app/services/data-services/parent.service';
import { ManagerService } from 'src/app/services/data-services/manager.service';
import { NgbDateParserFormatter, NgbDate } from '@ng-bootstrap/ng-bootstrap';
import * as $ from 'jquery';
import { SystemService } from 'src/app/services/data-services/system.service';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [StudentService]
})
export class ProfileComponent extends BaseComponent implements OnInit {

  // Form data
  public userInfo: any;
  ngDateOfBirth: NgbDate;
  avatarFile: File;
  //
  infoForm: FormGroup;
  data: any;
  cropperSettings: CropperSettings;
  studentService: StudentService;
  teacherService: TeacherService;
  parentService: ParentService;
  managerService: ManagerService;
  systemService: SystemService;

  constructor(fb: FormBuilder, private ngbDateParserFormatter: NgbDateParserFormatter,
    injector: Injector) {
    super(injector);
    this.teacherService = injector.get(TeacherService);
    this.studentService = injector.get(StudentService);
    this.parentService = injector.get(ParentService);
    this.managerService = injector.get(ManagerService);
    this.systemService = injector.get(SystemService);
    this.cropperSettings = new CropperSettings();

    this.userInfo = this.localStorageService.getUserInfo();
    if (this.userInfo.UserDob) {
      let dob: Date;
      dob = new Date(this.userInfo.UserDob);
      this.ngDateOfBirth = new NgbDate(dob.getFullYear(), dob.getMonth(), dob.getDay());
    }
    this.cropperSettings.width = 100;
    this.cropperSettings.height = 100;
    this.cropperSettings.croppedWidth = 100;
    this.cropperSettings.croppedHeight = 100;
    this.cropperSettings.canvasWidth = 300;
    this.cropperSettings.canvasHeight = 200;
    // this.cropperSettings.noFileInput = true;

    this.infoForm = fb.group({
      'name': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
      'id': [null, Validators.compose([Validators.required, Validators.minLength(7), Validators.maxLength(8)])],
      // 'gender': [null, Validators.required],
      'birthday': [null, Validators.required],
      'phone': [null, Validators.compose([Validators.required, Validators.pattern('[0-9]*'),
      Validators.minLength(10)])],
      'address': [null, Validators.compose([Validators.required])],
      'email': [null, Validators.compose([Validators.required, Validators.email])]
    });

    this.data = {};
  }

  ngOnInit() {
    if (!(this.isStudentLogin() && this.isTeacherLogin())) {
      this.infoForm.get('id').clearValidators();
      this.infoForm.get('id').updateValueAndValidity();
    }
  }

  changedAvatar($event: any) {
    this.avatarFile = $event.target.files.item(0);

    const file: File = $event.target.files[0];
    if ($event.target.files && file) {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onloadend = function (e: any) {
        $('#avatarImg').attr('src', e.target.result);
      };
      reader.onloadend = (e: any) => {
        this.userInfo.UserAvatar = e.target.result;
      };
    }
  }

  resetAvatarOnClick() {
    this.data.image = undefined;
  }

  dateChanged(data) {
    this.userInfo.UserDob = new Date(data.year, data.month - 1, data.day);
  }

  changeInfoOnClick() {
    switch (this.userInfo.UserType) {
      case 1:
        this.managerService.updateManager(JSON.parse(JSON.stringify(this.userInfo))).subscribe(
          result => {
            this.userInfo = result;
            alert('Lưu thành công!');
            this.localStorageService.setUserInfo(this.userInfo, 28800);
          }
        );
        break;
      case 2:
        this.teacherService.updateTeacher(JSON.parse(JSON.stringify(this.userInfo))).subscribe(
          result => {
            this.userInfo = result;
            alert('Lưu thành công!');
            this.localStorageService.setUserInfo(this.userInfo, 28800);
          }
        );
        break;
      case 3:
        this.studentService.updateStudent(JSON.parse(JSON.stringify(this.userInfo))).subscribe(
          result => {
            this.userInfo = result;
            alert('Lưu thành công!');
            this.localStorageService.setUserInfo(this.userInfo, 28800);
          }
        );
        break;
      case 4:
        this.parentService.updateParent(JSON.parse(JSON.stringify(this.userInfo))).subscribe(
          result => {
            this.userInfo = result;
            alert('Lưu thành công!');
            this.localStorageService.setUserInfo(this.userInfo, 28800);
          }
        );
        break;
    }
  }

  resetInfoFormOnClick() {
    this.userInfo.UserFullName = '';
    this.userInfo.IdentificationCode = '';
    // this.userInfo.UserGender = 0;
    this.userInfo.UserDob = new Date();
    this.userInfo.UserMobile = '';
    this.userInfo.UserAddress = '';
    this.userInfo.UserEmail = '';
    this.resetAvatarOnClick();
  }
}
