
using System.Web.Http;
using WebServer.Models;
using WebServer.Repository;

namespace WebServer.Controllers
{
    //Kế thừa từ BaseController
    public class HocSinhController : BaseController
    {
        // Tạo biến hocSinhReposistory để gọi các hàm từ HocSinhReposistory
        private HocSinhReposistory hocSinhReposistory = new HocSinhReposistory();
        
        // API Thêm mới học sinh
        [Route("rest/hoc-sinh/insert")] //Đây là chuỗi url dùng để client có gọi đến server qua url này
        [HttpPost]   //Phương thức truyền của http (Get, Post, Delete...)
        public IHttpActionResult InsertHocSinh([FromBody] HocSinh hocSinh)
        {
            // Chỉ cần gọi hàm từ hocSinhReposistory và trả về
            return Ok(hocSinhReposistory.InsertHocSinh(hocSinh));
        }

        //API Sửa thông tin học sinh
        [Route("rest/hoc-sinh/update")]
        [HttpPost]
        public IHttpActionResult UpdateHocSinh([FromBody] HocSinh hocSinh)
        {
            return Ok(hocSinhReposistory.UpdateHocSinh(hocSinh));
        }

        //API Lấy tất cả học sinh
        [Route("rest/hoc-sinh/get-all")]
        [HttpGet]
        public IHttpActionResult GetAllHocSinh()
        {
            return Ok(hocSinhReposistory.GetAllHocSinh());
        }

        //API Lấy thông tin 1 học sinh
        [Route("rest/hoc-sinh/get")]
        [HttpGet]
        public IHttpActionResult GetOneHocSinh(long hocSinhId)
        {
            return Ok(hocSinhReposistory.GetOneHocSinhById(hocSinhId));
        }

        //API Delete 1 học sinh
        [Route("rest/hoc-sinh/delete")]
        [HttpDelete]
        public IHttpActionResult DeleteHocSinh(long hocSinhId)
        {
            return Ok(hocSinhReposistory.DeleteHocSinhById(hocSinhId));
        }


        //API Resert password
        [Route("rest/hoc-sinh/reset-password")]
        [HttpPost]
        public IHttpActionResult ResetPassword([FromBody] HocSinh hocSinh)
        {
            return Ok(hocSinhReposistory.ResetPassword(hocSinh));
        }




        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool HocSinhExists(long id)
        //{
        //    return db.HocSinhs.Count(e => e.HocSinhId == id) > 0;
        //}
    }
}