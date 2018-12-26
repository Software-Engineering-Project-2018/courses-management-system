using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class TeacherController : BaseController
    {
        // Tạo biến teacherReposistory để gọi các hàm từ TeacherReposistory
        private TeacherReposistory teacherReposistory = new TeacherReposistory();

        // API Thêm mới giáo viên
        [Route("rest/teacher/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertTeacher([FromBody] Teacher teacher)
        {
            // Chỉ cần gọi hàm từ TeacherReposistory và trả về
            return Ok(teacherReposistory.InsertTeacher(teacher));
        }

        //API Sửa thông tin giáo viên
        [Route("rest/teacher/update")]
        [HttpPost]
        public IHttpActionResult UpdateTeacher([FromBody] Teacher teacher)
        {
            return Ok(teacherReposistory.UpdateTeacher(teacher));
        }

        //API Lấy tất cả giáo viên(tìm kiếm quản lý theo tên)
        [Route("rest/teacher/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllTeacher(string searchKeyword)
        {
            return Ok(teacherReposistory.GetAllTeacher(searchKeyword));
        }

        //API Lấy thông tin 1 giáo viên
        [Route("rest/teacher/get")]
        [HttpGet]
        public IHttpActionResult GetOneTeacher(long teacherId)
        {
            return Ok(teacherReposistory.GetOneTeacherById(teacherId));
        }

        //API Delete 1 giáo viên
        [Route("rest/teacher/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteTeacher(long teacherId)
        {
            return Ok(teacherReposistory.DeleteTeacherById(teacherId));
        }


        //API Resert password
        [Route("rest/teacher/reset-password")]
        [HttpPost]
        public IHttpActionResult ResetPassword([FromBody] Teacher teacher)
        {
            return Ok(teacherReposistory.ResetPassword(teacher));
        }
    }
}