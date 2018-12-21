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
                    break;
                case UserBaseDto.TypeTeacher: //GiaoVien
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
            //GiaoVien giaoVien = new GiaoVienReposistory().LoginGiaoVien(userName, password);
            //if (giaoVien != null)
            //{
            //    return giaoVien;
            //}
            //PhuHuynh phuHuynh = new PhuHuynhReposistory().LoginPhuHuynh(userName, password);
            //if (phuHuynh != null)
            //{
            //    return phuHuynh;
            //}
            //QuanLy quanLy = new QuanLyReposistory().LoginQuanLy(userName, password);
            //if (quanLy != null)
            //{
            //    return quanLy;
            //}
            return null;
        }

        public bool ChangePassword(long userType, string userName, string oldPassword, string newPassword)
        {
            switch (userType)
            {
                case UserBaseDto.TypeAdmin: //1: Quan ly
                    break;
                case UserBaseDto.TypeTeacher: //2: GiaoVien
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