using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class ParentReposistory : BaseReposistory
    {
        public Parent LoginParent(string userName, string password)
        {
            //Giá trị trả về của hàm này
            Parent queryResult = null;

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Parent WHERE (UserName = @userName OR UserEmail = @userName) AND UserPw = @password";

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
                    Parent parentDto = new Parent();
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["UserId"] != DBNull.Value)
                    {
                        parentDto.UserId = (long)reader["UserId"];
                    }
                    if (reader["UserName"] != DBNull.Value)
                    {
                        parentDto.UserName = (string)reader["UserName"];
                    }
                    if (reader["UserFullName"] != DBNull.Value)
                    {
                        parentDto.UserFullName = (string)reader["UserFullName"];
                    }
                    if (reader["UserDob"] != DBNull.Value)
                    {
                        parentDto.UserDob = (DateTime)reader["UserDob"];
                    }
                    if (reader["UserGender"] != DBNull.Value)
                    {
                        parentDto.UserGender = (long)reader["UserGender"];
                    }
                    if (reader["UserAddress"] != DBNull.Value)
                    {
                        parentDto.UserAddress = (string)reader["UserAddress"];
                    }
                    if (reader["UserMobile"] != DBNull.Value)
                    {
                        parentDto.UserMobile = (string)reader["UserMobile"];
                    }
                    if (reader["UserEmail"] != DBNull.Value)
                    {
                        parentDto.UserEmail = (string)reader["UserEmail"];
                    }
                    if (reader["UserAvatar"] != DBNull.Value)
                    {
                        parentDto.UserAvatar = (string)reader["UserAvatar"];
                    }
                    if (reader["StudentId"] != DBNull.Value)
                    {
                        parentDto.StudentId = (long)reader["StudentId"];
                    }
                    if (reader["UserType"] != DBNull.Value)
                    {
                        parentDto.UserType = (long)reader["UserType"];
                    }

                    if (parentDto.UserId != 0)
                    {
                        queryResult = parentDto;
                    }
                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }
        public void ChangePasswordParent(string userName, string oldPassword, string newPassword)
        {
            string queryString = "UPDATE Parent SET UserPw = @newPassword"
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

        public Parent InsertParent(Parent parent)
        {
            //Mật khẩu mặc định khi thêm mới tài khoản
            if (parent.UserPw == null || parent.UserPw == "")
            {
                parent.UserPw = this._defaultPassword;
            }

            //Câu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO Pra (UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, StudentId UserAvatar, UserType) VALUES" +
                                 "(@userPw, @userName, @userFullName, @userDob, @userGender, @userAddress, @userMobile, @userEmail,userAvatar, userType);"
                                 + " SELECT @@IDENTITY"; //Lấy ra Key(StudentId) của học sinh vừa được thêm

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Parent
                SqlCommand command = new SqlCommand(queryString, connection);       
                command.Parameters.AddWithValue("@userPw", parent.UserPw);
                command.Parameters.AddWithValue("@userName", parent.UserName);
                command.Parameters.AddWithValue("@userFullName", parent.UserFullName);
                command.Parameters.AddWithValue("@userDob", parent.UserDob);
                command.Parameters.AddWithValue("@userGender", parent.UserGender == 0 ? (object)DBNull.Value : parent.UserGender);
                command.Parameters.AddWithValue("@userAddress", string.IsNullOrEmpty(parent.UserAddress)
                    ? (object)DBNull.Value : parent.UserAddress);
                command.Parameters.AddWithValue("@userMobile", string.IsNullOrEmpty(parent.UserMobile)
                    ? (object)DBNull.Value : parent.UserMobile);
                command.Parameters.AddWithValue("@userEmail", string.IsNullOrEmpty(parent.UserEmail)
                    ? (object)DBNull.Value : parent.UserEmail);
                command.Parameters.AddWithValue("@userAvatar", string.IsNullOrEmpty(parent.UserAvatar)
                    ? (object)DBNull.Value : parent.UserAvatar);
                command.Parameters.AddWithValue("@userType", parent.UserType);
                command.Parameters.AddWithValue("@StudentId", parent.StudentId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy ParentID sau khi Create xong
                    parent.UserId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return parent;
        }

        public Parent UpdateParent(Parent parent)
        {
            string queryString = "UPDATE Parent SET UserName = @userName, UserFullName = @userFullName, UserDob = @userDob, UserGender = @userGender, UserAddress = @userAddress, UserMobile = @userMobile, UserEmail = @userEmail, UserAvatar = @userAvatar, StudentId = @StudentId"
                               + "  WHERE UserId = @userId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Student
                //Không cho phép update password và usertype ở hàm update
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@userId", parent.UserId);
                command.Parameters.AddWithValue("@userName", parent.UserName);
                command.Parameters.AddWithValue("@userFullName", parent.UserFullName);
                command.Parameters.AddWithValue("@userDob", parent.UserDob);
                command.Parameters.AddWithValue("@userGender", parent.UserGender == 0 ? (object)DBNull.Value : parent.UserGender);
                command.Parameters.AddWithValue("@userAddress", string.IsNullOrEmpty(parent.UserAddress)
                    ? (object)DBNull.Value : parent.UserAddress);
                command.Parameters.AddWithValue("@userMobile", string.IsNullOrEmpty(parent.UserMobile)
                    ? (object)DBNull.Value : parent.UserMobile);
                command.Parameters.AddWithValue("@userEmail", string.IsNullOrEmpty(parent.UserEmail)
                    ? (object)DBNull.Value : parent.UserEmail);
               command.Parameters.AddWithValue("@userAvatar", string.IsNullOrEmpty(parent.UserAvatar)
                    ? (object)DBNull.Value : parent.UserAvatar);
                command.Parameters.AddWithValue("@StudentId", parent.StudentId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return parent;
        }


        public List<Parent> GetAllParent(string searchKeyword)
        {
            //Giá trị trả về của hàm này: List<PhuHuynh>
            List<Parent> queryResult = new List<Parent>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Parent WHERE UserFullName like '%' + @searchKeyword + '%' OR UserName like '%' + @searchKeyword + '%'";

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
                    Parent entity = new Parent();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["UserId"] != DBNull.Value)
                    {
                        entity.UserId = (long)reader["UserId"];
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
                    if (reader["StudentId"] != DBNull.Value)
                    {
                        entity.UserType = (long)reader["StduentId"];
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

        public Parent GetOneParentById(long parentId)
        {
            //Giá trị trả về của hàm này
            Parent queryResult = new Parent();

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Parent WHERE UserId = @parentId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là hocSinhId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@parentId", parentId);

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
                    if (reader["StudentId"] != DBNull.Value)
                    {
                        queryResult.UserType = (long)reader["StudentId"];
                    }
                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }

        public long DeleteParentById(long parentId)
        {
            // Hàm trả về parentId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM Parent WHERE UserId = @parentId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là studentId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@parentId", parentId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về HocSinhId
            return parentId;
        }

        //Hàm đặt lại mật khẩu mặt định
        public Parent ResetPassword(Parent parent)
        {
            string queryString = "UPDATE Parent SET UserPw = @password"
                               + "  WHERE ParentId = @parentId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là parentId và mật khẩu mặc định
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@parentId", parent.UserId);
                command.Parameters.AddWithValue("@password", this._defaultPassword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return parent;
        }
        //Hàm lấy danh sách phụ huynh của học sinh
        public List<Parent> GetAllParentByStudentId(long studentId)
        {
            //Giá trị trả về của hàm này: List<PhuHuynh>
            List<Parent> queryResult = new List<Parent>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Parent WHERE StudentId = @studentId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@studentId", studentId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    Parent entity = new Parent();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["UserId"] != DBNull.Value)
                    {
                        entity.UserId = (long)reader["UserId"];
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
                    if (reader["StudentID"] != DBNull.Value)
                    {
                        entity.UserType = (long)reader["StduentId"];
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
    }
}