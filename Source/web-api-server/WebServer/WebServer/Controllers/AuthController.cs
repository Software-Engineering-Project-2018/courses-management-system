
using System;
using System.Web.Http;
using WebServer.Models;
using WebServer.Repository;
using WebServer.Repository.sp;

namespace WebServer.Controllers
{
    //Kế thừa từ BaseController
    public class AuthController : BaseController
    {
        // Tạo biến systemsReposistory để gọi các hàm từ SystemsReposistory
        private SystemsReposistory systemsReposistory = new SystemsReposistory();

        //API Đăng nhập
        [Authorize]
        [Route("rest/systems/login")]
        [HttpGet]
        public IHttpActionResult Login([FromBody] dynamic data)
        {
            string userName = data.userName;
            string password = data.password;
            return Ok(systemsReposistory.Login(userName, password));
        }

        //API Đăng ký
        [Authorize]
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
    }
}