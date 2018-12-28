using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class DocumentDetailController : BaseController
    {
        // Tạo biến documentDetailReposistory để gọi các hàm từ DocumentDetailReposistory
        private DocumentDetailReposistory documentDetailReposistory = new DocumentDetailReposistory();

        // API Thêm mới thông tin chi tiết tài liệu
        [Route("rest/documentdetail/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertDocumentDetail([FromBody] DocumentDetail documentDetail)
        {
            // Chỉ cần gọi hàm từ DocumentDetailReposistory và trả về
            return Ok(documentDetailReposistory.InsertDocumentDetail(documentDetail));
        }

        //API Sửa thông tin chi tiết tài liệu
        [Route("rest/documentdetail/update")]
        [HttpPost]
        public IHttpActionResult UpdateDocumentDetail([FromBody] DocumentDetail documentDetail)
        {
            return Ok(documentDetailReposistory.UpdateDocumentDetail(documentDetail));
        }

        //API Lấy thông tin tất cả bài tập trong khóa học
        [Route("rest/documentdetail/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllDocumentDetailByCourseAndTeacher(long courseId)
        {
            return Ok(documentDetailReposistory.GetAllDocumentDetailByCourse(courseId));
        }

        //API Lấy thông tin chi tiết 1 tài liệu
        [Route("rest/documentdetail/get")]
        [HttpGet]
        public IHttpActionResult GetOneDocumentDetail(long documentDetailId)
        {
            return Ok(documentDetailReposistory.GetOneDocumentDetailById(documentDetailId));
        }

        //API Delete thông tin chi tiết 1 tài liệu
        [Route("rest/documentDetail/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteDocumentDetail(long documentDetailId)
        {
            return Ok(documentDetailReposistory.DeleteDocumentDetailById(documentDetailId));
        }
    }
}