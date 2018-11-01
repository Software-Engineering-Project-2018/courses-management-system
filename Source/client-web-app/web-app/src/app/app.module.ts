import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { BaseComponent } from './module/base/base.component';
import { HomePageComponent } from './module/system-components/home-page/home-page.component';
import { LoginComponent } from './module/system-components/login/login.component';
import { RegisterComponent } from './module/system-components/register/register.component';
import { ContactComponent } from './module/system-components/contact/contact.component';
import { ForgotPasswordComponent } from './module/system-components/forgot-password/forgot-password.component';
import { CoursesComponent } from './module/user-components/courses/courses.component';
import { SettingComponent } from './module/user-components/setting/setting.component';
import { ProfileComponent } from './module/user-components/profile/profile.component';
import { MainScreenComponent } from './module/main-screen/main-screen.component';
import { NotificationComponent } from './module/user-components/notification/notification.component';
@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginComponent,
    RegisterComponent,
    ContactComponent,
    ForgotPasswordComponent,
    CoursesComponent,
    SettingComponent,
    ProfileComponent,
    BaseComponent,
    MainScreenComponent,
    NotificationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFontAwesomeModule,
    HttpClientModule
  ],
  // providers: [HocSinhService],
  bootstrap: [AppComponent]
})
export class AppModule { }
