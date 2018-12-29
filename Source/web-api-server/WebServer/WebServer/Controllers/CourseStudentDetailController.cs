using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class CourseStudentDetailController : BaseController
    {
        // Tạo biến courseStudentDetailReposistory để gọi các hàm từ CourseStudentDetailReposistory
        private CourseStudentDetailReposistory courseStudentDetailReposistory = new CourseStudentDetailReposistory();

        // API Thêm mới khóa học chi tiết cfhco học sinh
        [Route("rest/course-student-detail/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertCourseStudentDetail([FromBody] CourseStudentDetail courseStudentDetail)
        {
            // Chỉ cần gọi hàm từ CourseStudentDetailReposistory và trả về
            return Ok(courseStudentDetailReposistory.InsertCourseStudentDetail(courseStudentDetail));
        }

        //API Sửa thông tin chi tiết khóa học
        [Route("rest/course-student-detail/update")]
        [HttpPost]
        public IHttpActionResult UpdateCourseStudentDetail([FromBody] CourseStudentDetail courseStudentDetail)
        {
            return Ok(courseStudentDetailReposistory.UpdateCourseStudentDetail(courseStudentDetail));
        }

        //API Lấy thông tin chi tiết khoá học theo mã khóa học và theo học sinh
        [Route("rest/course-student-detail/get-all-by-student")]
        [HttpGet]
        public IHttpActionResult GetAllCourseStudentDetailByStudent(string studentId)
        {
            return Ok(courseStudentDetailReposistory.GetAllCourseStudentDetailByStudent(long.Parse(studentId)));
        }

        //API Lấy thông tin chi tiết khoá học theo mã khóa học và theo học sinh
        [Route("rest/course-student-detail/get-all-by-course")]
        [HttpPost]
        public IHttpActionResult GetAllCourseStudentDetailByCourse([FromBody] dynamic data)
        {
            string searchKeyword = data.searchKeyword;
            long courseId = data.courseId;
            return Ok(courseStudentDetailReposistory.GetAllCourseStudentDetailByCourse(searchKeyword, courseId));
        }

        //API Lấy thông tin chi tiết 1 khóa học của học sinh
        [Route("rest/course-student-detail/get")]
        [HttpGet]
        public IHttpActionResult GetOneDocumentDetail(long courseStudentDetailId)
        {
            return Ok(courseStudentDetailReposistory.GetOneCourseStudentDetailById(courseStudentDetailId));
        }

        //API Delete thông tin của 1 khóa học của học sinh
        [Route("rest/course-student-detail/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteCourseStudentDetail(long courseStudentDetailId)
        {
            return Ok(courseStudentDetailReposistory.DeleteCourseStudentDetailById(courseStudentDetailId));
        }
    }
}