using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class CourseTeacherDetailReposistory : BaseReposistory
    {

        public CourseTeacherDetail InsertCourseTeacherDetail(CourseTeacherDetail courseTeacherDetail)
        {
            //Cấu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO CourseTeacherDetail (CourseTeacherDetailId, CourseId, TeacherId) VALUES" +
                                 "(CourseTeacherDetailId = @courseTeacherDetailId, CourseId = @courseId, TeacherId = @teacherId)";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng CourseTeahcherDetail
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseTeacherDetailId", courseTeacherDetail.CourseTeacherDetailId);
                command.Parameters.AddWithValue("@courseId", courseTeacherDetail.CourseId);
                command.Parameters.AddWithValue("@teacherId", courseTeacherDetail.TeacherId);
               
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy CourseTeacherDetailId sau khi Create xong
                    courseTeacherDetail.CourseTeacherDetailId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return courseTeacherDetail;
        }

        //Hàm sửa đổi thông tin chi tiết bài giảng của giáo viên
        public CourseTeacherDetail UpdateCourseTeacherDetail(CourseTeacherDetail courseTeacherDetail)
        {
            string queryString = "UPDATE CourseTeacherDetail SET CourseId = @courseId, TeacherId = @teacherId"
                               + "  WHERE CourseTeacherDetailId = @courseTeacherDetailId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng CourseTeacherDetailId, 

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseTeacherDetailId", courseTeacherDetail.CourseTeacherDetailId);
                command.Parameters.AddWithValue("@courseId", courseTeacherDetail.CourseId);
                command.Parameters.AddWithValue("@teacherId", courseTeacherDetail.TeacherId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return courseTeacherDetail;
        }

        //hàm lấy danh sách bài giảng tiết của tất cả giáo viên
        public List<CourseTeacherDetail> GetAllCourseTeacherDetailByCourseAndTeacher(long teacherId, long courseId)
        {
            //Giá trị trả về của hàm này: List<CourseTeacherDetail>
            List<CourseTeacherDetail> queryResult = new List<CourseTeacherDetail>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM CourseTeacherDetail WHERE CourseId like '%' + @courseId + '%' OR TeacherId like '%' + @teacherId + '%'";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseId", courseId);
                command.Parameters.AddWithValue("@teacherId", teacherId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    CourseTeacherDetail entity = new CourseTeacherDetail();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["CourseTeacherDetailId"] != DBNull.Value)
                    {
                        entity.CourseTeacherDetailId = (long)reader["CourseTeacherDetailId"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        entity.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["TeacherId"] != DBNull.Value)
                    {
                        entity.TeacherId = (long)reader["TeacherId"];
                    }
                   //Thêm entity vào list trả về
                    queryResult.Add(entity);
                }

                //Đóng kết nối
                reader.Close();
                connection.Close();
            }

            //Trả về kết quả
            return queryResult;
        }


        //hàm lấy thông tin chi tiết bài giảng của giáo viên theo mã giáo viên
        public CourseTeacherDetail GetOneCourseTeacherDetailById(long courseTeacherDetailId)
        {
            //Giá trị trả về của hàm này
            CourseTeacherDetail queryResult = new CourseTeacherDetail();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM CourseTeacherDetail WHERE CourseTeacherDetailId = @courseTeacherDetailId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là courseTeacherDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseTeacherDetailId", courseTeacherDetailId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["CourseTeacherDetailId"] != DBNull.Value)
                    {
                        queryResult.CourseTeacherDetailId = (long)reader["CourseTeacherDetailId"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        queryResult.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["TeacherId"] != DBNull.Value)
                    {
                        queryResult.TeacherId = (long)reader["TeacherId"];
                    }
                        }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }


        //Hàm xóa thông tin chi tiết 1 bài giảng của giáo viên
        public long DeleteCourseTeacherDetailById(long courseTeacherDetailId)
        {
            // Hàm trả về courseTeacherDetailId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM CourseTeacherDetail WHERE CourseTeacherDetailId = @courseTeacherDetailId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là CourseTeacherDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseTeacherDetailId", courseTeacherDetailId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về CourseTeacherDetailId
            return courseTeacherDetailId;
        }

    }
}