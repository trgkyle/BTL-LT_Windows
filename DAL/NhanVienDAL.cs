using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class NhanVienDAL
    {
        dbDataContext data = new dbDataContext();

        public string TimTenNhanVienVoiMa(string maNhanVien)
        {
            data = new dbDataContext();

            try
            {
                var nhanVien = data.NhanViens.Single(x => x.MaNhanVien == maNhanVien);
                return nhanVien.HoTen;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
