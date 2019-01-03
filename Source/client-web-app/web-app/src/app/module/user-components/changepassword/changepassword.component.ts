import { Component, OnInit, Injector } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '../../base/base.component';
import { SystemService } from 'src/app/services/data-services/system.service';

@Component({
  selector: 'app-changepassword',
  templateUrl: './changepassword.component.html',
  styleUrls: ['./changepassword.component.css']
})
export class ChangepasswordComponent extends BaseComponent implements OnInit {

  oldPassword = '';
  newPassword = '';
  confirmPassword = '';

  passwordForm: FormGroup;
  systemService: SystemService;
  constructor(injector: Injector, fb: FormBuilder) {
    super(injector);
    this.systemService = injector.get(SystemService);
    this.passwordForm = fb.group({
      'oldPassword': [null, Validators.compose([Validators.required])],
      'newPassword': [null, Validators.compose([Validators.required, Validators.minLength(8)])],
      'confirmPassword': [null, Validators.compose([Validators.required])],
    });
  }

  ngOnInit() {
  }

  changePasswordOnClick() {
    this.systemService.changePassword(this.UserLogin, this.oldPassword, this.newPassword).subscribe(
      result => {
        if (result) {
          alert('Lưu mật khẩu thành công!');
          this.router.navigateByUrl('/dashboard/profile');
        } else {
          alert('Lưu thất bại, vui lòng kiểm tra lại mật khẩu.');
        }
      },
      error => {
        console.log(error);
      });
  }

  resetPwchangeFormOnClick() {
    this.oldPassword = '';
    this.newPassword = '';
    this.confirmPassword = '';
  }
}
