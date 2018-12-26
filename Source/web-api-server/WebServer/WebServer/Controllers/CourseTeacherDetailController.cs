using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class CourseTeacherDetailController : BaseController
    {
        // Tạo biến courseTeacherDetailReposistory để gọi các hàm từ CourseTeacherDetailReposistory
        private CourseTeacherDetailReposistory courseTeacherDetailReposistory = new CourseTeacherDetailReposistory();

        // API Thêm mới bài giảng chi tiết của giáo viên
        [Route("rest/courseteacherdetail/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertCourseTeacherDetail([FromBody] CourseTeacherDetail courseTeacherDetail)
        {
            // Chỉ cần gọi hàm từ CourseTeacherDetailReposistory và trả về
            return Ok(courseTeacherDetailReposistory.InsertCourseTeacherDetail(courseTeacherDetail));
        }

        //API Sửa thông tin chi tiết bài giảng của giáo viên
        [Route("rest/courseteacherdetail/update")]
        [HttpPost]
        public IHttpActionResult UpdateCourseTeacherDetail([FromBody] CourseTeacherDetail courseTeacherDetail)
        {
            return Ok(courseTeacherDetailReposistory.UpdateCourseTeacherDetail(courseTeacherDetail));
        }

        //API Lấy thông tin chi tiết tất cả bài giảng của giáo viên 
        [Route("rest/courseTeacherdetail/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllCourseTeacherDetailByCourseAndTeacher(long courseId, long teacherId)
        {
            return Ok(courseTeacherDetailReposistory.GetAllCourseTeacherDetailByCourseAndTeacher(courseId, teacherId));
        }

        //API Lấy thông tin chi tiết 1 bài giảng của giáo viên
        [Route("rest/courseteacherdetail/get")]
        [HttpGet]
        public IHttpActionResult GetOneCourseTeacherDetailDetail(long courseTeacherDetailId)
        {
            return Ok(courseTeacherDetailReposistory.GetOneCourseTeacherDetailById(courseTeacherDetailId));
        }

        //API Delete thông tin của 1 bài giảng của giáo viên
        [Route("rest/courseteacherdetail/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteCourseTeacherDetail(long courseTeacherDetailId)
        {
            return Ok(courseTeacherDetailReposistory.DeleteCourseTeacherDetailById(courseTeacherDetailId));
        }
    }
}