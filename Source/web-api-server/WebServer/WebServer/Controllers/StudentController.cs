
using System.Web.Http;
using WebServer.Models;
using WebServer.Repository;

namespace WebServer.Controllers
{
    //Kế thừa từ BaseController
    public class StudentController : BaseController
    {
        // Tạo biến hocSinhReposistory để gọi các hàm từ HocSinhReposistory
        private StudentReposistory studentReposistory = new StudentReposistory();

        // API Thêm mới học sinh
        [Route("rest/student/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertHocSinh([FromBody] Student student)
        {
            // Chỉ cần gọi hàm từ studentReposistory và trả về
            return Ok(studentReposistory.InsertStudent(student));
        }

        //API Sửa thông tin học sinh
        [Route("rest/student/update")]
        [HttpPost]
        public IHttpActionResult UpdateStudent([FromBody] Student student)
        {
            return Ok(studentReposistory.UpdateStudent(student));
        }

        //API Lấy tất cả học sinh(tìm kiếm học sinh theo tên)
        [Route("rest/student/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllStudent(string searchKeyword)
        {
            return Ok(studentReposistory.GetAllStudent(searchKeyword));
        }

        //API Lấy thông tin 1 học sinh
        [Route("rest/student/get")]
        [HttpGet]
        public IHttpActionResult GetOneHocSinh(long studentId)
        {
            return Ok(studentReposistory.GetOneStudentById(studentId));
        }

        //API Delete 1 học sinh
        [Route("rest/student/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteStudent(long studentId)
        {
            return Ok(studentReposistory.DeleteStudentById(studentId));
        }


        //API Resert password
        [Route("rest/student/reset-password")]
        [HttpPost]
        public IHttpActionResult ResetPassword([FromBody] Student student)
        {
            return Ok(studentReposistory.ResetPassword(student));
        }

       
    }
}