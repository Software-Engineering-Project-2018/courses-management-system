using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebServer.Models;

namespace WebServer.Repository
{
    public class HocSinhReposistory : BaseReposistory
    {
        public List<HocSinh> GetAll()
        {
            List<HocSinh> queryResult = new List<HocSinh>();
            string queryString = "SELECT * FROM HOCSINH";
            
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
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

            //Trả về kết quả từ query sql
            return queryResult;
        }
    }
}