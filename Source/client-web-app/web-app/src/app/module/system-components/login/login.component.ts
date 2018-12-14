import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CropperSettings } from 'ng2-img-cropper';

export interface FormModel {
  captcha?: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends BaseComponent implements OnInit {

  loginForm: FormGroup;
  public formModel: FormModel = {};
  cropperSettings: CropperSettings;
  constructor(fb: FormBuilder) {
    super();
    this.loginForm = fb.group({
      'username': [null, Validators.required],
      'password': [null, Validators.required]
    });
  }

  ngOnInit() {
  }

  loginOnClick() {
  }
}
