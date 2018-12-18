import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-changepassword',
  templateUrl: './changepassword.component.html',
  styleUrls: ['./changepassword.component.css']
})
export class ChangepasswordComponent implements OnInit {

  oldPassword = '';
  newPassword = '';
  confirmPassword = '';

  passwordForm: FormGroup;

  constructor(fb: FormBuilder) {
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
