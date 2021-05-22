using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class TheLoaiDAL
    {
        private string maTheLoai;
        private string tenTheLoai;
        private string ghiChu;

        public TheLoaiDAL(string maTheLoai, string tenTheLoai, string ghiChu)
        {
            this.maTheLoai = maTheLoai;
            this.tenTheLoai = tenTheLoai;
            this.ghiChu = ghiChu;
        }
    }
}
