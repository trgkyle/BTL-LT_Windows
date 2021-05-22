using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TheLoaiDTO
    {
        private string maTheLoai;
        private string tenTheLoai;
        private string ghiChu;

        public TheLoaiDTO(string maTheLoai, string tenTheLoai, string ghiChu)
        {
            this.MaTheLoai = maTheLoai;
            this.TenTheLoai = tenTheLoai;
            this.GhiChu = ghiChu;
        }

        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
