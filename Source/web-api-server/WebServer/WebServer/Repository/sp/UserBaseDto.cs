using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Repository.sp
{
    public class UserBaseDto
    {
        //Define const
        public const long TypeAdmin = 1;
        public const long TypeTeacher = 2;
        public const long TypeStudent = 3;
        public const long TypeParent = 4;

        //Data
        public long Id { get; set; }
        public long Type { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}