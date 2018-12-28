import { Component, OnInit, Injector } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CropperSettings } from 'ng2-img-cropper';
import { BaseComponent } from '../../base/base.component';
import { TeacherService } from 'src/app/services/data-services/teacher.service';
import { StudentService } from 'src/app/services/data-services/student.service';
import { ParentService } from 'src/app/services/data-services/parent.service';
import { ManagerService } from 'src/app/services/data-services/manager.service';
import { UserObject } from 'src/app/object/user-object';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { SystemService } from 'src/app/services/data-services/system.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent extends BaseComponent implements OnInit {

  ngDateOfBirth: NgbDate;
  userType = 1;
  userInfo: any = new UserObject();
  registerForm: FormGroup;
  cropperSettings: CropperSettings;
  studentService: StudentService;
  teacherService: TeacherService;
  parentService: ParentService;
  systemService: SystemService;

  constructor(fb: FormBuilder,
    public injector: Injector) {
    super(injector);
    this.teacherService = injector.get(TeacherService);
    this.studentService = injector.get(StudentService);
    this.parentService = injector.get(ParentService);
    this.systemService = injector.get(SystemService);

    this.registerForm = fb.group({
      'username': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50),
      Validators.pattern('[A-Za-z0-9]+')])],
      'name': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
      'gender': [null, Validators.required],
      'birthday': [null, Validators.required],
      'phone': [null, Validators.compose([Validators.required, Validators.pattern('[0-9]*'),
      Validators.minLength(10), Validators.maxLength(20)])],
      'address': [null, Validators.compose([Validators.required])],
      'email': [null, Validators.compose([Validators.required, Validators.email])],
      'password': [null, Validators.compose([Validators.required, Validators.minLength(8), Validators.maxLength(30)])],
      'confirmPassword': [null, Validators.required],
      'agree-terms': [null, Validators.requiredTrue],
    });
  }

  ngOnInit() {
    if (this.authenticationService.isLoggedIn()) {
      this.router.navigateByUrl('/dashboard');
    }
  }

  checkUsedUsername() {

  }
  checkUsedMail() {

  }

  registerOnClick() {
    this.userInfo.UserDob = new Date(this.ngDateOfBirth.year, this.ngDateOfBirth.month - 1, this.ngDateOfBirth.day);
    this.systemService.register(this.userInfo).subscribe(
      result => {
        this.userInfo = result;
        alert('Đăng ký thành công! Vui lòng đăng nhập!');
        this.router.navigateByUrl('/login');
      },
      error => {
        alert('Lỗi!');
      }
    );
  }
}
