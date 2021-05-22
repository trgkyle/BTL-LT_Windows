using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class NhanVienDAL
    {
        private string maNhanVien;
        private string hoTen;
        private string maChucVu;
        private string chucVu;
        private string taiKhoan;
        private string matKhau;
        private string quyen;

        public NhanVienDAL(string maNhanVien, string hoTen, string maChucVu, string chucVu, string taiKhoan, string matKhau, string quyen)
        {
            this.maNhanVien = maNhanVien;
            this.hoTen = hoTen;
            this.maChucVu = maChucVu;
            this.chucVu = chucVu;
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.quyen = quyen;
        }
    }
}
