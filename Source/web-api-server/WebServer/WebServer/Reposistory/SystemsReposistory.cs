using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Models;

namespace WebServer.Repository.sp
{
    public class SystemsReposistory
    {
        public bool Register(long userType, string userName, string password,
               string fullName, long gender, DateTime birthDay, string phone, string email, string address)
        {
            switch (userType)
            {
                case UserBaseDto.TypeAdmin: //Quan ly
                    break;
                case UserBaseDto.TypeTeacher: //GiaoVien
                    break;
                case UserBaseDto.TypeStudent: //HocSinh
                    {
                        HocSinh hocSinhDto = new HocSinh();
                        hocSinhDto.TenDangNhap = userName;
                        hocSinhDto.MatKhau = password;
                        hocSinhDto.TenHocSinh = fullName;
                        //hocSinhDto.GioiTinh = gender;
                        hocSinhDto.NgaySinh = birthDay;
                        hocSinhDto.SoDienThoai = phone;
                        hocSinhDto.Email = email;
                        hocSinhDto.DiaChi = address;
                        hocSinhDto = new HocSinhReposistory().InsertHocSinh(hocSinhDto);
                        if (hocSinhDto == null)
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
            HocSinh hocSinh = new HocSinhReposistory().LoginHocSinh(userName, password);
            if (hocSinh != null)
            {
                return hocSinh;
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
                        HocSinh hocSinhDto = new HocSinhReposistory().LoginHocSinh(userName, oldPassword);
                        if (hocSinhDto == null)
                        {
                            return false;
                        }
                        new HocSinhReposistory().ChangePasswordHocSinh(userName, oldPassword, newPassword);
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
                        HocSinh hocSinhDto = new HocSinhReposistory().GetOneHocSinhById(userId);
                        return hocSinhDto;
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