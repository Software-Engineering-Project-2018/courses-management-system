
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    // BaseController sẽ định nghĩa các phương thức, biến dùng chung
    // BaseController kế thừa từ ApiController có sẵn
    public class BaseController : ApiController
    {
        protected CoursesSystemEntities db = new CoursesSystemEntities();

    }
}