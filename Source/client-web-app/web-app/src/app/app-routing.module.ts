import { NgModule } from '@angular/core';
// import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './module/home-page/home-page.component';
import { LoginComponent } from './module/login/login.component';
import { DashboardComponent } from './module/dashboard/dashboard.component';
import { ContactComponent } from './module/contact/contact.component';
import { ForgotPasswordComponent } from './module/forgot-password/forgot-password.component';
import { RegisterComponent } from './module/register/register.component';
import { CoursesComponent } from './module/courses/courses.component';
import { SettingComponent } from './module/setting/setting/setting.component';
import { ProfileComponent } from './module/profile/profile.component';

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
    component: DashboardComponent,
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
      }
    ]
  },
  { path: 'contact', component: ContactComponent }

];

@NgModule({
  imports: [
    // CommonModule
    RouterModule.forRoot(routes, {useHash: true})
  ],
  // declarations: [],
  exports: [RouterModule]
})
export class AppRoutingModule { }
