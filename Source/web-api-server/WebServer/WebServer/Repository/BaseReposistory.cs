using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebServer.Repository
{
    //BaseReposistory nơi chứa các phương thức, biến xài chung cho các reposistory
    public class BaseReposistory
    {
        //Chuỗi kết nối đến database khi khởi tạo kết nối
        public string _connectionString;
        public string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["CoursesSystemEntities"].ConnectionString.ToString();
                }
                return _connectionString;
            }
        }
        
        //Mật khẩu mặc định
        public string _defaultPassword = "1234567890";

    }
}