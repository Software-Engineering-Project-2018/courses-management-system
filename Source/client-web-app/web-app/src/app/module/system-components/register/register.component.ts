import { Component, OnInit } from '@angular/core';
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
  constructor(fb: FormBuilder) {
    super();
    this.registerForm = fb.group({
      'name': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
      'gender': [null, Validators.required],
      'birthday': [null, Validators.required],
      'phone': [null, Validators.compose([Validators.required, Validators.pattern('[0-9]*'),
      Validators.minLength(10), Validators.maxLength(10)])],
      'address': [null, Validators.compose([Validators.required])],
      'email': [null, Validators.compose([Validators.required, Validators.email])],
      'agree-terms': [null, Validators.requiredTrue],
    });
  }

  ngOnInit() {
  }

  registerOnClick() {
  }
}
