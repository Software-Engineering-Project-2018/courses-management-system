using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Repository;
using System.Web.Http;
using WebServer.Models;
using WebServer.Repository.sp;

namespace WebServer.Controllers
{
    public class NotificationController : BaseController
    {
        // Tạo biến notificationReposistory để gọi các hàm từ NotificationReposistory
        private NotificationReposistory notificationReposistory = new NotificationReposistory();

        // API Thêm mới thông báo
        [Route("rest/notification/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertNotification([FromBody] Notification notification)
        {
            // Chỉ cần gọi hàm từ NotificationReposistory và trả về
            return Ok(notificationReposistory.InsertNotification(notification));
        }

        //API Sửa thông báo
        [Route("rest/notification/update")]
        [HttpPost]
        public IHttpActionResult UpdateNotification([FromBody] Notification notification)
        {
            return Ok(notificationReposistory.UpdateNotification(notification));
        }

        //API Lấy tất cả thông báo chung
        [Route("rest/notification/get-general")]
        [HttpGet]
        public IHttpActionResult GetAllGeneralNotification(string searchKeyword)
        {
            return Ok(notificationReposistory.GetAllGeneralNotification(searchKeyword));
        }

        //API Lấy tất cả thông báo từ khóa học mà học sinh tham gia
        [Route("rest/notification/get-course")]
        [HttpGet]
        public IHttpActionResult GetAllCourseNotification(string searchKeyword)
        {
            UserBaseDto user = this.GetUserLogin();
            return Ok(notificationReposistory.GetAllCourseNotification(searchKeyword, user.UserId));
        }

        //API Lấy thông tin chi tiết thông báo
        [Route("rest/notification/get")]
        [HttpGet]
        public IHttpActionResult GetOneNotification(long notificationId)
        {
            return Ok(notificationReposistory.GetOneNotificationById(notificationId));
        }

        //API Delete thông báo
        [Route("rest/notification/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteNotification(long notificationId)
        {
            return Ok(notificationReposistory.DeleteNotificationById(notificationId));
        }
    }
}