using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class HocSinhReposistory : BaseReposistory
    {
        public HocSinh LoginHocSinh(string userName, string password)
        {
            //Giá trị trả về của hàm này
            HocSinh queryResult = new HocSinh();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM HocSinh WHERE (TenDangNhap = @userName OR Email = @userName) AND MatKhau = @password";

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
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["HocSinhId"] != DBNull.Value)
                    {
                        queryResult.HocSinhId = (long)reader["HocSinhId"];
                    }
                    if (reader["TenHocSinh"] != DBNull.Value)
                    {
                        queryResult.TenHocSinh = (string)reader["TenHocSinh"];
                    }
                    if (reader["NgaySinh"] != DBNull.Value)
                    {
                        queryResult.NgaySinh = (DateTime)reader["NgaySinh"];
                    }
                    if (reader["SoDienThoai"] != DBNull.Value)
                    {
                        queryResult.SoDienThoai = (string)reader["SoDienThoai"];
                    }
                    if (reader["DiaChi"] != DBNull.Value)
                    {
                        queryResult.DiaChi = (string)reader["DiaChi"];
                    }
                    if (reader["Email"] != DBNull.Value)
                    {
                        queryResult.Email = (string)reader["Email"];
                    }
                    if (reader["MatKhau"] != DBNull.Value)
                    {
                        queryResult.MatKhau = (string)reader["MatKhau"];
                    }
                    if (reader["TenDangNhap"] != DBNull.Value)
                    {
                        queryResult.TenDangNhap = (string)reader["TenDangNhap"];
                    }
                    if (reader["Avatar"] != DBNull.Value)
                    {
                        queryResult.Avatar = (string)reader["Avatar"];
                    }
                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }
        public void ChangePasswordHocSinh(string userName, string oldPassword, string newPassword)
        {
            string queryString = "UPDATE HocSinh SET MatKhau = @newPassword"
                               + " WHERE (TenDangNhap = @userName OR Email = @userName) AND MatKhau = @oldPassword";
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

        public HocSinh InsertHocSinh(HocSinh hocSinh)
        {
            //Mật khẩu mặc định khi thêm mới tài khoản
            if (hocSinh.MatKhau == null || hocSinh.MatKhau == "")
            {
                hocSinh.MatKhau = this._defaultPassword;
            }

            //Cấu lệnh truy vấn ở dạng string
            //HocSinhId tự động được sinh ra, ta không cần phải truyền vào HocSinhId ở câu query
            string queryString = "INSERT INTO HocSinh (TenHocSinh, NgaySinh, SoDienThoai, DiaChi, Email, MatKhau, TenDangNhap, Avatar) VALUES" +
                                 "(@tenHocSinh, @ngaySinh, @soDienThoai, @diaChi, @email, @matKhau, @tenDangNhap, @avatar);"
                                 + " SELECT @@IDENTITY"; //Lấy ra Key(HocSinhId) của học sinh vừa được thêm

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng HocSinh
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@tenHocSinh", hocSinh.TenHocSinh);
                command.Parameters.AddWithValue("@ngaySinh", hocSinh.NgaySinh);
                command.Parameters.AddWithValue("@soDienThoai", hocSinh.SoDienThoai);
                command.Parameters.AddWithValue("@diaChi", hocSinh.DiaChi);
                command.Parameters.AddWithValue("@email", hocSinh.Email);
                command.Parameters.AddWithValue("@matKhau", hocSinh.MatKhau);
                command.Parameters.AddWithValue("@tenDangNhap", hocSinh.TenDangNhap);
                command.Parameters.AddWithValue("@avatar", hocSinh.Avatar);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Lấy HocSinhId sau khi Create xong
                    hocSinh.HocSinhId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return hocSinh;
        }

        public HocSinh UpdateHocSinh(HocSinh hocSinh)
        {
            string queryString = "UPDATE HocSinh SET TenHocSinh = @tenHocSinh, NgaySinh = @ngaySinh, SoDienThoai = @soDienThoai, DiaChi = @diaChi, Email = @email, MatKhau = @matKhau, TenDangNhap = @tenDangNhap, Avatar = @avatar"
                               + "  WHERE HocSinhId = @hocSinhId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng HocSinh
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@hocSinhId", hocSinh.HocSinhId);
                command.Parameters.AddWithValue("@tenHocSinh", hocSinh.TenHocSinh);
                command.Parameters.AddWithValue("@ngaySinh", hocSinh.NgaySinh);
                command.Parameters.AddWithValue("@soDienThoai", hocSinh.SoDienThoai);
                command.Parameters.AddWithValue("@diaChi", hocSinh.DiaChi);
                command.Parameters.AddWithValue("@email", hocSinh.Email);
                command.Parameters.AddWithValue("@matKhau", hocSinh.MatKhau);
                command.Parameters.AddWithValue("@tenDangNhap", hocSinh.TenDangNhap);
                command.Parameters.AddWithValue("@avatar", hocSinh.Avatar);
                
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return hocSinh;
        }


        public List<HocSinh> GetAllHocSinh()
        {
            //Giá trị trả về của hàm này: List<HocSinh>
            List<HocSinh> queryResult = new List<HocSinh>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM HocSinh";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command không có tham số nào truyền vào
                SqlCommand command = new SqlCommand(queryString, connection);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    HocSinh entity = new HocSinh();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["HocSinhId"] != DBNull.Value)
                    {
                        entity.HocSinhId = (long)reader["HocSinhId"];
                    }
                    if (reader["TenHocSinh"] != DBNull.Value)
                    {
                        entity.TenHocSinh = (string)reader["TenHocSinh"];
                    }
                    if (reader["NgaySinh"] != DBNull.Value)
                    {
                        entity.NgaySinh = (DateTime)reader["NgaySinh"];
                    }
                    if (reader["SoDienThoai"] != DBNull.Value)
                    {
                        entity.SoDienThoai = (string)reader["SoDienThoai"];
                    }
                    if (reader["DiaChi"] != DBNull.Value)
                    {
                        entity.DiaChi = (string)reader["DiaChi"];
                    }
                    if (reader["Email"] != DBNull.Value)
                    {
                        entity.Email = (string)reader["Email"];
                    }
                    if (reader["MatKhau"] != DBNull.Value)
                    {
                        entity.MatKhau = (string)reader["MatKhau"];
                    }
                    if (reader["TenDangNhap"] != DBNull.Value)
                    {
                        entity.TenDangNhap = (string)reader["TenDangNhap"];
                    }
                    if (reader["Avatar"] != DBNull.Value)
                    {
                        entity.Avatar = (string)reader["Avatar"];
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

        public HocSinh GetOneHocSinhById(long hocSinhId)
        {
            //Giá trị trả về của hàm này
            HocSinh queryResult = new HocSinh();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM HocSinh WHERE HocSinhId = @hocSinhId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là hocSinhId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@hocSinhId", hocSinhId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["HocSinhId"] != DBNull.Value)
                    {
                        queryResult.HocSinhId = (long)reader["HocSinhId"];
                    }
                    if (reader["TenHocSinh"] != DBNull.Value)
                    {
                        queryResult.TenHocSinh = (string)reader["TenHocSinh"];
                    }
                    if (reader["NgaySinh"] != DBNull.Value)
                    {
                        queryResult.NgaySinh = (DateTime)reader["NgaySinh"];
                    }
                    if (reader["SoDienThoai"] != DBNull.Value)
                    {
                        queryResult.SoDienThoai = (string)reader["SoDienThoai"];
                    }
                    if (reader["DiaChi"] != DBNull.Value)
                    {
                        queryResult.DiaChi = (string)reader["DiaChi"];
                    }
                    if (reader["Email"] != DBNull.Value)
                    {
                        queryResult.Email = (string)reader["Email"];
                    }
                    if (reader["MatKhau"] != DBNull.Value)
                    {
                        queryResult.MatKhau = (string)reader["MatKhau"];
                    }
                    if (reader["TenDangNhap"] != DBNull.Value)
                    {
                        queryResult.TenDangNhap = (string)reader["TenDangNhap"];
                    }
                    if (reader["Avatar"] != DBNull.Value)
                    {
                        queryResult.Avatar = (string)reader["Avatar"];
                    }
                }
                //Đóng kết nối
                reader.Close();
                connection.Close();
            }
            //Trả về kết quả
            return queryResult;
        }

        public long DeleteHocSinhById(long hocSinhId)
        {
            // Hàm trả về HocSinhId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM HocSinh WHERE HocSinhId = @hocSinhId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là hocSinhId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@hocSinhId", hocSinhId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về HocSinhId
            return hocSinhId;
        }

        //Hàm đặt lại mật khẩu mặt định
        public HocSinh ResetPassword(HocSinh hocSinh)
        {
            //HocSinhId tự động được sinh ra, ta không cần phải truyền vào HocSinhId ở câu query
            string queryString = "UPDATE HocSinh SET MatKhau = @password"
                               + "  WHERE HocSinhId = @hocSinhId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là hocSinhId và mật khẩu mặc định
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@hocSinhId", hocSinh.HocSinhId);
                command.Parameters.AddWithValue("@password", this._defaultPassword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return hocSinh;
        }

    }
}