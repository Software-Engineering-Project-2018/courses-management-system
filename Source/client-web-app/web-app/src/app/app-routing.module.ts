import { NgModule } from '@angular/core';
// import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './module/system-components/home-page/home-page.component';
import { LoginComponent } from './module/system-components/login/login.component';
import { RegisterComponent } from './module/system-components/register/register.component';
import { ForgotPasswordComponent } from './module/system-components/forgot-password/forgot-password.component';
import { ProfileComponent } from './module/user-components/profile/profile.component';
import { CourseListComponent } from './module/user-components/course-list/course-list.component';
import { SettingComponent } from './module/user-components/setting/setting.component';
import { ContactComponent } from './module/system-components/contact/contact.component';
import { MainScreenComponent } from './module/main-screen/main-screen.component';
import { DashboardComponent } from './module/system-components/dashboard/dashboard.component';
import { ScoreboardComponent } from './module/user-components/scoreboard/scoreboard.component';
import { StudentListComponent } from './module/user-components/student-list/student-list.component';
import { TeacherListComponent } from './module/user-components/teacher-list/teacher-list.component';
import { IncomeComponent } from './module/user-components/income/income.component';
import { ChangepasswordComponent } from './module/user-components/changepassword/changepassword.component';
import { TaskComponent } from './module/user-components/task/task.component';
import { CourseInfoComponent } from './module/user-components/course-info/course-info.component';
import { UserInfoComponent } from './module/user-components/user-info/user-info.component';
import { EnrollCourseComponent } from './module/user-components/enroll-course/enroll-course.component';
import { AuthGuard } from './services/auth-guard';
import { CourseNotificationListComponent } from './module/user-components/notification-list/courses-notification-list.component';
import { GeneralNotificationListComponent } from './module/user-components/notification-list/general-notification-list.component';
import { NotificationInfoComponent } from './module/user-components/notification-info/notification-info.component';
import { MyCourseListComponent } from './module/user-components/course-list/my-course-list.component';
import { CourseStudentListComponent } from './module/user-components/course-student-list/course-student-list.component';
import { TutitionFeeComponent } from './module/user-components/tutition-fee/tutition-fee.component';

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
        path: 'courses-notification',
        component: CourseNotificationListComponent
      },
      {
        path: 'general-notification',
        component: GeneralNotificationListComponent
      },
      {
        path: 'notification',
        component: NotificationInfoComponent
      },
      {
        path: 'courses',
        component: CourseListComponent
      },
      {
        path: 'course-students',
        component: CourseStudentListComponent
      },
      {
        path: 'my-courses',
        component: MyCourseListComponent
      },
      {
        path: 'scoreboard',
        component: ScoreboardComponent
      },
      {
        path: 'students',
        component: StudentListComponent
      },
      {
        path: 'teachers',
        component: TeacherListComponent
      },
      {
        path: 'income',
        component: IncomeComponent
      },
      {
        path: 'tutition',
        component: TutitionFeeComponent
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
        path: 'task',
        component: TaskComponent
      },
      {
        path: 'course-info',
        component: CourseInfoComponent
      },
      {
        path: 'enroll-course',
        component: EnrollCourseComponent
      },
      {
        path: 'user-info',
        component: UserInfoComponent
      }
    ],
    canActivate: [AuthGuard] // khai báo AuthGuard
  },
  { path: 'contact', component: ContactComponent }

];

@NgModule({
  imports: [
    // CommonModule
    RouterModule.forRoot(routes, { useHash: true })
  ],
  // declarations: [],
  providers: [
    AuthGuard
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
