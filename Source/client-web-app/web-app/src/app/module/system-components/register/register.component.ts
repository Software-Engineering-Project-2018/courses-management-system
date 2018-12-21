import { Component, OnInit, Injector } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CropperSettings } from 'ng2-img-cropper';
import { BaseComponent } from '../../base/base.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent extends BaseComponent implements OnInit {

  registerForm: FormGroup;
  cropperSettings: CropperSettings;
  constructor(fb: FormBuilder,
    public injector: Injector) {
    super(injector);
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
  }
}
