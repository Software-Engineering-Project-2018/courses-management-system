﻿
using System;
using System.Security.Claims;
using System.Web.Http;
using WebServer.Models;
using WebServer.Repository;
using WebServer.Repository.sp;

namespace WebServer.Controllers
{
    // AuthController chứa các API hệ thống
    // AuthController Kế thừa từ BaseController
    public class AuthController : BaseController
    {
        // Tạo biến systemsReposistory để gọi các hàm từ SystemsReposistory
        private SystemsReposistory systemsReposistory = new SystemsReposistory();

        //API Đăng nhập
        //[Authorize]
        //[Route("rest/systems/login")]
        ////[HttpGet]
        //public IHttpActionResult Login([FromBody] dynamic data)
        //{
        //    string userName = data.userName;
        //    string password = data.password;
        //    return Ok(systemsReposistory.Login(userName, password));
        //}

        //API Đăng ký
        [Authorize]
        [Route("rest/systems/register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody] dynamic data)
        {
            long userType = data.userType;  //Loại người dùng Quản lý/ Học sinh/ Giáo viên/ phụ huynh
            string userName = data.userName;
            string identificationCode = null;    //Mã học sinh/ Mã giao viên
            if (data.identificationCode != null)
            {
                identificationCode = data.identificationCode;
            }
            string password = data.password;
            string fullName = data.fullName;
            long gender = data.gender;
            DateTime birthDay = data.birthDay;
            string phone = data.phone;
            string email = data.email;
            string address = data.address;
            string avatar = data.avatar;
            return Ok(systemsReposistory.Register(userType, identificationCode, userName, password,
                fullName, gender, birthDay, phone, email, address, avatar));
        }

        //API Get thông tin user đăng nhập
        [Route("rest/systems/get-user-info")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetUserInfo()
        {
            ClaimsIdentity identityClaims = (ClaimsIdentity)User.Identity;
            long userId = Int64.Parse(identityClaims.FindFirst("UserId").Value);
            long userType = Int64.Parse(identityClaims.FindFirst("UserType").Value);

            return Ok(systemsReposistory.GetUserInfo(userType, userId));
        }
        //API Đăng ký
        [Authorize]
        [Route("rest/systems/change-password")]
        [HttpPost]
        public IHttpActionResult ChangePassword([FromBody] dynamic data)
        {
            long userType = data.user.UserType;
            string userName = data.user.UserName;
            string oldPw = data.oldPw;
            string newPw = data.newPw;
            return Ok(systemsReposistory.ChangePassword(userType, userName, oldPw, newPw));
        }
    }
}