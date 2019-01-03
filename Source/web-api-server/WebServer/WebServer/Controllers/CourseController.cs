using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;
using System.Net.Http;
using System.Threading.Tasks;

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

        //API Lấy tất cả khóa(tìm kiếm khóa học theo tên)
        [Route("rest/course/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllParent(string searchKeyword)
        {
            return Ok(courseReposistory.GetAllCourse(searchKeyword));
        }

        //API Lấy tất cả khóa học đã tham gia(tìm kiếm quản lý theo tên)
        [Route("rest/course/get-all-joined")]
        [HttpPost]
        public IHttpActionResult GetAllCourseJoined([FromBody] dynamic data)
        {
            string searchKeyword = data.searchKeyword;
            long studentId = data.studentId;
            return Ok(courseReposistory.GetAllCourseJoined(searchKeyword, studentId));
        }

        //API Lấy tất cả khóa học chưa đã tham gia(tìm kiếm quản lý theo tên)
        [Route("rest/course/get-all-not-joined")]
        [HttpPost]
        public IHttpActionResult GetAllCourseNotJoined([FromBody] dynamic data)
        {
            string searchKeyword = data.searchKeyword;
            long studentId = data.studentId;
            return Ok(courseReposistory.GetAllCourseNotJoined(searchKeyword, studentId));
        }

        //API Lấy thông tin 1 khóa học
        [Route("rest/course/get")]
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
        
        //API Lấy danh sách khoá học mà học sinh đã tham gia
        [Route("rest/course/get-by-student-id")]
        [HttpGet]
        public IHttpActionResult GetAllCourseByStudent(long studentId)
        {
            return Ok(courseReposistory.GetAllCourseByStudent(studentId));
        }

        //API Lấy danh sách khoá học mà giáo viên đã tham gia
        [Route("rest/course/get-by-teacher-id")]
        [HttpPost]
        public IHttpActionResult GetAllCourseByTeacher([FromBody] dynamic data)
        {
            long teacherId = data.teacherId;
            string searchKeyword = data.searchKeyword;
            return Ok(courseReposistory.GetAllCourseByTeacher(teacherId, searchKeyword));
        }

        [HttpPost]
        [Route("rest/file/upload")]
        [System.Web.Http.Authorize]
        //public async Task<System.Web.Mvc.ActionResult> UploadFiles()
        //{
        //    var file = HttpContext.Current.Request.Files[0];
        //    //...
        //    return null;
        //}
        public IHttpActionResult UploadFiles()
        {
            int i = 0;
            var uploadedFileNames = new List<string>();
            HttpResponseMessage response = new HttpResponseMessage();

            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[i];
                    var filePath = HttpContext.Current.Server.MapPath("~/File/Data/" + postedFile.FileName);
                    try
                    {
                        postedFile.SaveAs(filePath);
                        uploadedFileNames.Add(httpRequest.Files[i].FileName);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    i++;
                }
            }

            return Ok(uploadedFileNames);
        }

        [HttpPost]
        [Route("rest/file/download")]
        [System.Web.Http.Authorize]
        public IHttpActionResult DownloadFiles()
        {
            int i = 0;
            var uploadedFileNames = new List<string>();
            //HttpResponseMessage response = new HttpResponseMessage();

            //var httpRequest = HttpContext.Current.Request;
            //if (httpRequest.Files.Count > 0)
            //{
            //    foreach (string file in httpRequest.Files)
            //    {
            //        var postedFile = httpRequest.Files[i];
            //        var filePath = HttpContext.Current.Server.MapPath("~/File/Data/" + postedFile.FileName);
            //        try
            //        {
            //            postedFile.SaveAs(filePath);
            //            uploadedFileNames.Add(httpRequest.Files[i].FileName);
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
            //        i++;
            //    }
            //}

            return Ok(uploadedFileNames);
        }

    }
}