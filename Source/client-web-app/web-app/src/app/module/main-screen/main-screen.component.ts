import { Component, OnInit, Injector } from '@angular/core';
import * as $ from 'jquery';
import { BaseComponent } from '../base/base.component';
import { ɵshimContentAttribute } from '@angular/platform-browser';
@Component({
  selector: 'app-main-screen',
  templateUrl: './main-screen.component.html',
  styleUrls: ['./main-screen.component.css']
})
export class MainScreenComponent extends BaseComponent implements OnInit {

  isMobile = false;
  userTypeName = 'Không xác định';
  defaultAvatar = '../../../assets/user.jpg';
  constructor(public injector: Injector) {
    super(injector);
  }

  ngOnInit() {
    if (window.screen.width < 768) { // 768px portrait
      this.isMobile = true;
    }
    // Dropdown menu
    $('.sidebar-dropdown > a').click(function () {
      $('.sidebar-submenu').slideUp(200);
      if ($(this).parent().hasClass('active')) {
        $('.sidebar-dropdown').removeClass('active');
        $(this).parent().removeClass('active');
      } else {
        $('.sidebar-dropdown').removeClass('active');
        $(this).next('.sidebar-submenu').slideDown(200);
        $(this).parent().addClass('active');
      }

    });

    // close sidebar
    $('#close-sidebar').click(function () {
      $('.page-wrapper').removeClass('toggled');
    });
    // $('.sidebar-submenu > ul > li > a').click(function () {
    //   $('.page-wrapper').removeClass('toggled');
    // });
    // $('.not-contain-submenu>a').click(function () {
    //   $('.page-wrapper').removeClass('toggled');
    // });

    // show sidebar
    $('#show-sidebar').click(function () {
      $('.page-wrapper').addClass('toggled');
    });

    // hide sidebar on mobile
    if ($(window).width() <= 768) {
      $('.page-wrapper').removeClass('toggled');
    }
    // // switch between themes
    // var themes = 'chiller-theme ice-theme cool-theme light-theme';
    // $('[data-theme]').click(function () {
    //   $('[data-theme]').removeClass('selected');
    //   $(this).addClass('selected');
    //   $('.page-wrapper').removeClass(themes);
    //   $('.page-wrapper').addClass($(this).attr('data-theme'));
    // });

    // // switch between background images
    // var bgs = 'bg1 bg2 bg3 bg4';
    // $('[data-bg]').click(function () {
    //   $('[data-bg]').removeClass('selected');
    //   $(this).addClass('selected');
    //   $('.page-wrapper').removeClass(bgs);
    //   $('.page-wrapper').addClass($(this).attr('data-bg'));
    // });

    // toggle background image
    // $('#toggle-bg').change(function (e) {
    //   e.preventDefault();
    //   $('.page-wrapper').toggleClass('sidebar-bg');
    // });

    // custom scroll bar is only used on desktop
    // if (!/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
    //   $('.sidebar-content').mCustomScrollbar({
    //     axis: 'y',
    //     autoHideScrollbar: true,
    //     scrollInertia: 300
    //   });
    //   $('.sidebar-content').addClass('desktop');

    // }
    // if (this.userInfo.UserType) {
    //   switch (this.userInfo.UserType) {
    //     case 1: this.userTypeName = 'Admministrator';
    //       break;
    //     case 2: this.userTypeName = 'Giáo viên';
    //       break;
    //     case 3: this.userTypeName = 'Học sinh';
    //       break;
    //     case 4: this.userTypeName = 'Phụ huynh';
    //       break;
    //   }
    // }
  }

  logOutOnClick() {
    this.logOut();
    this.router.navigate(['/']);
  }
}
