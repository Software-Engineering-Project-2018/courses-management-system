using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class TaskController : BaseController
    {
        // Tạo biến taskReposistory để gọi các hàm từ TaskReposistory
        private TaskReposistory taskReposistory = new TaskReposistory();

        // API Thêm mới bài tập
        [Route("rest/task/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertTask([FromBody] Task task)
        {
            // Chỉ cần gọi hàm từ TaskReposistory và trả về
            return Ok(taskReposistory.InsertTask(task));
        }

        //API Sửa thông tin bài tập
        [Route("rest/task/update")]
        [HttpPost]
        public IHttpActionResult UpdateTask([FromBody] Task task)
        {
            return Ok(taskReposistory.UpdateTask(task));
        }

        //API Lấy tất cả bài tập(tìm kiếm quản lý theo tên)
        [Route("rest/task/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllTask(string searchKeyword)
        {
            return Ok(taskReposistory.GetAllTask(searchKeyword));
        }

        //API Lấy thông tin 1 bài tập
        [Route("rest/task/get")]
        [HttpGet]
        public IHttpActionResult GetOneCourse(long taskId)
        {
            return Ok(taskReposistory.GetOneTaskById(taskId));
        }

        //API Delete 1 bài tập
        [Route("rest/task/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteTask(long taskId)
        {
            return Ok(taskReposistory.DeleteTaskById(taskId));
        }
    }
}