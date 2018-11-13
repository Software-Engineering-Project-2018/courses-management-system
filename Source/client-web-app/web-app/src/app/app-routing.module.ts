import { NgModule } from '@angular/core';
// import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './module/system-components/home-page/home-page.component';
import { LoginComponent } from './module/system-components/login/login.component';
import { RegisterComponent } from './module/system-components/register/register.component';
import { ForgotPasswordComponent } from './module/system-components/forgot-password/forgot-password.component';
import { ProfileComponent } from './module/user-components/profile/profile.component';
import { CoursesComponent } from './module/user-components/courses/courses.component';
import { SettingComponent } from './module/user-components/setting/setting.component';
import { ContactComponent } from './module/system-components/contact/contact.component';
import { MainScreenComponent } from './module/main-screen/main-screen.component';
import { NotificationComponent } from './module/user-components/notification/notification.component';
import { DashboardComponent } from './module/system-components/dashboard/dashboard.component';
import { ScoreboardComponent } from './module/user-components/scoreboard/scoreboard.component';
import { StudentsComponent } from './module/user-components/students/students.component';
import { TeachersComponent } from './module/user-components/teachers/teachers.component';
import { IncomeComponent } from './module/user-components/income/income.component';
import { ChangepasswordComponent } from './module/user-components/changepassword/changepassword.component';
import { LessonComponent } from './module/user-components/lesson/lesson.component';
import { CourseInfoComponent } from './module/user-components/course-info/course-info.component';
import { UserInfoComponent } from './module/user-components/user-info/user-info.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  {
    path: 'dashboard',
    component: MainScreenComponent,
    children: [
      {
        path: '',
        component: DashboardComponent
      },
      {
        path: 'notification',
        component: NotificationComponent
      },
      {
        path: 'courses',
        component: CoursesComponent
      },
      {
        path: 'scoreboard',
        component: ScoreboardComponent
      },
      {
        path: 'students',
        component: StudentsComponent
      },
      {
        path: 'teachers',
        component: TeachersComponent
      },
      {
        path: 'income',
        component: IncomeComponent
      },
      {
        path: 'settings',
        component: SettingComponent
      },
      {
        path: 'profile',
        component: ProfileComponent
      },
      {
        path: 'changepassword',
        component: ChangepasswordComponent
      },
      {
        path: 'contact',
        component: ContactComponent
      },
      {
        path: 'lesson',
        component: LessonComponent
      },
      {
        path: 'course-info',
        component: CourseInfoComponent
      },
      {
        path: 'user-info',
        component: UserInfoComponent
      }
    ]
  },
  { path: 'contact', component: ContactComponent }

];

@NgModule({
  imports: [
    // CommonModule
    RouterModule.forRoot(routes, { useHash: true })
  ],
  // declarations: [],
  exports: [RouterModule]
})
export class AppRoutingModule { }
