import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CropperSettings } from 'ng2-img-cropper';
import { AuthService } from 'src/app/services/auth.service';
import { StorageService } from 'src/app/services/storage.service';
import { ActivatedRoute } from '@angular/router';

export interface FormModel {
  captcha?: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends BaseComponent implements OnInit {


  username = '';
  password = '';

  loginForm: FormGroup;
  public formModel: FormModel = {};
  cropperSettings: CropperSettings;
  constructor(fb: FormBuilder,
    public injector: Injector,
    private route: ActivatedRoute) {
    super(injector);

    this.loginForm = fb.group({
      'username': [null, Validators.required],
      'password': [null, Validators.required],
      // 'recaptcha': [null, Validators.required]
    });
  }

  ngOnInit() {
  }

  // implement login here
  loginOnClick(): void {
    if (this.authenticationService.isLoggedIn()) {
      this.router.navigateByUrl('/register');
    }
    this.authenticationService
      .login(this.username, this.password)
      .subscribe(
        response => {
          this.router.navigateByUrl('/dashboard');
          this.localStorageService.setUserToken(response.access_token, response.expires_in);
          this.authenticationService.getUserInfo().subscribe(
            user => {
              // store user
              this.localStorageService.setUserInfo(user, response.expires_in);
            }
          );
        },
        error => {
          if (error.status === 0) {
            alert('Mất kết nối với máy chủ, kiểm tra lại kết nối mạng hoặc liên hệ bộ phận hỗ trợ.');
          } else {
            alert('Đăng nhập thất bại, tên đăng nhập hoặc mật khẩu không đúng!');
          }
          // console.error(error);
        },
        () => {
          // completeCallback
        }
      );
  }
}
