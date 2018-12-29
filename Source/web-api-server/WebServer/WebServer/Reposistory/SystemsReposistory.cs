using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Models;

namespace WebServer.Repository.sp
{
    public class SystemsReposistory
    {
        public bool Register(long userType, string identificationCode, string userName, string password,
               string fullName, long gender, DateTime birthDay, string phone, string email, string address, string avatar)
        {
            switch (userType)
            {
                case UserBaseDto.TypeAdmin: //Quan ly
                    {
                        Manager managerDto = new Manager();
                        managerDto.UserName = userName;
                        managerDto.UserPw = password;
                        managerDto.UserFullName = fullName;
                        managerDto.UserGender = gender;
                        managerDto.UserDob = birthDay;
                        managerDto.UserMobile = phone;
                        managerDto.UserEmail = email;
                        managerDto.UserAddress = address;
                        managerDto.UserAvatar = avatar;
                        managerDto = new ManagerReposistory().InsertManager(managerDto);
                        if (managerDto == null)
                        {
                            return false;
                        }
                    }
                    break;
                case UserBaseDto.TypeTeacher: //GiaoVien
                    {
                        Teacher teacherDto = new Teacher();
                        teacherDto.UserName = userName;
                        teacherDto.UserPw = password;
                        teacherDto.UserFullName = fullName;
                        teacherDto.UserGender = gender;
                        teacherDto.UserDob = birthDay;
                        teacherDto.UserMobile = phone;
                        teacherDto.UserEmail = email;
                        teacherDto.UserAddress = address;
                        teacherDto.UserAvatar = avatar;
                        teacherDto = new TeacherReposistory().InsertTeacher(teacherDto);
                        if (teacherDto == null)
                        {
                            return false;
                        }
                    }
                    break;
                case UserBaseDto.TypeStudent: //HocSinh
                    {
                        Student studentDto = new Student();
                        studentDto.UserName = userName;
                        studentDto.UserPw = password;
                        studentDto.UserFullName = fullName;
                        studentDto.UserGender = gender;
                        studentDto.UserDob = birthDay;
                        studentDto.UserMobile = phone;
                        studentDto.UserEmail = email;
                        studentDto.UserAddress = address;
                        studentDto.UserAvatar = avatar;
                        studentDto = new StudentReposistory().InsertStudent(studentDto);
                        if (studentDto == null)
                        {
                            return false;
                        }
                    }
                    break;
                case UserBaseDto.TypeParent: //Phu huynh
                    {
                        Parent parentDto = new Parent();
                        parentDto.UserName = userName;
                        parentDto.UserPw = password;
                        parentDto.UserFullName = fullName;
                        parentDto.UserGender = gender;
                        parentDto.UserDob = birthDay;
                        parentDto.UserMobile = phone;
                        parentDto.UserEmail = email;
                        parentDto.UserAddress = address;
                        parentDto.UserAvatar = avatar;
                        parentDto = new ParentReposistory().InsertParent(parentDto);
                        if (parentDto == null)
                        {
                            return false;
                        }
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        public dynamic Login(string userName, string password)
        {
            Student student = new StudentReposistory().LoginStudent(userName, password);
            if (student != null)
            {
                return student;
            }
            Teacher teacher = new TeacherReposistory().LoginTeacher(userName, password);
            if (teacher != null)
            {
                return teacher;
            }
            Parent parent = new ParentReposistory().LoginParent(userName, password);
            if (parent != null)
            {
                return parent;
            }
            Manager manager = new ManagerReposistory().LoginManager(userName, password);
            if (manager != null)
            {
                return manager;
            }
            return null;
        }

        public bool ChangePassword(long userType, string userName, string oldPassword, string newPassword)
        {
            switch (userType)
            {
                case UserBaseDto.TypeAdmin: //1: Quan ly
                    {
                        Manager managerDto = new ManagerReposistory().LoginManager(userName, oldPassword);
                        if (managerDto == null)
                        {
                            return false;
                        }
                        new ManagerReposistory().ChangePasswordManager(userName, oldPassword, newPassword);
                    }
                    break;
                case UserBaseDto.TypeTeacher: //2: GiaoVien
                    {
                        Teacher teacherDto = new TeacherReposistory().LoginTeacher(userName, oldPassword);
                        if (teacherDto == null)
                        {
                            return false;
                        }
                        new TeacherReposistory().ChangePasswordTeacher(userName, oldPassword, newPassword);
                    }
                    break;
                case UserBaseDto.TypeStudent: //3: HocSinh
                    {
                        Student studentDto = new StudentReposistory().LoginStudent(userName, oldPassword);
                        if (studentDto == null)
                        {
                            return false;
                        }
                        new StudentReposistory().ChangePasswordStudent(userName, oldPassword, newPassword);
                    }
                    break;
                case UserBaseDto.TypeParent: //4: Phu huynh
                    {
                        Parent parentDto = new ParentReposistory().LoginParent(userName, oldPassword);
                        if (parentDto == null)
                        {
                            return false;
                        }
                        new ParentReposistory().ChangePasswordParent(userName, oldPassword, newPassword);
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        public dynamic GetUserInfo(long userType, long userId)
        {
            switch (userType)
            {
                case UserBaseDto.TypeAdmin: //Quan ly
                    break;
                case UserBaseDto.TypeTeacher: //GiaoVien
                    break;
                case UserBaseDto.TypeStudent: //HocSinh
                    {
                        Student studentDto = new StudentReposistory().GetOneStudentById(userId);
                        return studentDto;
                    }
                case UserBaseDto.TypeParent: //Phu huynh
                    break;
                default:
                    return false;
            }
            return null;
        }
    }
}