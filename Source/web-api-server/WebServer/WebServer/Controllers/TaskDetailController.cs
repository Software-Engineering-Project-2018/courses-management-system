using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class TaskDetailController : BaseController
    {
        // Tạo biến taskDetailReposistory để gọi các hàm từ TaskDetailReposistory
        private TaskDetailReposistory taskDetailReposistory = new TaskDetailReposistory();

        // API Thêm mới thông tin chi tiết bài tập
        [Route("rest/task-detail/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertTaskDetail([FromBody] TaskDetail taskDetail)
        {
            // Chỉ cần gọi hàm từ TaskDetailReposistory và trả về
            return Ok(taskDetailReposistory.InsertTaskDetail(taskDetail));
        }

        //API Sửa thông tin chi tiết bài tập
        [Route("rest/task-detail/update")]
        [HttpPost]
        public IHttpActionResult UpdateTaskDetail([FromBody] TaskDetail taskDetail)
        {
            return Ok(taskDetailReposistory.UpdateTaskDetail(taskDetail));
        }

        //API Lấy thông tin chi tiết tất cả bài tập theo mã bài tập và mã học sinh

        [Route("rest/task-detail/get-all-by-student-task")]
        [HttpPost]
        public IHttpActionResult GetAllTaskdetailByTaskAndStudent([FromBody] dynamic data)
        {
            long taskId = data.taskId;
            long studentId = data.studentId;
            return Ok(taskDetailReposistory.GetAllTaskDetailByTaskAndStudent(taskId, studentId));
        }

        //API Lấy thông tin chi tiết 1 bài tập
        [Route("rest/task-detail/get")]
        [HttpGet]
        public IHttpActionResult GetOneTakeDetail(long taskDetailId)
        {
            return Ok(taskDetailReposistory.GetOneTaskDetailById(taskDetailId));
        }

        //API Delete thông tin 1 bài tập
        [Route("rest/task-detail/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteTaskDetail(long taskDetailId)
        {
            return Ok(taskDetailReposistory.DeleteTaskDetailById(taskDetailId));
        }

    }
}