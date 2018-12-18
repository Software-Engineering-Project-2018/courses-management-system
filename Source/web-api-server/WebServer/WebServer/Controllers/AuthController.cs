
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
        [Route("rest/systems/login")]
        [HttpGet]
        public IHttpActionResult Login([FromBody] dynamic data)
        {
            string userName = data.userName;
            string password = data.password;
            return Ok(systemsReposistory.Login(userName, password));
        }

        //API Đăng ký
        [Route("rest/systems/register")]
        [HttpGet]
        public IHttpActionResult Register([FromBody] dynamic data)
        {
            long userType = data.userType;  //Loại người dùng Quản lý/ Học sinh/ Giáo viên/ phụ huynh
            string userName = data.userName;
            string password = data.password;
            string fullName = data.fullName;
            long gender = data.gender;
            DateTime birthDay = data.birthDay;
            string phone = data.phone;
            string email = data.email;
            string address = data.address;
            return Ok(systemsReposistory.Register(userType, userName, password,
                fullName, gender, birthDay, phone, email, address));
        }

        //API Get thông tin user đăng nhập
        [Route("rest/systems/get-user-info")]
        [HttpGet]
        public IHttpActionResult GetUserInfo()
        {
            ClaimsIdentity identityClaims = (ClaimsIdentity)User.Identity; 
            long userType = Int64.Parse(identityClaims.FindFirst("UserType").Value);
            long userId = Int64.Parse(identityClaims.FindFirst("UserId").Value);

            return Ok(systemsReposistory.GetUserInfo(userType, userId));
        }
    }
}