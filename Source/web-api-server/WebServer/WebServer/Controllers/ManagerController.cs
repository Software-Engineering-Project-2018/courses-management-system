using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class Managerontroller : BaseController
    {
        // Tạo biến managerReposistory để gọi các hàm từ ManagerReposistory
        private ManagerReposistory managerReposistory = new ManagerReposistory();

        // API Thêm mới quản lý
        [Route("rest/manager/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertQuanLy([FromBody] Manager manager)
        {
            // Chỉ cần gọi hàm từ ManagerReposistory và trả về
            return Ok(managerReposistory.InsertManager(manager));
        }

        //API Sửa thông tin quản lý
        [Route("rest/manager/update")]
        [HttpPost]
        public IHttpActionResult UpdateManager(Manager manager)
        {
            return Ok(managerReposistory.UpdateManager(manager));
        }

        //API Lấy tất cả quản lý(tìm kiếm quản lý theo tên)
        [Route("rest/manager/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllManager(string searchKeyword)
        {
            return Ok(managerReposistory.GetAllManager(searchKeyword));
        }

        //API Lấy thông tin 1 quản lý
        [Route("rest/manager/get")]
        [HttpGet]
        public IHttpActionResult GetOneQuanLy(long managerId)
        {
            return Ok(managerReposistory.GetOneManagerById(managerId));
        }

        //API Delete 1 quản lý
        [Route("rest/manager/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteManager(long managerId)
        {
            return Ok(managerReposistory.DeleteManagerById(managerId));
        }


        //API Resert password của quản lí
        [Route("rest/manager/reset-password")]
        [HttpPost]
        public IHttpActionResult ResetPassword(long managerId)
        {
            return Ok(managerReposistory.ResetPassword(managerId));
        }
    }
}