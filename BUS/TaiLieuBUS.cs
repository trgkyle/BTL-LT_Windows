using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    class TaiLieuBUS
    {
        private string maTaiLieu;
        private string tenTaiLieu;
        private string theLoai;
        private int soLuong;
        private string nhaXuatBan;
        private int namXuatBan;
        private string tacGia;

        public TaiLieuBUS(string maTaiLieu, string tenTaiLieu, string theLoai, int soLuong, string nhaXuatBan, int namXuatBan, string tacGia)
        {
            this.maTaiLieu = maTaiLieu;
            this.tenTaiLieu = tenTaiLieu;
            this.theLoai = theLoai;
            this.soLuong = soLuong;
            this.nhaXuatBan = nhaXuatBan;
            this.namXuatBan = namXuatBan;
            this.tacGia = tacGia;
        }
        
    }
}
