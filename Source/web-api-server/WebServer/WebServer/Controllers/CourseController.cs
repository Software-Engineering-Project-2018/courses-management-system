using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class CourseController : BaseController
    {
        // Tạo biến courseReposistory để gọi các hàm từ CourseReposistory
        private CourseReposistory courseReposistory = new CourseReposistory();

        // API Thêm mới khóa học 
        [Route("rest/course/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertCourse([FromBody] Course course)
        {
            // Chỉ cần gọi hàm từ CourseReposistory và trả về
            return Ok(courseReposistory.InsertCourse(course));
        }

        //API Sửa thông tin khóa học
        [Route("rest/course/update")]
        [HttpPost]
        public IHttpActionResult UpdateCourse([FromBody] Course course)
        {
            return Ok(courseReposistory.UpdateCourse(course));
        }

        //API Lấy tất cả khóa học(tìm kiếm quản lý theo tên)
        [Route("rest/course/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllCourse(string searchKeyword)
        {
            return Ok(courseReposistory.GetAllCourse(searchKeyword));
        }

        //API Lấy thông tin 1 khóa học
        [Route("rest/teacher/get")]
        [HttpGet]
        public IHttpActionResult GetOneCourse(long courseId)
        {
            return Ok(courseReposistory.GetOneCourseById(courseId));
        }

        //API Delete 1 khóa học
        [Route("rest/course/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteCourse(long courseId)
        {
            return Ok(courseReposistory.DeleteCourseById(courseId));
        }
    }
}