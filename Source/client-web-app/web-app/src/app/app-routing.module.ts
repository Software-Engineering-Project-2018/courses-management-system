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

const routes: Routes = [
  // {
  //   path: '',
  //   redirectTo: '/home/hang-hoa/xuat-ban-hang-hoa',
  //   pathMatch: 'full'
  // },
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
        component: ProfileComponent
      },
      {
        path: 'courses',
        component: CoursesComponent
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
        path: 'notification',
        component: NotificationComponent
      },
      {
        path: 'contact',
        component: ContactComponent
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
