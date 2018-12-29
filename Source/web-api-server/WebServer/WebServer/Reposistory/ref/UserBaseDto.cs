

using System;

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
        public long UserId { get; set; }
        public long UserType { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        //public static implicit operator UserBaseDto(UserBaseDto v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}