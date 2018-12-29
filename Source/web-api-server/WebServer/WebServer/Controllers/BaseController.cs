
using System;
using System.Security.Claims;
using System.Web.Http;
using WebServer.Models;
using WebServer.Repository.sp;

namespace WebServer.Controllers
{
    // BaseController sẽ định nghĩa các phương thức, biến dùng chung
    // BaseController kế thừa từ ApiController có sẵn
    public class BaseController : ApiController
    {
        protected CoursesSystemEntities db = new CoursesSystemEntities();

        public UserBaseDto GetUserLogin()
        {
            ClaimsIdentity identityClaims = (ClaimsIdentity)User.Identity;
            UserBaseDto user = new UserBaseDto()
            {
                UserId = Int64.Parse(identityClaims.FindFirst("UserId").Value),
                UserType = Int64.Parse(identityClaims.FindFirst("UserType").Value)
            };
            return user;
        }
    }
}