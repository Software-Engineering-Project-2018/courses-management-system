import { Component, OnInit, Injector } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '../../base/base.component';

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

  constructor(injector: Injector, fb: FormBuilder) {
    super(injector);
    this.passwordForm = fb.group({
      'oldPassword': [null, Validators.compose([Validators.required])],
      'newPassword': [null, Validators.compose([Validators.required, Validators.minLength(8)])],
      'confirmPassword': [null, Validators.compose([Validators.required])],
    });
  }

  ngOnInit() {
  }

  changePasswordOnClick() {

  }
  resetPwchangeFormOnClick() {
    this.oldPassword = '';
    this.newPassword = '';
    this.confirmPassword = '';
  }
}
