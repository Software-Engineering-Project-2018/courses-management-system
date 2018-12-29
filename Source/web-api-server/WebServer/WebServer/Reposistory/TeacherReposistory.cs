using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class TeacherReposistory : BaseReposistory
    {
        public Teacher LoginTeacher(string userName, string password)
        {
            //Giá trị trả về của hàm này
            Teacher queryResult = null;

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Teacher WHERE (UserName = @userName OR UserEmail = @userName) AND UserPw = @password";

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
                    Teacher teacherDto = new Teacher();
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["UserId"] != DBNull.Value)
                    {
                        teacherDto.UserId = (long)reader["UserId"];
                    }
                    if (reader["IdentificationCode"] != DBNull.Value)
                    {
                        teacherDto.IdentificationCode = (string)reader["IdentificationCode"];
                    }
                    if (reader["UserName"] != DBNull.Value)
                    {
                        teacherDto.UserName = (string)reader["UserName"];
                    }
                    if (reader["UserFullName"] != DBNull.Value)
                    {
                        teacherDto.UserFullName = (string)reader["UserFullName"];
                    }
                    if (reader["UserDob"] != DBNull.Value)
                    {
                        teacherDto.UserDob = (DateTime)reader["UserDob"];
                    }
                    if (reader["UserGender"] != DBNull.Value)
                    {
                        teacherDto.UserGender = (long)reader["UserGender"];
                    }
                    if (reader["UserAddress"] != DBNull.Value)
                    {
                        teacherDto.UserAddress = (string)reader["UserAddress"];
                    }
                    if (reader["UserMobile"] != DBNull.Value)
                    {
                        teacherDto.UserMobile = (string)reader["UserMobile"];
                    }
                    if (reader["UserEmail"] != DBNull.Value)
                    {
                        teacherDto.UserEmail = (string)reader["UserEmail"];
                    }
                    if (reader["UserAvatar"] != DBNull.Value)
                    {
                        teacherDto.UserAvatar = (string)reader["UserAvatar"];
                    }
                    if (reader["UserType"] != DBNull.Value)
                    {
                        teacherDto.UserType = (long)reader["UserType"];
                    }

                    if (teacherDto.UserId != 0)
                    {
                        queryResult = teacherDto;
                    }
                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }

        //Thay đổi password của giáo viên.
        public void ChangePasswordTeacher(string userName, string oldPassword, string newPassword)
        {
            string queryString = "UPDATE Teacher SET UserPw = @newPassword"
                               + " WHERE (UserName = @userName OR UserEmail = @userName) AND UserPw = @oldPassword";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Teacher
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

        //Thêm mới 1 giáo viên.
        public Teacher InsertTeacher(Teacher teacher)
        {
            //Mật khẩu mặc định khi thêm mới tài khoản
            if (teacher.UserPw == null || teacher.UserPw == "")
            {
                teacher.UserPw = this._defaultPassword;
            }

            //Câu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO Teacher (IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, UserAvatar, UserType) VALUES" +
                                 "(@identificationCode, @userPw, @userName, @userFullName, @userDob, @userGender, @userAddress, @userMobile, @userEmail, @userAvatar, @userType);";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Teacher
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@identificationCode", string.IsNullOrEmpty(teacher.IdentificationCode)
                    ? (object)DBNull.Value : teacher.IdentificationCode); //Trường này cho phép null, thì ktra nếu là null thì truyền vào DBNull. Nếu không làm bước này nó sẽ truyền vào tham số là ' ' gây lỗi query
                command.Parameters.AddWithValue("@userPw", teacher.UserPw);
                command.Parameters.AddWithValue("@userName", teacher.UserName);
                command.Parameters.AddWithValue("@userFullName", teacher.UserFullName);
                command.Parameters.AddWithValue("@userDob", teacher.UserDob);
                command.Parameters.AddWithValue("@userGender", teacher.UserGender == 0 ? (object)DBNull.Value : teacher.UserGender);
                command.Parameters.AddWithValue("@userAddress", string.IsNullOrEmpty(teacher.UserAddress)
                    ? (object)DBNull.Value : teacher.UserAddress);
                command.Parameters.AddWithValue("@userMobile", string.IsNullOrEmpty(teacher.UserMobile)
                    ? (object)DBNull.Value : teacher.UserMobile);
                command.Parameters.AddWithValue("@userEmail", string.IsNullOrEmpty(teacher.UserEmail)
                    ? (object)DBNull.Value : teacher.UserEmail);
                command.Parameters.AddWithValue("@userAvatar", string.IsNullOrEmpty(teacher.UserAvatar)
                    ? (object)DBNull.Value : teacher.UserAvatar);
                command.Parameters.AddWithValue("@userType", teacher.UserType);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy managerID sau khi Create xong
                    teacher.UserId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return teacher;
        }

        //Hàm sửa đổi thông tin của giáo viên.
        public Teacher UpdateTeacher(Teacher teacher)
        {
            string queryString = "UPDATE Teacher SET IdentificationCode = @identificationCode, UserName = @userName, UserFullName = @userFullName, UserDob = @userDob, UserGender = @userGender, UserAddress = @userAddress, UserMobile = @userMobile, UserEmail = @userEmail, UserAvatar = @userAvatar"
                               + "  WHERE UserId = @userId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Teacher
                //Không cho phép update password và usertype ở hàm update
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@userId", teacher.UserId);
                command.Parameters.AddWithValue("@identificationCode", string.IsNullOrEmpty(teacher.IdentificationCode)
                    ? (object)DBNull.Value : teacher.IdentificationCode); //Trường này cho phép null, thì ktra nếu là null thì truyền vào DBNull. Nếu không làm bước này nó sẽ truyền vào tham số là ' ' gây lỗi query
                command.Parameters.AddWithValue("@userName", teacher.UserName);
                command.Parameters.AddWithValue("@userFullName", teacher.UserFullName);
                command.Parameters.AddWithValue("@userDob", teacher.UserDob);
                command.Parameters.AddWithValue("@userGender", teacher.UserGender == 0 ? (object)DBNull.Value : teacher.UserGender);
                command.Parameters.AddWithValue("@userAddress", string.IsNullOrEmpty(teacher.UserAddress)
                    ? (object)DBNull.Value : teacher.UserAddress);
                command.Parameters.AddWithValue("@userMobile", string.IsNullOrEmpty(teacher.UserMobile)
                    ? (object)DBNull.Value : teacher.UserMobile);
                command.Parameters.AddWithValue("@userEmail", string.IsNullOrEmpty(teacher.UserEmail)
                    ? (object)DBNull.Value : teacher.UserEmail);
                command.Parameters.AddWithValue("@userAvatar", string.IsNullOrEmpty(teacher.UserAvatar)
                     ? (object)DBNull.Value : teacher.UserAvatar);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return teacher;
        }

        //Lấy danh sách tất cả giáo viên.
        public List<Teacher> GetAllTeacher(string searchKeyword)
        {
            //Giá trị trả về của hàm này: List<Teacher>
            List<Teacher> queryResult = new List<Teacher>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Teacher WHERE UserFullName like '%' + @searchKeyword + '%' OR UserName like '%' + @searchKeyword + '%'";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@searchKeyword", string.IsNullOrEmpty(searchKeyword) ? "" : searchKeyword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    Teacher entity = new Teacher();

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

        //Hàm lấy 1 người giáo viên theo Id
        public Teacher GetOneTeacherById(long teacherId)
        {
            //Giá trị trả về của hàm này
            Teacher queryResult = new Teacher();

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Teacher WHERE UserId = @teacherId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là managerId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@teacherId", teacherId);

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

        //Hàm xóa thông tin giáo viên ra khỏi danh sách
        public long DeleteTeacherById(long teacherId)
        {
            // Hàm trả về teacherId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM Teacher WHERE UserId = @teacherId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là teacherId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@teacherId", teacherId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về ManagerId
            return teacherId;
        }

        //Hàm đặt lại mật khẩu mặt định
        public long ResetPassword(long teacherId)
        {
            string queryString = "UPDATE Teacher SET UserPw = @password"
                               + "  WHERE TeacherId = @teacherId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là teacherId và mật khẩu mặc định
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@teacherId", teacherId);
                command.Parameters.AddWithValue("@password", this._defaultPassword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return teacherId;
        }

    }
}