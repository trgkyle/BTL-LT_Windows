using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanDAL
    {
        dbDataContext data = new dbDataContext();

        public Boolean dangNhap(string taiKhoan,string password)
        {
            data = new dbDataContext();

            try
            {
                var nhanVienRes = data.NhanViens.Single(nhanVien => nhanVien.TaiKhoan == taiKhoan && nhanVien.MatKhau == password);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public TaiKhoanDTO layThongTinTaiKhoan(string taiKhoan, string password)
        {
            data = new dbDataContext();

            try
            {
                var nhanVienRes = data.NhanViens.Single(nhanVien => nhanVien.TaiKhoan == taiKhoan && nhanVien.MatKhau == password);
                return new TaiKhoanDTO(nhanVienRes.HoTen, nhanVienRes.TaiKhoan,nhanVienRes.MatKhau,nhanVienRes.Quyen);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public Boolean doiMatKhau(string taiKhoan, string password, string newPassword)
        {
            data = new dbDataContext();

            try
            {
                var nhanVienRes = data.NhanViens.Single(nhanVien => nhanVien.TaiKhoan == taiKhoan && nhanVien.MatKhau == password);
                nhanVienRes.MatKhau = newPassword;
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        
    }
}
