using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class ParentController : BaseController
    {
        // Tạo biến parentReposistory để gọi các hàm từ ParentReposistory
        private ParentReposistory parentReposistory = new ParentReposistory();

        // API Thêm mới phụ huynh của học sinh
        [Route("rest/parent/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertPhuHuynh([FromBody] Parent parent)
        {
            // Chỉ cần gọi hàm từ ParentReposistory và trả về
            return Ok(parentReposistory.InsertParent(parent));
        }

        //API Sửa thông tin phụ huynh
        [Route("rest/parent/update")]
        [HttpPost]
        public IHttpActionResult UpdateParent([FromBody] Parent parent)
        {
            return Ok(parentReposistory.UpdateParent(parent));
        }

        //API Lấy tất cả phụ huynh(tìm kiếm phụ huynh theo tên)
        [Route("rest/parent/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllParent(string searchKeyword)
        {
            return Ok(parentReposistory.GetAllParent(searchKeyword));
        }

        //API Lấy thông tin 1 phụ huynh
        [Route("rest/parent/get")]
        [HttpGet]
        public IHttpActionResult GetOnePhuHuynh(long parentId)
        {
            return Ok(parentReposistory.GetOneParentById(parentId));
        }

        //API Delete 1 phụ huynh
        [Route("rest/parent/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteParent(long parentId)
        {
            return Ok(parentReposistory.DeleteParentById(parentId));
        }

        //API Lấy tất cả phụ huynh của học sinh(tìm kiếm phụ huynh theo Id của học sinh)
        [Route("rest/parent/get-all-by-student")]
        [HttpGet]
        public IHttpActionResult GetAllParentByStudentId(long studentId)
        {
            return Ok(parentReposistory.GetAllParentByStudentId(studentId));
        }


        //API Resert password
        [Route("rest/parent/reset-password")]
        [HttpPost]
        public IHttpActionResult ResetPassword(long parentId)
        {
            return Ok(parentReposistory.ResetPassword(parentId));
        }
    }
}