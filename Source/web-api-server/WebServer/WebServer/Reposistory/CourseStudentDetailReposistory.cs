using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class CourseStudentDetailReposistory : BaseReposistory
    {
      
        public CourseStudentDetail InsertCourseStudentDetail(CourseStudentDetail courseStudentDetail)
        {
            //Cấu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO CourseStudentDetail (CourseId, StudentId, FinalScore) VALUES" +
                                 "(@courseId, @studentId, @finalScore) SELECT @@IDENTITY";
                                 
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng CourseStudentDetail
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseId", courseStudentDetail.Course.CourseId);
                command.Parameters.AddWithValue("@studentId", courseStudentDetail.Student.UserId);
                command.Parameters.AddWithValue("@finalScore", courseStudentDetail.FinalScore == null ? (object)DBNull.Value : courseStudentDetail.FinalScore);
                
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy CourseStudentDetailId sau khi Create xong
                    courseStudentDetail.CourseStudentDetailId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return courseStudentDetail;
        }

        public CourseStudentDetail UpdateCourseStudentDetail(CourseStudentDetail courseStudentDetail)
        {
            string queryString = "UPDATE CourseStudentDetail SET CourseId = @courseId, StudentId = @studentId, FinalScore = @finalScore"
                               + "  WHERE CourseStudentDetailId = @courseStudentDetailId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng CourseStudentDetailId, 

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseStudentDetailId", courseStudentDetail.CourseStudentDetailId);
                command.Parameters.AddWithValue("@courseId", courseStudentDetail.CourseId);
                command.Parameters.AddWithValue("@studentId", courseStudentDetail.StudentId);
                command.Parameters.AddWithValue("@finalScore", courseStudentDetail.FinalScore);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return courseStudentDetail;
        }


        public List<CourseStudentDetail> GetAllCourseStudentDetailByStudent(long studentId, DateTime fromDate, DateTime toDate)
        {
            //Giá trị trả về của hàm này: List<CourseStudentDetail>
            List<CourseStudentDetail> queryResult = new List<CourseStudentDetail>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM CourseStudentDetail csd JOIN COURSE c ON csd.CourseId = c.CourseId WHERE StudentId = @studentId AND ((c.DateStart BETWEEN @fromDate AND @toDate) OR (c.DateEnd BETWEEN @fromDate AND @toDate))";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@studentId", studentId);
                command.Parameters.AddWithValue("@fromDate", fromDate);
                command.Parameters.AddWithValue("@toDate", toDate);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    CourseStudentDetail entity = new CourseStudentDetail();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["CourseStudentDetailId"] != DBNull.Value)
                    {
                        entity.CourseStudentDetailId = (long)reader["CourseStudentDetailId"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        entity.Course.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["StudentId"] != DBNull.Value)
                    {
                        entity.Student.UserId = (long)reader["StudentId"];
                    }
                    if (reader["FinalScore"] != DBNull.Value)
                    {
                        entity.FinalScore = (long)reader["FinalScore"];
                    }

                    entity.Course = new CourseReposistory().GetOneCourseById(entity.Course.CourseId);
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

        public List<CourseStudentDetail> GetAllCourseStudentDetailByCourse(string searchKeyword, long courseId)
        {
            //Giá trị trả về của hàm này: List<CourseStudentDetail>
            List<CourseStudentDetail> queryResult = new List<CourseStudentDetail>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Student st JOIN CourseStudentDetail csd ON st.UserId = csd.StudentId WHERE csd.CourseId = @courseId AND st.UserFullName LIKE '%' + @searchKeyword + '%'";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseId", courseId);
                command.Parameters.AddWithValue("@searchKeyword", searchKeyword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    CourseStudentDetail entity = new CourseStudentDetail();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["CourseStudentDetailId"] != DBNull.Value)
                    {
                        entity.CourseStudentDetailId = (long)reader["CourseStudentDetailId"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        entity.Course.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["StudentId"] != DBNull.Value)
                    {
                        entity.Student.UserId = (long)reader["StudentId"];
                    }
                    if (reader["FinalScore"] != DBNull.Value)
                    {
                        entity.FinalScore = (long)reader["FinalScore"];
                    }

                    entity.Student = new StudentReposistory().GetOneStudentById(entity.Student.UserId);
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

        public CourseStudentDetail GetOneCourseStudentDetailById(long courseStudentDetailId)
        {
            //Giá trị trả về của hàm này
            CourseStudentDetail queryResult = new CourseStudentDetail();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM CourseStudentDetail WHERE CourseStudentDetailId = @courseStudentDetailId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là courseStudentDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseStudentDetailId", courseStudentDetailId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["CourseStudentDetailId"] != DBNull.Value)
                    {
                        queryResult.CourseStudentDetailId = (long)reader["CourseStudentDetailId"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        queryResult.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["StudentId"] != DBNull.Value)
                    {
                        queryResult.StudentId = (long)reader["StudentId"];
                    }
                    if (reader["FinalScore"] != DBNull.Value)
                    {
                        queryResult.FinalScore = (long)reader["FinalScore"];
                    }

                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }

        public long DeleteCourseStudentDetailById(long courseStudentDetailId)
        {
            // Hàm trả về courseStudentDetailId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM CourseStudentDetail WHERE CourseStudentDetailId = @courseStudentDetailId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là CourseStudentDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseStudentDetailId", courseStudentDetailId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về ourseStudentDetailId
            return courseStudentDetailId;
        }
        public long GetNumberOfStudentInCourse(long courseId)
        {
            long queryResult = 0;

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT COUNT(*) FROM CourseStudentDetail WHERE CourseId = @courseId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseId", courseId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();

                object obj = command.ExecuteScalar();
                if (obj.GetType() != typeof(DBNull))
                {
                    queryResult = Convert.ToInt64(obj);
                }
                else
                {
                    queryResult = 0;
                }

                //Đóng kết nối
                connection.Close();
            }

            //Trả về kết quả
            return queryResult;
        }

    }
}