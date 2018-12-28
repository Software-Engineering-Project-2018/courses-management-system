using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class ManagerReposistory : BaseReposistory
    {
        public Manager LoginManager(string userName, string password)
        {
            //Giá trị trả về của hàm này
            Manager queryResult = null;

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Manager WHERE (UserName = @userName OR UserEmail = @userName) AND UserPw = @password";

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
                    Manager managerDto = new Manager();
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["UserId"] != DBNull.Value)
                    {
                        managerDto.UserId = (long)reader["UserId"];
                    }
                    if (reader["UserName"] != DBNull.Value)
                    {
                        managerDto.UserName = (string)reader["UserName"];
                    }
                    if (reader["UserFullName"] != DBNull.Value)
                    {
                        managerDto.UserFullName = (string)reader["UserFullName"];
                    }
                    if (reader["UserDob"] != DBNull.Value)
                    {
                        managerDto.UserDob = (DateTime)reader["UserDob"];
                    }
                    if (reader["UserGender"] != DBNull.Value)
                    {
                        managerDto.UserGender = (long)reader["UserGender"];
                    }
                    if (reader["UserAddress"] != DBNull.Value)
                    {
                        managerDto.UserAddress = (string)reader["UserAddress"];
                    }
                    if (reader["UserMobile"] != DBNull.Value)
                    {
                        managerDto.UserMobile = (string)reader["UserMobile"];
                    }
                    if (reader["UserEmail"] != DBNull.Value)
                    {
                        managerDto.UserEmail = (string)reader["UserEmail"];
                    }
                    if (reader["UserAvatar"] != DBNull.Value)
                    {
                        managerDto.UserAvatar = (string)reader["UserAvatar"];
                    }
                    if (reader["UserType"] != DBNull.Value)
                    {
                        managerDto.UserType = (long)reader["UserType"];
                    }

                    if (managerDto.UserId != 0)
                    {
                        queryResult = managerDto;
                    }
                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }

        //Thay đổi password của người quản lý.
        public void ChangePasswordManager(string userName, string oldPassword, string newPassword)
        {
            string queryString = "UPDATE Manager SET UserPw = @newPassword"
                               + " WHERE (UserName = @userName OR UserEmail = @userName) AND UserPw = @oldPassword";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Manager
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

        //Thêm mới 1 người quản lý.
        public Manager InsertManager(Manager manager)
        {
            //Mật khẩu mặc định khi thêm mới tài khoản
            if (manager.UserPw == null || manager.UserPw == "")
            {
                manager.UserPw = this._defaultPassword;
            }

            //Câu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO Manager (UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, UserAvatar, UserType) VALUES" +
                                 "(@userPw, @userName, @userFullName, @userDob, @userGender, @userAddress, @userMobile, @userEmail, @userAvatar, @userType);";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Manager
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@userPw", manager.UserPw);
                command.Parameters.AddWithValue("@userName", manager.UserName);
                command.Parameters.AddWithValue("@userFullName", manager.UserFullName);
                command.Parameters.AddWithValue("@userDob", manager.UserDob);
                command.Parameters.AddWithValue("@userGender", manager.UserGender == 0 ? (object)DBNull.Value : manager.UserGender);
                command.Parameters.AddWithValue("@userAddress", string.IsNullOrEmpty(manager.UserAddress)
                    ? (object)DBNull.Value : manager.UserAddress);
                command.Parameters.AddWithValue("@userMobile", string.IsNullOrEmpty(manager.UserMobile)
                    ? (object)DBNull.Value : manager.UserMobile);
                command.Parameters.AddWithValue("@userEmail", string.IsNullOrEmpty(manager.UserEmail)
                    ? (object)DBNull.Value : manager.UserEmail);
                command.Parameters.AddWithValue("@userAvatar", string.IsNullOrEmpty(manager.UserAvatar)
                    ? (object)DBNull.Value : manager.UserAvatar);
                command.Parameters.AddWithValue("@userType", manager.UserType);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy managerID sau khi Create xong
                    manager.UserId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return manager;
        }

        //Hàm sửa đổi thông tin của người quản lý.
        public Manager UpdateManager(Manager manager)
        {
            string queryString = "UPDATE Manager SET UserName = @userName, UserFullName = @userFullName, UserDob = @userDob, UserGender = @userGender, UserAddress = @userAddress, UserMobile = @userMobile, UserEmail = @userEmail, UserAvatar = @userAvatar"
                               + "  WHERE UserId = @userId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Manager
                //Không cho phép update password và usertype ở hàm update
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@userId", manager.UserId);
                command.Parameters.AddWithValue("@userName", manager.UserName);
                command.Parameters.AddWithValue("@userFullName", manager.UserFullName);
                command.Parameters.AddWithValue("@userDob", manager.UserDob);
                command.Parameters.AddWithValue("@userGender", manager.UserGender == 0 ? (object)DBNull.Value : manager.UserGender);
                command.Parameters.AddWithValue("@userAddress", string.IsNullOrEmpty(manager.UserAddress)
                    ? (object)DBNull.Value : manager.UserAddress);
                command.Parameters.AddWithValue("@userMobile", string.IsNullOrEmpty(manager.UserMobile)
                    ? (object)DBNull.Value : manager.UserMobile);
                command.Parameters.AddWithValue("@userEmail", string.IsNullOrEmpty(manager.UserEmail)
                    ? (object)DBNull.Value : manager.UserEmail);
                command.Parameters.AddWithValue("@userAvatar", string.IsNullOrEmpty(manager.UserAvatar)
                     ? (object)DBNull.Value : manager.UserAvatar);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return manager;
        }

        //Lấy danh sách tất cả quản lý.
        public List<Manager> GetAllManager(string searchKeyword)
        {
            //Giá trị trả về của hàm này: List<Manager>
            List<Manager> queryResult = new List<Manager>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Manager WHERE UserFullName like '%' + @searchKeyword + '%' OR UserName like '%' + @searchKeyword + '%'";

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
                    Manager entity = new Manager();

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

        //Hàm lấy 1 người quản lý theo Id
        public Manager GetOneManagerById(long managerId)
        {
            //Giá trị trả về của hàm này
            Manager queryResult = new Manager();

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Manager WHERE UserId = @managerId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là managerId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@managerId", managerId);

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
                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }

        //Hàm xóa thông tin quản lý ra khỏi danh sách
        public long DeleteManagerById(long managerId)
        {
            // Hàm trả về managerId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM Manager WHERE UserId = @managerId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là managerId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@managerId", managerId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về ManagerId
            return managerId;
        }

        //Hàm đặt lại mật khẩu mặt định
        public Manager ResetPassword(Manager manager)
        {
            string queryString = "UPDATE Manager SET UserPw = @password"
                               + "  WHERE ManagerId = @managerId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là parentId và mật khẩu mặc định
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@managerId", manager.UserId);
                command.Parameters.AddWithValue("@password", this._defaultPassword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return manager;
        }
        
    }
}