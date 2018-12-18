import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgScrollbarModule } from 'ngx-scrollbar';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RecaptchaModule, RECAPTCHA_SETTINGS, RecaptchaSettings, RECAPTCHA_LANGUAGE } from 'ng-recaptcha';
import { RecaptchaFormsModule } from 'ng-recaptcha/forms';
import { AngularWebStorageModule } from 'angular-web-storage';
import { ImageCropperModule } from 'ng2-img-cropper';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { HomePageComponent } from './module/system-components/home-page/home-page.component';
import { LoginComponent } from './module/system-components/login/login.component';
import { RegisterComponent } from './module/system-components/register/register.component';
import { ContactComponent } from './module/system-components/contact/contact.component';
import { ForgotPasswordComponent } from './module/system-components/forgot-password/forgot-password.component';
import { CourseListComponent } from './module/user-components/course-list/course-list.component';
import { SettingComponent } from './module/user-components/setting/setting.component';
import { ProfileComponent } from './module/user-components/profile/profile.component';
import { MainScreenComponent } from './module/main-screen/main-screen.component';
import { CourseNotificationListComponent } from './module/user-components/notification-list/courses-notification-list.component';
import { GeneralNotificationListComponent } from './module/user-components/notification-list/general-notification-list.component';
import { DashboardComponent } from './module/system-components/dashboard/dashboard.component';
import { ScoreboardComponent } from './module/user-components/scoreboard/scoreboard.component';
import { ChangepasswordComponent } from './module/user-components/changepassword/changepassword.component';
import { StudentListComponent } from './module/user-components/student-list/student-list.component';
import { TeacherListComponent } from './module/user-components/teacher-list/teacher-list.component';
import { IncomeComponent } from './module/user-components/income/income.component';
import { CourseInfoComponent } from './module/user-components/course-info/course-info.component';
import { LessonComponent } from './module/user-components/lesson/lesson.component';
import { UserInfoComponent } from './module/user-components/user-info/user-info.component';
import { EnrollCourseComponent } from './module/user-components/enroll-course/enroll-course.component';
import { AuthInterceptor } from './services/app-http-interceptor';
import { NotificationInfoComponent } from './module/user-components/notification-info/notification-info.component';
@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginComponent,
    RegisterComponent,
    ContactComponent,
    ForgotPasswordComponent,
    CourseListComponent,
    SettingComponent,
    ProfileComponent,
    MainScreenComponent,
    CourseNotificationListComponent,
    GeneralNotificationListComponent,
    DashboardComponent,
    ScoreboardComponent,
    ChangepasswordComponent,
    StudentListComponent,
    TeacherListComponent,
    IncomeComponent,
    CourseInfoComponent,
    LessonComponent,
    UserInfoComponent,
    EnrollCourseComponent,
    NotificationInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFontAwesomeModule,
    HttpClientModule,
    NgbModule.forRoot(),
    NgScrollbarModule,
    ImageCropperModule,
    RecaptchaModule.forRoot(),
    RecaptchaFormsModule,
    AngularWebStorageModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    // {
    //   provide: RECAPTCHA_LANGUAGE,
    //   useValue: 'vi',
    // },
    {
      provide: HTTP_INTERCEPTORS, // import { HTTP_INTERCEPTORS } from '@angular/common/http';
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
