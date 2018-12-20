import { Component, OnInit, Injector } from '@angular/core';
import { HocSinhService } from 'src/app/services/data-services/hoc-sinh.service';
import { CropperSettings } from 'ng2-img-cropper';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { BaseComponent } from '../../base/base.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [HocSinhService]
})
export class ProfileComponent extends BaseComponent implements OnInit {

  // Form data
  name = '';
  id = '';
  gender = 0;
  birthday = new Date();
  phone = '';
  address = '';
  email = '';

  //
  infoForm: FormGroup;
  data: any;
  cropperSettings: CropperSettings;

  constructor(fb: FormBuilder,
    injector: Injector) {
    super(injector);
    this.cropperSettings = new CropperSettings();
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
      'gender': [null, Validators.required],
      'birthday': [null, Validators.required],
      'phone': [null, Validators.compose([Validators.required, Validators.pattern('[0-9]*'),
      Validators.minLength(10), Validators.maxLength(10)])],
      'address': [null, Validators.compose([Validators.required])],
      'email': [null, Validators.compose([Validators.required, Validators.email])]
    });

    this.data = {};
  }

  ngOnInit() {
  }

  resetAvatarOnClick() {
    this.data.image = undefined;
  }

  changeInfoOnClick() {

  }

  resetInfoFormOnClick() {
    this.name = '';
    this.id = '';
    this.gender = 0;
    this.birthday = new Date();
    this.phone = '';
    this.address = '';
    this.email = '';
  }
}
