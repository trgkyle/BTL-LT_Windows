using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class TaiKhoanBUS
    {
        TaiKhoanDAL taiKhoan = new TaiKhoanDAL();
        public Boolean Login(string tenTaiKhoan, string password)
        {
            return taiKhoan.dangNhap(tenTaiKhoan, password);
        }
        public TaiKhoanDTO layThongTin(string tenTaiKhoan, string password)
        {
            return taiKhoan.layThongTinTaiKhoan(tenTaiKhoan, password);
        }
        public Boolean doiMatKhau(string tenTaiKhoan, string password, string newPassword)
        {
            return taiKhoan.doiMatKhau(tenTaiKhoan, password, newPassword);
        }
    }
}
