using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class NhanVienBUS
    {
        NhanVienDAL nhanVienDB = new NhanVienDAL();
        public String searchTenNhanVien(string maDocGia)
        {
            return nhanVienDB.TimTenNhanVienVoiMa(maDocGia);
        }
    }
}
