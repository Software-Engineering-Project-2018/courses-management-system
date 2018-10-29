import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomePageComponent } from './module/home-page/home-page.component';
import { LoginComponent } from './module/login/login.component';
import { RegisterComponent } from './module/register/register.component';
import { AppRoutingModule } from './app-routing.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { DashboardComponent } from './module/dashboard/dashboard.component';
import { ContactComponent } from './module/contact/contact.component';
import { ForgotPasswordComponent } from './module/forgot-password/forgot-password.component';
import { CoursesComponent } from './module/courses/courses.component';
import { SettingComponent } from './module/setting/setting/setting.component';
import { ProfileComponent } from './module/profile/profile.component';
import { BaseComponent } from './module/base/base/base.component';
import { HocSinhService } from './services/hoc-sinh.service';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent,
    ContactComponent,
    ForgotPasswordComponent,
    CoursesComponent,
    SettingComponent,
    ProfileComponent,
    BaseComponent
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
