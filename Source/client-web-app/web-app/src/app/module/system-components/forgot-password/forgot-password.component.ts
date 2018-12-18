import { Component, OnInit, Injector } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CropperSettings } from 'ng2-img-cropper';
import { BaseComponent } from '../../base/base.component';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent extends BaseComponent implements OnInit {

  forgotPasswordForm: FormGroup;
  cropperSettings: CropperSettings;
  constructor(fb: FormBuilder,
    public injector: Injector) {
    super(injector);
    this.forgotPasswordForm = fb.group({
      'username': [null, Validators.required],
      'email': [null, Validators.compose([Validators.required, Validators.email])],
    });
  }

  ngOnInit() {
  }

  forgotPasswordOnClick() {
  }
}
