using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class StudentReposistory : BaseReposistory
    {
        public Student LoginStudent(string userName, string password)
        {
            //Giá trị trả về của hàm này
            Student queryResult = null;

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Student WHERE (UserName = @userName OR UserEmail = @userName) AND UserPw = @password";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là userName, password
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@password", password);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    Student studentDto = new Student();
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["UserId"] != DBNull.Value)
                    {
                        studentDto.UserId = (long)reader["UserId"];
                    }
                    if (reader["IdentificationCode"] != DBNull.Value)
                    {
                        studentDto.IdentificationCode = (string)reader["IdentificationCode"];
                    }
                    if (reader["UserName"] != DBNull.Value)
                    {
                        studentDto.UserName = (string)reader["UserName"];
                    }
                    if (reader["UserFullName"] != DBNull.Value)
                    {
                        studentDto.UserFullName = (string)reader["UserFullName"];
                    }
                    if (reader["UserDob"] != DBNull.Value)
                    {
                        studentDto.UserDob = (DateTime)reader["UserDob"];
                    }
                    if (reader["UserGender"] != DBNull.Value)
                    {
                        studentDto.UserGender = (long)reader["UserGender"];
                    }
                    if (reader["UserAddress"] != DBNull.Value)
                    {
                        studentDto.UserAddress = (string)reader["UserAddress"];
                    }
                    if (reader["UserMobile"] != DBNull.Value)
                    {
                        studentDto.UserMobile = (string)reader["UserMobile"];
                    }
                    if (reader["UserEmail"] != DBNull.Value)
                    {
                        studentDto.UserEmail = (string)reader["UserEmail"];
                    }
                    if (reader["TotalTutition"] != DBNull.Value)
                    {
                        studentDto.TotalTutition = (double)reader["TotalTutition"];
                    }
                    if (reader["TotalinDebt"] != DBNull.Value)
                    {
                        studentDto.TotalinDebt = (double)reader["TotalinDebt"];
                    }
                    if (reader["UserAvatar"] != DBNull.Value)
                    {
                        studentDto.UserAvatar = (string)reader["UserAvatar"];
                    }
                    if (reader["UserType"] != DBNull.Value)
                    {
                        studentDto.UserType = (long)reader["UserType"];
                    }

                    if(studentDto.UserId != 0)
                    {
                        queryResult = studentDto;
                    }
                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }
        public void ChangePasswordStudent(string userName, string oldPassword, string newPassword)
        {
            string queryString = "UPDATE Student SET UserPw = @newPassword"
                               + " WHERE (UserName = @userName OR UserEmail = @userName) AND UserPw = @oldPassword";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng HocSinh
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@oldPassword", oldPassword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }
        }

        public Student InsertStudent(Student student)
        {
            //Mật khẩu mặc định khi thêm mới tài khoản
            if (student.UserPw == null || student.UserPw == "")
            {
                student.UserPw = this._defaultPassword;
            }

            //Cấu lệnh truy vấn ở dạng string
            //StudentId tự động được sinh ra, ta không cần phải truyền vào StudentId ở câu query
            string queryString = "INSERT INTO Student (IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail , TotalTuTition, TotalinDebt, UserAvatar, UserType) VALUES" +
                                 "(@identificationCode, @userPw, @userName, @userFullName, @userDob, @userGender, @userAddress, @userMobile, @userEmail, @totalTuTition, totalinDebt, userAvatar, userType);"
                                 + " SELECT @@IDENTITY"; //Lấy ra Key(StudentId) của học sinh vừa được thêm

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Student
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@identificationCode", string.IsNullOrEmpty(student.IdentificationCode) 
                    ? (object)DBNull.Value : student.IdentificationCode); //Trường này cho phép null, thì ktra nếu là null thì truyền vào DBNull. Nếu không làm bước này nó sẽ truyền vào tham số là ' ' gây lỗi query
                command.Parameters.AddWithValue("@userPw", student.UserPw);
                command.Parameters.AddWithValue("@userName", student.UserName);
                command.Parameters.AddWithValue("@userFullName", student.UserFullName);
                command.Parameters.AddWithValue("@userDob", student.UserDob);
                command.Parameters.AddWithValue("@userGender", student.UserGender == 0 ? (object)DBNull.Value : student.UserGender);
                command.Parameters.AddWithValue("@userAddress", string.IsNullOrEmpty(student.UserAddress)
                    ? (object)DBNull.Value : student.UserAddress);
                command.Parameters.AddWithValue("@userMobile", string.IsNullOrEmpty(student.UserMobile)
                    ? (object)DBNull.Value : student.UserMobile);   
                command.Parameters.AddWithValue("@userEmail", string.IsNullOrEmpty(student.UserEmail)
                    ? (object)DBNull.Value : student.UserEmail);
                command.Parameters.AddWithValue("@totalTuTition", student.TotalTutition.GetValueOrDefault() == 0 ? (object)DBNull.Value : student.TotalTutition);
                command.Parameters.AddWithValue("@totalinDebt", student.TotalinDebt.GetValueOrDefault() == 0 ? (object)DBNull.Value : student.TotalinDebt);
                command.Parameters.AddWithValue("@userAvatar", string.IsNullOrEmpty(student.UserAvatar)
                    ? (object)DBNull.Value : student.UserAvatar);
                command.Parameters.AddWithValue("@userType", student.UserType);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy StudenthId sau khi Create xong
                    student.UserId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return student;
        }

        public Student UpdateStudent(Student student)
        {
            string queryString = "UPDATE Student SET IdentificationCode = @identificationCode, UserName = @userName, UserFullName = @userFullName, UserDob = @userDob, UserGender = @userGender, UserAddress = @userAddress, UserMobile = @userMobile, UserEmail = @userEmail, TotalTuTition = @totalTuTition, TotalinDebt = @totalinDebt, UserAvatar = @userAvatar"
                               + "  WHERE UserId = @userId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Student
                //Không cho phép update password và usertype ở hàm update
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@userId", student.UserId);
                command.Parameters.AddWithValue("@identificationCode", string.IsNullOrEmpty(student.IdentificationCode)
                    ? (object)DBNull.Value : student.IdentificationCode); //Trường này cho phép null, thì ktra nếu là null thì truyền vào DBNull. Nếu không làm bước này nó sẽ truyền vào tham số là ' ' gây lỗi query
                command.Parameters.AddWithValue("@userName", student.UserName);
                command.Parameters.AddWithValue("@userFullName", student.UserFullName);
                command.Parameters.AddWithValue("@userDob", student.UserDob);
                command.Parameters.AddWithValue("@userGender", student.UserGender == 0 ? (object)DBNull.Value : student.UserGender);
                command.Parameters.AddWithValue("@userAddress", string.IsNullOrEmpty(student.UserAddress)
                    ? (object)DBNull.Value : student.UserAddress);
                command.Parameters.AddWithValue("@userMobile", string.IsNullOrEmpty(student.UserMobile)
                    ? (object)DBNull.Value : student.UserMobile);
                command.Parameters.AddWithValue("@userEmail", string.IsNullOrEmpty(student.UserEmail)
                    ? (object)DBNull.Value : student.UserEmail);
                command.Parameters.AddWithValue("@totalTuTition", student.TotalTutition.GetValueOrDefault() == 0 ? (object)DBNull.Value : student.TotalTutition);
                command.Parameters.AddWithValue("@totalinDebt", student.TotalinDebt.GetValueOrDefault() == 0 ? (object)DBNull.Value : student.TotalinDebt);
                command.Parameters.AddWithValue("@userAvatar", string.IsNullOrEmpty(student.UserAvatar)
                    ? (object)DBNull.Value : student.UserAvatar);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return student;
        }


        public List<Student> GetAllStudent(string searchKeyword)
        {
            //Giá trị trả về của hàm này: List<HocSinh>
            List<Student> queryResult = new List<Student>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Student WHERE UserFullName like '%' + @searchKeyword + '%' OR UserName like '%' + @searchKeyword + '%'";

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
                    Student entity = new Student();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["UserId"] != DBNull.Value)
                    {
                        entity.UserId = (long)reader["UserId"];
                    }
                    if (reader["IdentificationCode"] != DBNull.Value)
                    {
                        entity.IdentificationCode = (string)reader["IdentificationCode"];
                    }
                    if (reader["UserName"] != DBNull.Value)
                    {
                        entity.UserName = (string)reader["UserName"];
                    }
                    if (reader["UserFullName"] != DBNull.Value)
                    {
                        entity.UserFullName = (string)reader["UserFullName"];
                    }
                    if (reader["UserDob"] != DBNull.Value)
                    {
                        entity.UserDob = (DateTime)reader["UserDob"];
                    }
                    if (reader["UserGender"] != DBNull.Value)
                    {
                        entity.UserGender = (long)reader["UserGender"];
                    }
                    if (reader["UserAddress"] != DBNull.Value)
                    {
                        entity.UserAddress = (string)reader["UserAddress"];
                    }
                    if (reader["UserMobile"] != DBNull.Value)
                    {
                        entity.UserMobile = (string)reader["UserMobile"];
                    }
                    if (reader["UserEmail"] != DBNull.Value)
                    {
                        entity.UserEmail = (string)reader["UserEmail"];
                    }
                    if (reader["TotalTutition"] != DBNull.Value)
                    {
                        entity.TotalTutition = (double)reader["TotalTutition"];
                    }
                    if (reader["TotalinDebt"] != DBNull.Value)
                    {
                        entity.TotalinDebt = (double)reader["TotalinDebt"];
                    }
                    if (reader["UserAvatar"] != DBNull.Value)
                    {
                        entity.UserAvatar = (string)reader["UserAvatar"];
                    }
                    if (reader["UserType"] != DBNull.Value)
                    {
                        entity.UserType = (long)reader["UserType"];
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

        public Student GetOneStudentById(long studentId)
        {
            //Giá trị trả về của hàm này
            Student queryResult = new Student();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Student WHERE UserId = @studentId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là hocSinhId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@studentId", studentId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["UserId"] != DBNull.Value)
                    {
                        queryResult.UserId = (long)reader["UserId"];
                    }
                    if (reader["IdentificationCode"] != DBNull.Value)
                    {
                        queryResult.IdentificationCode = (string)reader["IdentificationCode"];
                    }
                    if (reader["UserName"] != DBNull.Value)
                    {
                        queryResult.UserName = (string)reader["UserName"];
                    }
                    if (reader["UserFullName"] != DBNull.Value)
                    {
                        queryResult.UserFullName = (string)reader["UserFullName"];
                    }
                    if (reader["UserDob"] != DBNull.Value)
                    {
                        queryResult.UserDob = (DateTime)reader["UserDob"];
                    }
                    if (reader["UserGender"] != DBNull.Value)
                    {
                        queryResult.UserGender = (long)reader["UserGender"];
                    }
                    if (reader["UserAddress"] != DBNull.Value)
                    {
                        queryResult.UserAddress = (string)reader["UserAddress"];
                    }
                    if (reader["UserMobile"] != DBNull.Value)
                    {
                        queryResult.UserMobile = (string)reader["UserMobile"];
                    }
                    if (reader["UserEmail"] != DBNull.Value)
                    {
                        queryResult.UserEmail = (string)reader["UserEmail"];
                    }
                    if (reader["TotalTutition"] != DBNull.Value)
                    {
                        queryResult.TotalTutition = (double)reader["TotalTutition"];
                    }
                    if (reader["TotalinDebt"] != DBNull.Value)
                    {
                        queryResult.TotalinDebt = (double)reader["TotalinDebt"];
                    }
                    if (reader["UserAvatar"] != DBNull.Value)
                    {
                        queryResult.UserAvatar = (string)reader["UserAvatar"];
                    }
                    if (reader["UserType"] != DBNull.Value)
                    {
                        queryResult.UserType = (long)reader["UserType"];
                    }
                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }

        public long DeleteStudentById(long studentId)
        {
            // Hàm trả về studentId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM Student WHERE UserId = @studentId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là studentId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@studentId", studentId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về HocSinhId
            return studentId;
        }

        //Hàm đặt lại mật khẩu mặt định
        public Student ResetPassword(Student student)
        {
            //HocSinhId tự động được sinh ra, ta không cần phải truyền vào HocSinhId ở câu query
            string queryString = "UPDATE Student SET UserPw = @password"
                               + "  WHERE StudentId = @studentId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là hocSinhId và mật khẩu mặc định
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@studentId", student.UserId);
                command.Parameters.AddWithValue("@password", this._defaultPassword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return student;
        }

    }
}