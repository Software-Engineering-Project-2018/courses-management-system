using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebServer.Repository
{
    public class BaseReposistory
    {
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

    }
}