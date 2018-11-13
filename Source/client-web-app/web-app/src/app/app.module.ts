import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgScrollbarModule } from 'ngx-scrollbar';
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
import { DashboardComponent } from './module/system-components/dashboard/dashboard.component';
import { ScoreboardComponent } from './module/user-components/scoreboard/scoreboard.component';
import { ChangepasswordComponent } from './module/user-components/changepassword/changepassword.component';
import { StudentsComponent } from './module/user-components/students/students.component';
import { TeachersComponent } from './module/user-components/teachers/teachers.component';
import { IncomeComponent } from './module/user-components/income/income.component';
import { CourseInfoComponent } from './module/user-components/course-info/course-info.component';
import { LessonComponent } from './module/user-components/lesson/lesson.component';
import { UserInfoComponent } from './module/user-components/user-info/user-info.component';
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
    NotificationComponent,
    DashboardComponent,
    ScoreboardComponent,
    ChangepasswordComponent,
    StudentsComponent,
    TeachersComponent,
    IncomeComponent,
    CourseInfoComponent,
    LessonComponent,
    UserInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFontAwesomeModule,
    HttpClientModule,
    NgScrollbarModule
  ],
  // providers: [HocSinhService],
  bootstrap: [AppComponent]
})
export class AppModule { }
