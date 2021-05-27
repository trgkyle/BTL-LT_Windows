using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TaiKhoanDTO
    {
        string hoTen;
        string taiKhoan;
        string matKhau;
        string quyen;

        public TaiKhoanDTO(string hoTen, string taiKhoan, string matKhau, string quyen)
        {
            this.HoTen = hoTen;
            this.TaiKhoan = taiKhoan;
            this.MatKhau = matKhau;
            this.Quyen = quyen;
        }

        public string HoTen { get => hoTen; set => hoTen = value; }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
    }
}
