using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    class TheLoaiBUS
    {
        private string maTheLoai;
        private string tenTheLoai;
        private string ghiChu;

        public TheLoaiBUS(string maTheLoai, string tenTheLoai, string ghiChu)
        {
            this.maTheLoai = maTheLoai;
            this.tenTheLoai = tenTheLoai;
            this.ghiChu = ghiChu;
        }
    }
}
