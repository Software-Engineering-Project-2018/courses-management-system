using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class CourseReposistory : BaseReposistory
    { 
        //Thêm mới 1 khóa học.
        public Course InsertCourse(Course course)
        {

            //Câu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO Course (courseId, courseName, dateStart, dateEnd, tutition) VALUES" +
                                 "(@courseId, @courseName, @dateStart, @dateEnd, @tutition);";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Course
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseId", course.CourseId);
                command.Parameters.AddWithValue("@courseName", course.CourseName);
                command.Parameters.AddWithValue("@courseDateStart", course.DateStart);
                command.Parameters.AddWithValue("@courseDateEnd", course.DateEnd);
                command.Parameters.AddWithValue("@courseTutition", course.Tutition);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy courseID sau khi Create xong
                    course.CourseId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return course;
        }

        //Hàm sửa đổi thông tin của khóa học.
        public Course UpdateCourse(Course course)
        {
            string queryString = "UPDATE Course SET courseName = @CourseName, dateStart = @DateStart, dateEnd = @DateEnd, tutition = @Tutiton"
                               + "  WHERE CourseId = @courseId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Course
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseId", course.CourseId);
                command.Parameters.AddWithValue("@courseName", course.CourseName);
                command.Parameters.AddWithValue("@courseDateStart", course.DateStart);
                command.Parameters.AddWithValue("@courseDateEnd", course.DateEnd);
                command.Parameters.AddWithValue("@courseTutition", course.Tutition);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return course;
        }

        //Lấy danh sách tất cả khóa học
        public List<Course> GetAllCourse(string searchKeyword)
        {
            //Giá trị trả về của hàm này: List<Course>
            List<Course> queryResult = new List<Course>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Course WHERE CourseName like '%' + @searchKeyword + '%'";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@searchKeyword", searchKeyword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    Course entity = new Course();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["CourseId"] != DBNull.Value)
                    {
                       entity.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["CourseName"] != DBNull.Value)
                    {
                        entity.CourseName = (string)reader["CourseName"];
                    }
                    if (reader["DateStart"] != DBNull.Value)
                    {
                        entity.DateStart = (DateTime)reader["DateStart"];
                    }
                    if (reader["DateEnd"] != DBNull.Value)
                    {
                        entity.DateEnd = (DateTime)reader["DateEnd"];
                    }
                    if (reader["TutiTion"] != DBNull.Value)
                    {
                        entity.Tutition = (double)reader["Tutition"];
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

        //Hàm lấy 1 khóa học theo Id
        public Course GetOneCourseById(long courseId)
        {
            //Giá trị trả về của hàm này
            Course queryResult = new Course();

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Course WHERE CourseId = @courseId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là CourseId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        queryResult.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["CourseName"] != DBNull.Value)
                    {
                        queryResult.CourseName = (string)reader["CourseName"];
                    }
                    if (reader["DateStart"] != DBNull.Value)
                    {
                        queryResult.DateStart = (DateTime)reader["DateStart"];
                    }
                    if (reader["DateEnd"] != DBNull.Value)
                    {
                        queryResult.DateEnd = (DateTime)reader["DateEnd"];
                    }
                    if (reader["TutiTion"] != DBNull.Value)
                    {
                        queryResult.Tutition = (double)reader["Tutition"];
                    }
                    //Đóng kết nối
                    reader.Close();
                    connection.Close();
                }
                //Trả về kết quả
                return queryResult;
            }
        }

        //Hàm xóa thông tin khóa học ra khỏi danh sách
        public long DeleteCourseById(long courseId)
        {
            // Hàm trả về courseId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM Course WHERE CourseId = @courseId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là courseId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseId", courseId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về courseId
            return courseId;
        }
    }
}